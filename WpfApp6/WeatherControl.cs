using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private string napr;
        private int scvetr;
        Osadki now = Osadki.Solnechno;

        enum Osadki
        {
            Solnechno,
            Oblachno,
            Dogd, 
            Sneg
        }
        public string Napr
        {
            get => napr;
            set => napr = value;
        }
        public int Scvetr
        {
            get => scvetr;
            set => scvetr = value;

        }

        public int Temp
        {
            get => (int) GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public WeatherControl ( string napr, int temp)
        {
            this.Napr = napr;
            this.Temp = temp;
            this.Scvetr = scvetr;
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
                
        }
        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= 0 && v <= 200)
                return true;
            else 
                return false;

        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v > 0 )
                return v;
            else
                return 0;
        }
        public string Print()
        {
            return $"{Temp}{Napr}{Scvetr}{(int)Osadki.Solnechno}";
        }
    }
}
