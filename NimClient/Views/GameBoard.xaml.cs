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
using System.Windows.Data;

namespace NimClient.Views
{
    public partial class GameBoard : PhoneApplicationPage
    {
        bool _pvp = true;
        public GameBoard()
        {
            InitializeComponent();
            OK_Button.IsEnabled = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _pvp = bool.Parse(this.NavigationContext.QueryString["pvp"]);
            this.DataContext =
                new GameBoardViewModel(_pvp);
            base.OnNavigatedTo(e);
        }

        private void RowView1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row2.IsEnabled = false;
            row3.IsEnabled = false;
            row4.IsEnabled = false;
            OK_Button.IsEnabled = true;
        }

        private void OKButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = true;
            row2.IsEnabled = true;
            row3.IsEnabled = true;
            row4.IsEnabled = true;
            OK_Button.IsEnabled = false;

            ((GameBoardViewModel)this.DataContext).OKClick.Execute(null);

            //BindingExpression be = ((Button)sender).GetBindingExpression(Button.CommandProperty);
            //be.UpdateSource();
        }

        private void RowView2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = false;
            row3.IsEnabled = false;
            row4.IsEnabled = false;
            OK_Button.IsEnabled = true;

        }

        private void RowView3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = false;
            row2.IsEnabled = false;
            row4.IsEnabled = false;
            OK_Button.IsEnabled = true;

        }

        private void RowView4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            row1.IsEnabled = false;
            row2.IsEnabled = false;
            row3.IsEnabled = false;
            OK_Button.IsEnabled = true;

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}