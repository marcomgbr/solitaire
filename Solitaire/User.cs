using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    [Serializable]
    public class User
    {
        private int matchSequence;
        public int Id { get; }
        public string Username { get; set; }
        public string Alias { get; set; }
        public bool IsCurrentUser { get; set; }

        private List<GameResult> matches = new List<GameResult>();

        public User(int id)
        {
            Id = id;
        }

        public GameResult CreateGameResult()
        {
            GameResult response = new GameResult(++this.matchSequence, this.Id);
            return response;
        }

        public bool AddGameResult(GameResult r)
        {
            this.matches.Add(r);
            return true;
        }

        public List<GameResult> GetMatches()
        {
            return this.matches;
        }
    }

    [Serializable]
    public class GameResult
    {
        public int Id { get; }
        public int UserId { get; }
        public int Score { get; set; }
        public TimeSpan GameDuration { get; set; }
        public DateTime Date { get; set; }

        public GameResult(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
