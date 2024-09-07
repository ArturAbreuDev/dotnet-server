using System;

namespace MarketVotingSystem.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string MarketId { get; set; }
        public DateTime VotedAt { get; set; }
        public string ClientId { get; set; } = string.Empty;
    }
}
