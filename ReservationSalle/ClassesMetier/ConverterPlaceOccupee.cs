using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ClassesMetier
{
    public class ConverterPlaceOccupee : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            char etat = (char)value;

            if(etat == 'o')
            {
                Color c = Colors.Red;
                return new SolidColorBrush(c);
            }
            else
            {
                if (etat == 'l')
                {
                    Color c = Colors.Yellow;
                    return new SolidColorBrush(c);
                }
                else
                {
                    Color c = Colors.YellowGreen;
                    return new SolidColorBrush(c);
                } 
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
