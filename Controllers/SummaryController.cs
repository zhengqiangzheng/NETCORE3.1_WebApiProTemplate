using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("V1/[controller]")]
    [ApiController]
    public class SummaryController : Controller
    {
        private readonly ISummaryDepository summaryDepository;

        public SummaryController(ISummaryDepository summaryDepository)
        {
            this.summaryDepository = summaryDepository;
        }
        public async Task<IActionResult> Get()
        {
            var res =await summaryDepository.GetCompanySummary();
            return Ok(res);
        }
    }
}