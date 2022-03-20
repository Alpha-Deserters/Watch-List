using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Watch_List.XAML.Windows;

namespace Watch_List.Classes.Dictonary_Handlers
{
    partial class MainToolBarHandler
    {

        private void AnimeSeachClick(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;
            new AnimeSearchWindow().Show();           
        }
    }
}
