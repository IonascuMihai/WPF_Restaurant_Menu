using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        bool showPass = false;
        public RegisterView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!showPass)
            {
                showPass = true;
                PasswordUnmask.Visibility = Visibility.Visible;
                passBox.Visibility = Visibility.Hidden;
                PasswordUnmask.Text = passBox.Password;
            }
            else
            {
                showPass = false;
                PasswordUnmask.Visibility = Visibility.Hidden;
                passBox.Visibility = Visibility.Visible;
            }
        }
    }
}
