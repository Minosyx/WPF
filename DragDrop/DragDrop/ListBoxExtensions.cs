﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DragDrop
{
    public static class ListBoxExtensions
    {
        public static ListBoxItem GetItemAt(this ListBox listBox, Point position)
        {
            DependencyObject item = VisualTreeHelper.HitTest(listBox, position).VisualHit;
            while (item != null && item is not ListBoxItem)
                item = VisualTreeHelper.GetParent(item);
            return item as ListBoxItem;
        }

        public static int IndexFromPoint(this ListBox listBox, Point position)
        {
            ListBoxItem item = GetItemAt(listBox, position);
            return listBox.Items.IndexOf(item);
        }
    }
}
