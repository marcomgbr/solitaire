using MMG.Forms;
using System;
using System.Windows.Forms;

namespace Solitaire
{
    class GameSession 
    {
        static GameSession instance = null;

        DateTime gameStart = DateTime.Now;
        Timer timer;

        private ToolStripStatusLabel userStatusLabel;
        private ToolStripStatusLabel stockStatusLabel;
        private ToolStripStatusLabel wasteStatusLabel;
        private ToolStripStatusLabel timeStatusLabel;
        private ToolStripStatusLabel scoreStatusLabel;

        private GameSession()
        {
        }

        public static GameSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameSession();
                    Console.WriteLine($"New {GameSession.Instance.GetType()} instance created.");
                }
                return instance;
            }
        }

        public void Init(Timer timer, ToolStripStatusLabel userStatusLabel,
            ToolStripStatusLabel stockStatusLabel, ToolStripStatusLabel wasteStatusLabel,
            ToolStripStatusLabel timeStatusLabel, ToolStripStatusLabel scoreStatusLabel)
        {
            this.timer = timer;
            this.userStatusLabel = userStatusLabel;
            this.stockStatusLabel = stockStatusLabel;
            this.wasteStatusLabel = wasteStatusLabel;
            this.timeStatusLabel = timeStatusLabel;
            this.scoreStatusLabel = scoreStatusLabel;
        }

        public TimeSpan GameDuration { get; set; }
        public ObjectBinaryPersistence<UserCollection> UserDataFile { get; set; }
        public GameController Controller { get; set; }
        public UserCollection UserCollection { get; set; }

        private User user;
        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.userStatusLabel.Text = "Player: ";
                this.userStatusLabel.Text += value.Alias != "" ? value.Alias : value.Username;
                this.user = value;
            }
        }

        public int StockCount
        {
            set
            {
                this.stockStatusLabel.Text = " Stock: " + value.ToString();
            }
        }

        public int WasteCount
        {
            set
            {
                this.wasteStatusLabel.Text = " Waste: " + value.ToString();
            }
        }

        private int score = 0;
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
                this.scoreStatusLabel.Text = " Score: " + this.score.ToString();
            }
        }

        bool isRunning = false;
        public void StartTimer()
        {
            if (!isRunning)
            {
                this.gameStart = DateTime.Now;
                this.timer.Start();
                isRunning = true;
            }
        }

        public void UpdateTime()
        {
            this.GameDuration = DateTime.Now - this.gameStart;
            this.timeStatusLabel.Text = " Time: " + this.GameDuration.ToString().Substring(0, 8);
        }

        public void StopTimer()
        {
            this.timer.Stop();
            isRunning = false;
        }
        
        public static void Invalidate()
        {
            GameSession.Instance.StopTimer();
            instance = null;
        }
    }
}
