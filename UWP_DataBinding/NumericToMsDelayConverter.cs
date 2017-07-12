using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWP_DataBinding
{
    public class NumericToMsDelayConverter: IValueConverter
    {
        private const string msSymbol = "ms";
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format("{0}  {1}", value, msSymbol);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException("Do something about the reverse conversion");
        }
    }
}
