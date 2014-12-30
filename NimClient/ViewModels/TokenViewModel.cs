using NimClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimClient.ViewModels
{
    internal class TokenViewModel : BaseViewModel
    {
        private RelayCommand _tokentap;

        public RelayCommand TokenTap { get { return _tokentap; } }

        public TokenViewModel() : this(new RelayCommand((obj) => { return; })) { }

        public TokenViewModel(RelayCommand tokentap)
        {
            _tokentap = tokentap;
        }
    }
}
