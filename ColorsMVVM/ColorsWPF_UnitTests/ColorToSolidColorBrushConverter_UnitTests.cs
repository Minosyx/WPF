using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorsMVVM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorsMVVM.UnitTests
{
    [TestClass()]
    public class ConvertersTests
    {
        [TestMethod()]
        public void ColorToSolidBrushTest()
        {
            ColorToSolidColorBrushConverter converter = new ColorToSolidColorBrushConverter();
            Color color = Colors.Violet;

            object obj = converter.Convert(color, typeof(SolidColorBrush), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(obj, typeof(SolidColorBrush));

            SolidColorBrush brush = (SolidColorBrush) obj;
            Assert.AreEqual(color, brush.Color);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void SolidBrushToColorTest()
        {
            ColorToSolidColorBrushConverter converter = new ColorToSolidColorBrushConverter();
            converter.ConvertBack(null, null, null, null);
        }
    }
}