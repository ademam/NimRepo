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

        public RelayCommand Remove { get { return _remove ?? (_remove = new RelayCommand((obj) => RemoveToken())); } }

        private void RemoveToken()
        {
            if (TokenCount > 0) TokenCount--;
        }

        #endregion

        public int TokenCount
        {
            set 
            { 
                _tokencount = value;
                OnPropertyChanged("Tokens");
            }
            get { return _tokencount; }
        }

        public string Tokens
        {
            get
            {
                string tok = string.Empty;
                for(int i = 0; i < TokenCount; i++)
                {
                    tok += "* ";
                }

                return tok;
            }
        }


        public RowViewModel() : this(0) { }

        public RowViewModel(int tokencount)
        {
            _tokencount = tokencount;
        }
    }
}
