using NimClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimClient.ViewModels
{
    internal class GameBoardViewModel : BaseViewModel
    {
        #region Constants

        private const string PLAYER_ONE_TURN = "Player 1 Turn";
        private const string PLAYER_TWO_TURN = "Player 2 Turn";
        private const string PLAYER_TURN = "Player Turn";
        private const string AI_TURN = "AI Turn";
        private const string PLAYER_ONE_WINS = "Player 1 Wins!";
        private const string PLAYER_TWO_WINS = "Player 2 Wins!";
        private const string PLAYER_WINS = "You Win!!";
        private const string AI_WINS = "You Lose...";
        private const string PVP_GAME = "NIM PVP";
        private const string AI_GAME = "NIM Player Vs. AI";

        #endregion

        #region Members

        private bool _pvp = true;
        private bool _isplayable = true;

        private string _gametype = string.Empty;
        private string _gamemessage = string.Empty;

        private RowViewModel _row1;
        private RowViewModel _row2;
        private RowViewModel _row3;
        private RowViewModel _row4;

        private RelayCommand _okclick;

        #endregion

        #region Properties

        public RowViewModel Row1 { get { return _row1 ?? (_row1 = new RowViewModel(1)); } }
        public RowViewModel Row2 { get { return _row2 ?? (_row2 = new RowViewModel(3)); } }
        public RowViewModel Row3 { get { return _row3 ?? (_row3 = new RowViewModel(5)); } }
        public RowViewModel Row4 { get { return _row4 ?? (_row4 = new RowViewModel(7)); } }

        public RelayCommand OKClick
        {
            get { return _okclick ?? (_okclick = new RelayCommand((obj) => OKButtonClicked())); }
        }

        public RelayCommand YesFirst
        {
            get { return _yesfirst ?? (_yesfirst = new RelayCommand((obj) => YesFirstClicked())); }
        }

        public RelayCommand NoFirst
        {
            get { return _nofirst ?? (_nofirst = new RelayCommand((obj) => NoFirstClicked())); }
        }

        private void NoFirstClicked()
        {
            BoardVisible = true;
            MenuVisible = true;
            QuestionVisible = false;
            GameMessage = AI_TURN;
            AINext();
        }

        private void YesFirstClicked()
        {
            BoardVisible = true;
            MenuVisible = true;
            QuestionVisible = false;
            GameMessage = PLAYER_TURN;
        }

        public bool IsPlayable
        {
            set { _isplayable = value; OnPropertyChanged("IsPlayable"); }
            get { return _isplayable; }
        }

        public bool BoardVisible
        {
            set { _boardvisible = value; OnPropertyChanged("BoardVisible"); }
            get { return _boardvisible; }
        }

        public bool QuestionVisible
        {
            set { _questionvisible = value; OnPropertyChanged("QuestionVisible"); }
            get { return _questionvisible; }
        }

        public bool MenuVisible
        {
            set { _menuvisible = value; OnPropertyChanged("MenuVisible"); }
            get { return _menuvisible; }
        }

        public string GameType
        {
            set { _gametype = value; OnPropertyChanged("GameType"); }
            get { return _gametype; }
        }

        public string GameMessage
        {
            set { _gamemessage = value; OnPropertyChanged("GameMessage"); }
            get { return _gamemessage; }
        }

        #endregion

        #region Constructors

        public GameBoardViewModel() : this(true){}

        public GameBoardViewModel(bool pvp)
        {
            if (pvp) SetupPVPGame();
            else SetupAiGame();
           
        }

        #endregion

        #region Private Methods

        private void SetupAiGame()
        {
            _pvp = false;

            GameMessage = "Go First?";
            GameType = AI_GAME;
            QuestionVisible = true;
            MenuVisible = false;
            BoardVisible = false;

            //AINext(); //todo Question first?
        }

        private void SetupPVPGame()
        {
            _pvp = true;
            _boardvisible = true;
            _menuvisible = true;
            GameMessage = PLAYER_ONE_TURN;
            GameType = PVP_GAME;
        }

        private void OKButtonClicked()
        {
            if (_pvp)
            {
                PVPGameNext();
            }
            else AINext();
        }

        private void AINext()
        {
            if(GameManager.IsVictory(new INimRow[] { _row1, _row2, _row3, _row4 }))
            {
                IsPlayable = false;
                GameMessage = PLAYER_WINS;
            }
            else
            {
                IsPlayable = false;
                GameMessage = AI_TURN;

                Task t = Task.Run(() =>
                {
                    GameManager.CalculateAITurn(new INimRow[] { _row1, _row2, _row3, _row4 });
                    
                }).ContinueWith(o =>
                {
                    if (GameManager.IsVictory(new INimRow[] { _row1, _row2, _row3, _row4 }))
                    {
                        IsPlayable = false;
                        GameMessage = AI_WINS;
                    }
                    else
                    {
                        IsPlayable = true;
                        GameMessage = PLAYER_TURN;
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void PVPGameNext()
        {
            if (IsPLayerOneTurn())
            {
                if (GameManager.IsVictory(new INimRow[] { _row1, _row2, _row3, _row4 }))
                {
                    IsPlayable = false;
                    GameMessage = PLAYER_ONE_WINS;
                }
                else
                {
                    GameMessage = PLAYER_TWO_TURN;
                }
            }
            else
            {
                if (GameManager.IsVictory(new INimRow[] { _row1, _row2, _row3, _row4 }))
                {
                    IsPlayable = false;
                    GameMessage = PLAYER_TWO_WINS;
                }
                else
                {
                    GameMessage = PLAYER_ONE_TURN;
                }
            }
        }      
    
        private bool IsPLayerOneTurn()
        {
            if (_gamemessage == PLAYER_ONE_TURN) return true;
            return false;
        }

        #endregion


        public bool _questionvisible { get; set; }

        public RelayCommand _yesfirst { get; set; }

        public RelayCommand _nofirst { get; set; }

        public bool _menuvisible { get; set; }

        public bool _boardvisible { get; set; }
    }
}
