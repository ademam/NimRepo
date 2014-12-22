using NimClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimClient.ViewModels
{
    internal class GameBoardViewModel
    {
        private RowViewModel _row1;
        private RowViewModel _row2;
        private RowViewModel _row3;
        private RowViewModel _row4;

        public RowViewModel Row1 { get { return _row1 ?? (_row1 = new RowViewModel(1)); } }
        public RowViewModel Row2 { get { return _row2 ?? (_row2 = new RowViewModel(3)); } }
        public RowViewModel Row3 { get { return _row3 ?? (_row3 = new RowViewModel(5)); } }
        public RowViewModel Row4 { get { return _row4 ?? (_row4 = new RowViewModel(7)); } }


        public GameBoardViewModel()
        {
        }
    }
}
