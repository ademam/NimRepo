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
    public partial class Token : UserControl
    {
        public Token()
        {
            InitializeComponent();
        }

        private void Token_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            lock (token)
            {
                if (token.IsEnabled)
                {
                    token.Content = " ";
                    token.IsEnabled = false;
                    ((TokenViewModel)this.DataContext).TokenTap.Execute(null); //ugly but until I can determine why there are spurrious call to Token tap this works
                }
            }
        }
    }
}
