using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotWatson.Models;
using Microsoft.AspNetCore.Mvc;

namespace BotWatson.Controllers
{
    public interface IBotsController
    {
        Task<ActionResult<Bot>> DeleteBot(string id);
        Task<ActionResult<IEnumerable<Bot>>> GetBot();
        Task<ActionResult<Bot>> GetBot(string id);
        Task<ActionResult<Bot>> PostBot(Bot bot);
        Task<IActionResult> PutBot(string id, Bot bot);
    }
}