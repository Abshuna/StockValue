using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mtapi.mt5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OMSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockForecastController : ControllerBase
    {
        private readonly ILogger<StockForecastController> _logger;

        public StockForecastController(ILogger<StockForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public StockForecast Get()
        {
            string Symbol = "XAUUSD.DEMO";
            StockForecast wf = new StockForecast();
            var api = new MT5API(8631960, "dd4444vv", "mt5demo.acetopfx.com", 443);
            //var api = new MT5API(5280, "FEED@12", "fincapmarkets", 443);
      
            Console.WriteLine("Connecting...");
            api.Connect();
            Console.WriteLine("Connected to server");
            while (api.GetQuote(Symbol) == null)
                Thread.Sleep(10);
            Quote quoteValue = api.GetQuote(Symbol);
            wf.BidValue = quoteValue.Bid.ToString();

            while (api.GetQuote("XAGUSD.DEMO") == null)
                Thread.Sleep(10);
            quoteValue = api.GetQuote("XAGUSD.DEMO");
            // StockForecast wf = new StockForecast();
            wf.SilverbidValue = quoteValue.Bid.ToString();
            return wf;
        }
    }
}
