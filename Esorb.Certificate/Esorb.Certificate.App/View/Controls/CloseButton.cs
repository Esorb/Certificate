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
    public class CloseButton : ButtonBase
    {
        static CloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CloseButton), new FrameworkPropertyMetadata(typeof(CloseButton)));
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(CloseButton), new PropertyMetadata(""));

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

    }
}
