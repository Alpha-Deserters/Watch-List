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
using System.Windows.Shapes;
using Watch_List.Models;
using Watch_List.Classes;

namespace Watch_List.XAML.Windows
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private User _user;
        public ProfileWindow(User user)
        {
            InitializeComponent();
            _user = user;
            var api = new AnimeAPI();
            var res = api.GetAnimeByName("Bleach");
            //this.Visibility = Visibility.Visible;
        }
    }
}
