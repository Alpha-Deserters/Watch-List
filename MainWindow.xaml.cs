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
using Watch_List.XAML_windows;
using Watch_List.Tool_classes;
using Watch_List.Model_classes;
namespace Watch_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            await LoginButtonClickAsync();
        }

        private void RegisterButtton_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
        }

        private async Task LoginButtonClickAsync() 
        {
            var users = new UserItems();
            await users.UpdateItems();

            foreach (var user in users.Items)
            {
                if (LoginTB.Text == user.Login &&
                   PasswordTB.Text == user.Password)
                {
                    new ProfileWindow(user).Show();
                }
            }
        }

    }
}
