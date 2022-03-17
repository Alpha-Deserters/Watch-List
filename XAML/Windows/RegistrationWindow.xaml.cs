using System.Threading.Tasks;
using System.Windows;
using Watch_List.Models;
using Watch_List.Classes;
using Watch_List.Interfaces;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Watch_List.XAML.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window, ISourceInitializer
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            InitSource();
        }

        public void InitSource()
        {
            var images = new Dictionary<string, Image>()
            {
                {"2", RegImage }
            };
            this.SetImageSource(images);
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
            var error = users.Items.TryCheckUniqueness(user);

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
                Close();
            }
            else if (result.Data == false)
            {
                MessageBox.Show("блять..");
            }
        }        
    }
}
