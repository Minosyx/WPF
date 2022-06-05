using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DragDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _dragStartPoint;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragStartPoint = e.GetPosition(null);

            //ListBox lbSender = sender as ListBox;
            //ListBoxItem przenoszonyElement = lbSender.GetItemAt(e.GetPosition(lbSender));
            //if (przenoszonyElement != null)
            //{
            //    DataObject dane = new DataObject();
            //    //dane.SetData("Format_Lista", lbSender);
            //    //dane.SetData("Format_ElementListy", przenoszonyElement);
            //    dane.SetData(DataFormats.StringFormat, przenoszonyElement.Content as string);
            //    DragDropEffects wynik = System.Windows.DragDrop.DoDragDrop(lbSender, dane, DragDropEffects.Copy | DragDropEffects.Move);

            //    if (wynik == DragDropEffects.Move)
            //        lbSender.Items.Remove(przenoszonyElement);
            //}
        }

        private void ListBox_OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.KeyStates.HasFlag(DragDropKeyStates.ControlKey) ? DragDropEffects.Copy : DragDropEffects.Move;
        }

        private void ListBox_OnDrop(object sender, DragEventArgs e)
        {
            ListBox lbSender = sender as ListBox;

            //ListBox lbSource = e.Data.GetData("Format_Lista") as ListBox;
            //ListBoxItem przenoszonyElement = e.Data.GetData("Format_ElementListy") as ListBoxItem;

            //if (!e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
            //    lbSource.Items.Remove(przenoszonyElement);
            //else przenoszonyElement = new ListBoxItem() {Content = przenoszonyElement.Content};

            string etykietaPrzenoszonychElementow = e.Data.GetData(DataFormats.StringFormat) as string;
            string[] etykietaElementu = etykietaPrzenoszonychElementow.Split(";");

            e.Effects = e.KeyStates.HasFlag(DragDropKeyStates.ControlKey) ? DragDropEffects.Copy : DragDropEffects.Move;

            foreach (var et in etykietaElementu)
            {
                ListBoxItem przenoszonyElement = new ListBoxItem() {Content = et};
                int index = lbSender.IndexFromPoint(e.GetPosition(lbSender));
                if (index < 0) lbSender.Items.Add(przenoszonyElement);
                else lbSender.Items.Insert(index, przenoszonyElement);
            }
        }

        private void ListBox_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(null);
            Vector diff = _dragStartPoint - point;
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                var sb = new StringBuilder();
                var lbSender = sender as ListBox;
                var przenoszoneElementy = new List<ListBoxItem>();
                przenoszoneElementy.Add(lbSender.GetItemAt(e.GetPosition(lbSender)));
                foreach (var item in lbSender.SelectedItems)
                {
                    if (przenoszoneElementy.Count == 0)
                        przenoszoneElementy.Add(item as ListBoxItem);
                    for (int i = 0; i < przenoszoneElementy.Count + 1; i++)
                    {
                        if (przenoszoneElementy.Contains(item))
                            break;
                        if (i == przenoszoneElementy.Count)
                        {
                            przenoszoneElementy.Add(item as ListBoxItem);
                            break;
                        }

                        if (lbSender.Items.IndexOf(item) > lbSender.Items.IndexOf(przenoszoneElementy[i]))
                            continue;
                        przenoszoneElementy.Insert(i, item as ListBoxItem);
                    }
                }

                foreach (var item in przenoszoneElementy)
                {
                    sb.Append(item.Content + ";");
                }

                sb.Remove(sb.Length - 1, 1);
                if (przenoszoneElementy.Count != 0)
                {
                    var dane = new DataObject();
                    dane.SetData(DataFormats.StringFormat, sb.ToString());
                    var wynik = System.Windows.DragDrop.DoDragDrop(lbSender, dane, DragDropEffects.Copy | DragDropEffects.Move);

                    if (wynik != DragDropEffects.Move) return;
                    foreach (var item in przenoszoneElementy)
                        lbSender.Items.Remove(item);
                }
            }
        }
    }
}
