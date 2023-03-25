using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Esorb.Certificate.App.View.Controls
{
    public class MinimizeButton : ButtonBase
    {
        static MinimizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MinimizeButton), new FrameworkPropertyMetadata(typeof(MinimizeButton)));
        }

        public static readonly DependencyProperty MinIconProperty = DependencyProperty.Register("MinIcon", typeof(string), typeof(MinimizeButton), new PropertyMetadata(""));

        public string MinIcon
        {
            get { return (string)GetValue(MinIconProperty); }
            set { SetValue(MinIconProperty, value); }
        }

    }
}
