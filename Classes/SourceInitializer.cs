using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Watch_List.Interfaces;

namespace Watch_List.Classes
{
    public static class SourceInitializer
    {
        // this ISourceInitializer, потому что Window classes не наследуются от классов
        // не сделал this Window, потому как является нарушением инкапсуляции

        /// <summary>
        /// Sets the image path (Source)
        /// </summary>
        public static void SetImageSource(this ISourceInitializer _, Dictionary<string, Image> items)
        {
            foreach (var item in items)
            {
                item.Value.Source = new BitmapImage(
                    new Uri($"{LocalPath.ImagePath}{item.Key}.png"));
            }
        }
    }
}
