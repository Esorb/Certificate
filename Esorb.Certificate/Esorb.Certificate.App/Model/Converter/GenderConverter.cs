using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.App.Model.Converter
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string SelectedValue = value as string;

            return SelectedValue switch
            {
                "female" => "weiblich",
                "male" => "männlich",
                "diverse" => "divers",
                _ => "weiblich",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
