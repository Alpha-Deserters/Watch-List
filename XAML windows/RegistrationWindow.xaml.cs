using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using Watch_List.Model_classes;
using Watch_List.Tool_classes;

namespace Watch_List.XAML_windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        // async void is bad, but Event handlers are the exception (Mincrosft Documentaion)        
        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            await RegisterButtonClickAsync();
        }

        private async Task RegisterButtonClickAsync()
        {
            var user = new User(LoginTB.Text, PasswordTB.Text, EmailTB.Text);
            var users = new UserItems();

            await users.UpdateItems();
            var error = users.Items.CheckUniqueness(user);

            if (error != null)
            {
                MessageBox.Show(error.Message);
                return;
            }

            users.Items.Add(user);
            var result = await FileConverter.TryWriteToJson(users, "Users");

            if (result.Data == true)
            {
                MessageBox.Show("Успешная регистрация!");
            }
            else if (result.Data == false)
            {
                MessageBox.Show("блять..");
            }
        }
    }
}
