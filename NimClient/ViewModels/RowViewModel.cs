using NimClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimClient.ViewModels
{
    internal class RowViewModel : BaseViewModel, INimRow
    {
        #region members

        int _tokencount;
        RelayCommand _remove;
        TokenViewModel[] _tokens;

        public RelayCommand Remove { get { return _remove ?? (_remove = new RelayCommand((obj) => RemoveToken())); } }

        private void RemoveToken()
        {
            if (_tokencount > 0) _tokencount--;
        }

        #endregion

        public int TokenCount
        {
            get { return _tokencount; }
        }

        public TokenViewModel[] Tokens
        {
            get
            {
                return _tokens;
            }
        }


        public RowViewModel() : this(0) { }

        public RowViewModel(int tokencount)
        {
            _tokencount = tokencount;
            BuildTokens(tokencount);
        }

        private void BuildTokens(int tokencount)
        {
            List<TokenViewModel> tokens = new List<TokenViewModel>();
 	        for(int i = 0; i < tokencount; i++)
            {
                tokens.Add(new TokenViewModel(Remove));
            }

            _tokens = tokens.ToArray();
            OnPropertyChanged("Tokens");
        }


        void INimRow.RemoveToken()
        {
            TokenViewModel token = Tokens.Where(tok => tok.Enabled == true).First();
            token.Tap();
        }
    }
}
