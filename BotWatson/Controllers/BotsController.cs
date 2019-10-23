﻿using System;
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
    public class BotsController : ControllerBase, IBotsController
    {
        private readonly ApplicationDbContext _context;

        public BotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bot>>> GetBot()
        {
            return await _context.Bot.ToListAsync();
        }

        // GET: api/Bots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bot>> GetBot(string id)
        {
            var bot = await _context.Bot.FindAsync(id);

            if (bot == null)
            {
                return NotFound();
            }

            return bot;
        }

        // PUT: api/Bots/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBot(string id, Bot bot)
        {
            if (id != bot.Id)
            {
                return BadRequest();
            }

            _context.Entry(bot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BotExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bots
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bot>> PostBot(Bot bot)
        {
            _context.Bot.Add(bot);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BotExists(bot.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBot", new { id = bot.Id }, bot);
        }

        // DELETE: api/Bots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bot>> DeleteBot(string id)
        {
            var bot = await _context.Bot.FindAsync(id);
            if (bot == null)
            {
                return NotFound();
            }

            _context.Bot.Remove(bot);
            await _context.SaveChangesAsync();

            return bot;
        }

        private bool BotExists(string id)
        {
            return _context.Bot.Any(e => e.Id == id);
        }
    }
}
