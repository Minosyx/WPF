using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class SColor : IComparable<SColor>
        {
            public string Name { get; set; }
            public SolidColorBrush Color { get; set; }

            public int CompareTo(SColor obj)
            {
                if (Color.Color.R < obj.Color.Color.R)
                    return 1;
                if (Color.Color.R > obj.Color.Color.R)
                    return -1;
                if (Color.Color.G < obj.Color.Color.G)
                    return 1;
                if (Color.Color.G > obj.Color.Color.G)
                    return -1;
                if (Color.Color.B < obj.Color.Color.B)
                    return 1;
                if (Color.Color.B > obj.Color.Color.B)
                    return -1;

                return 0;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadSystemColors();
        }

        public void LoadSystemColors()
        {
            List<SColor> colors = new List<SColor>();
            Type t = typeof(SystemColors);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(Color))
                {
                    SColor color = new SColor();
                    //BindingFlags.GetProperty, null, null, null
                    color.Color = new SolidColorBrush((Color) property.GetValue(new Color()));
                    color.Name = property.Name;

                    colors.Add(color);
                }
            }

            colors.Sort();
            combo.ItemsSource = colors;
        }
    }
}
