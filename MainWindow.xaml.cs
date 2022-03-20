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
using Watch_List.XAML.Windows;
using Watch_List.Models;
using Watch_List.Classes;
using Watch_List.Interfaces;
using System.ComponentModel;

namespace Watch_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISourceInitializer
    {
        public MainWindow()
        {
            InitializeComponent();           
            InitSource();// init source path 
        }

        public void InitSource()
        {
            var images = new Dictionary<string, Image>()
            {
                {"ia1205", AutorizationImage },
                {"login", UserImage },
                {"lock", LockImage }
            };
            this.SetImageSource(images);
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
                    this.Close();
                }
            }
        }       
    }
}
