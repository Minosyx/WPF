﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Choinka
{
    public class IkonaWZasobniku : IDisposable
    {
        private NotifyIcon notifyIcon;
        private System.Windows.Window okno;

        public IkonaWZasobniku(System.Windows.Window okno)
        {
            this.okno = okno;

            string nazwaIkony = "choinka.ico";
            string nazwaAplikacji = Application.ProductName;
            System.Windows.Resources.StreamResourceInfo sri =
                System.Windows.Application.GetResourceStream(new Uri(@"/" + nazwaAplikacji + ";component/" + nazwaIkony,
                    UriKind.RelativeOrAbsolute));
            Icon icon = new Icon(sri.Stream);

            ContextMenuStrip menu = tworzMenu();

            notifyIcon = new();
            notifyIcon.Icon = icon;
            notifyIcon.Text = "Choinka 2021";
            notifyIcon.ContextMenuStrip = menu;
            notifyIcon.Visible = true;

            notifyIcon.DoubleClick += (s, e) =>
            {
                notifyIcon.BalloonTipTitle = "Choinka 2021";
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipText = "Wesołych Świąt!";
                notifyIcon.ShowBalloonTip(3000);
            };

            okno.MouseRightButtonDown += (s, e) =>
            {
                System.Windows.Point p = okno.PointToScreen(e.GetPosition(okno));
                menu.Show((int) p.X, (int) p.Y);
            };
        }

        private ContextMenuStrip tworzMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem ukryjToolStripMenuItem = new ToolStripMenuItem("Ukryj");
            ukryjToolStripMenuItem.Click += (s, e) => okno.Hide();
            menu.Items.Add(ukryjToolStripMenuItem);

            ToolStripMenuItem przywrocToolStripMenuItem = new ToolStripMenuItem("Przywróć");
            przywrocToolStripMenuItem.Click += (s, e) => okno.Show();
            menu.Items.Add(przywrocToolStripMenuItem);

            ToolStripMenuItem zamknijToolStripMenuItem = new ToolStripMenuItem("Zamknij");
            zamknijToolStripMenuItem.Click += (s, e) => okno.Close();
            menu.Items.Add(zamknijToolStripMenuItem);

            return menu;
        }

        public bool Widoczna
        {
            get => notifyIcon.Visible;
            set => notifyIcon.Visible = value;
        }

        public void Usun()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            notifyIcon = null;
        }

        public void Dispose()
        {
            Usun();
        }
    }
}
