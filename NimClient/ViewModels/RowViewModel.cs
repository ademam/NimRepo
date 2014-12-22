using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimClient.ViewModels
{
    internal class RowViewModel
    {
        #region members

        int _tokencount = 1;

        #endregion

        public int TokenCount
        {
            set { _tokencount = value; }
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

        }
    }
}
