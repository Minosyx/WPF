using System.Windows;
using System.Windows.Controls;

namespace Controls
{
    public class UGrid : Grid
    {
        public int Rows { get; set; } = 1;
        public int Cols { get; set; } = 1;

        private int smaller;

        protected override Size MeasureOverride(Size availableSize)
        {
            smaller = InternalChildren.Count > Rows * Cols ? Rows * Cols : InternalChildren.Count;
            for (int i = 0; i < smaller; i++)
            {
                var child = InternalChildren[i];
                child?.Measure(availableSize);
            }

            Size avail = new Size(ActualWidth / Cols, ActualHeight / Rows);
            return avail;
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            double yindex = 0;
            for (int i = 0; i < smaller; i++)
            {
                var child = InternalChildren[i];
                if (child == null) break;
                if (i != 0 && i % Cols == 0) yindex++;
                double x = i % Cols * arrangeSize.Width / Cols;
                double y = yindex * arrangeSize.Height / Rows;

                Size avail = new Size(arrangeSize.Width / Cols, arrangeSize.Height / Rows);
                child.Arrange(new Rect(new Point(x, y), avail));
            }

            return arrangeSize;
        }
    }
}
