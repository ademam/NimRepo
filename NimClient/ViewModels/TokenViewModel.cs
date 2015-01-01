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
        private string _content = "*";
        private bool _enabled = true;
        private RelayCommand _tokentap;

        public string Content
        {
            get { return _content; }
        }

        public bool Enabled
        {
            get { return _enabled; }
        }

        public RelayCommand TokenTap { get { return new RelayCommand((obj) => Tap()); } }

        public void Tap()
        {
            _content = " ";
            _enabled = false;
            _tokentap.Execute(null);

            OnPropertyChanged("Content");
            OnPropertyChanged("Enabled");
        }

        public TokenViewModel() : this(new RelayCommand((obj) => { return; })) { }

        public TokenViewModel(RelayCommand tokentap)
        {
            _tokentap = tokentap;
        }
    }
}
