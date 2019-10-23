using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotWatson.Models;
using Microsoft.AspNetCore.Mvc;

namespace BotWatson.Controllers
{
    public interface IMessagesController
    {
        Task<ActionResult<IEnumerable<Messagem>>> GetMessagem();
        Task<ActionResult<Messagem>> GetMessagem(string id);
        Task<ActionResult<Messagem>> PostMessagem(Messagem messagem);
    }
}