using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BotWatson.Data;
using BotWatson.Models;

namespace BotWatson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase, IMessagesController
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Messagem>>> GetMessagem()
        {
            return await _context.Messagem.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Messagem>> GetMessagem(string id)
        {
            var messagem = await _context.Messagem.FindAsync(id);

            if (messagem == null)
            {
                return NotFound();
            }

            return messagem;
        }


        [HttpGet("{conversationId}")]
        public async Task<ActionResult<IEnumerable<Messagem>>> GetMessagemByConversationId(string conversationId)
        {
            return await _context.Messagem.Where(m => m.ConversationId == conversationId).ToListAsync();
        }

        // POST: api/Messages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Messagem>> PostMessagem(Messagem messagem)
        {
            _context.Messagem.Add(messagem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MessagemExists(messagem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMessagem", new { id = messagem.Id }, messagem);
        }

        private bool MessagemExists(string id)
        {
            return _context.Messagem.Any(e => e.Id == id);
        }
    }
}
