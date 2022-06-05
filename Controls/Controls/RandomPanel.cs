using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Controls
{
    public class RandomPanel : Panel
    {
        public Size ContentSize { get; set; } = new Size(300, 200);
        public Size MinimalChildSize { get; set; } = new Size(100, 25);

        private Random random = new();
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }
            return ContentSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            List<Rect> history = new List<Rect>();

            foreach (UIElement child in InternalChildren)
            {
                int _counter = 0;
                Rect rect;
                Size childSize = child.DesiredSize;
                child.Visibility = Visibility.Visible;
                if (childSize.Width < MinimalChildSize.Width)
                    childSize.Width = MinimalChildSize.Width;
                if (childSize.Height < MinimalChildSize.Height)
                    childSize.Height = MinimalChildSize.Height;

                bool intersects;
                bool skip = false;
                do
                {
                    if (_counter > 1000)
                        skip = true;
                    intersects = false;
                    var x = ContentSize.Width * random.NextDouble();
                    var y = ContentSize.Height * random.NextDouble();
                    rect = new Rect(new Point(x, y), childSize);
                    foreach (var r in history.Where(r => rect.IntersectsWith(r)))
                    {
                        intersects = true;
                    }

                    _counter++;
                } while (intersects && !skip);


                child.Arrange(rect);
                if (!skip)
                    history.Add(rect);
                else
                    child.Visibility = Visibility.Hidden;

            }

            return finalSize;
        }
    }
}
