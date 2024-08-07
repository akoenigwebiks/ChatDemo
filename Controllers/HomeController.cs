using ChatDemo.Models;
using ChatDemo.Sockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Diagnostics;

namespace ChatDemo.Controllers
{
    public record Threat();
    public record CounterMeasureResponse();
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddNum(int num)
        {
            await _hubContext.Clients.All.SendAsync("FE_sendNumber", num);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateThreat(Threat threat)
        {
            await _hubContext.Clients.All.SendAsync("NotifyIronDomeOfThreat", threat);
            return Ok();
        }

        [HttpGet]
        public Task CreateResponse(CounterMeasureResponse counterMeasureResponse)
        {
            // PROTECT ZION!!!
            return null!;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
