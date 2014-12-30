using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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
            token.Content = " ";
            this.IsEnabled = false;
            ((Button)sender).GetBindingExpression(Button.CommandProperty).UpdateSource();
        }
    }
}
