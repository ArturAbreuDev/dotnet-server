using Microsoft.AspNetCore.Mvc;
using MarketVotingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarketVotingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotingController : ControllerBase
    {
        private static List<Market> _markets = new List<Market>
        {
            new Market { Id = "Zanela", Name = "Market A" },
            new Market { Id = "São jorge", Name = "Market B" }
        };

        private static List<Vote> _votes = new List<Vote>();

        [HttpPost("vote")]
        public IActionResult Vote([FromBody] Vote vote)
        {
            var existingVote = _votes.FirstOrDefault(v => v.ClientId == vote.ClientId && v.VotedAt.Date == DateTime.Today);
            if (existingVote != null)
            {
                return BadRequest("Você já votou hoje.");
            }

            if (_votes.Any(v => v.MarketId == vote.MarketId && v.VotedAt.Month == DateTime.Today.Month))
            {
                return BadRequest("O mercado já foi escolhido este mês.");
            }

            vote.VotedAt = DateTime.Now;
            _votes.Add(vote);
            return Ok();
        }

        [HttpGet("results")]
        public IActionResult GetResults()
        {
            var result = _votes
                .GroupBy(v => v.MarketId)
                .Select(g => new
                {
                    MarketId = g.Key,
                    Votes = g.Count()
                });

            return Ok(result);
        }
    }
}
