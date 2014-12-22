using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NimClient.ViewModels;

namespace NimClient.Views
{
    public partial class GameBoard : PhoneApplicationPage
    {
        public GameBoard()
        {
            InitializeComponent();
            this.DataContext = new GameBoardViewModel();
        }

        private void RowView1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row2.IsEnabled = false;
            row3.IsEnabled = false;
            row4.IsEnabled = false;
        }

        private void OKButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = true;
            row2.IsEnabled = true;
            row3.IsEnabled = true;
            row4.IsEnabled = true;
        }

        private void RowView2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = false;
            row3.IsEnabled = false;
            row4.IsEnabled = false;
        }

        private void RowView3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = false;
            row2.IsEnabled = false;
            row4.IsEnabled = false;
        }

        private void RowView4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = false;
            row2.IsEnabled = false;
            row3.IsEnabled = false;
        }
    }
}