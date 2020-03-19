using CefSharp;
using CefSharp.Wpf;
using MahApps.Metro.Controls;
using ShadSBB.Infrastructure;
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
using System.Windows.Shapes;

namespace ShadSBB.Windows
{
    /// <summary>
    /// Logique d'interaction pour SBBWindow.xaml
    /// </summary>
    public partial class SBBWindow : MetroWindow
    {
        public SBBWindow()
        {
            InitializeComponent();
        }

        public SBBWindow(string url)
        {
            InitializeComponent();
            Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
            {
                return;
            }
            Browser.Address = url;
            Browser.DisplayHandler = new SBBDisplayHandler();
        }

        internal void SetFullscreen(bool fullscreen)
        {
            Dispatcher.Invoke(new Action(delegate ()
            {
                if (fullscreen)
                {
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                    ResizeMode = ResizeMode.NoResize;
                    UseNoneWindowStyle = true;
                }
                else
                {

                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.ThreeDBorderWindow;
                    ResizeMode = ResizeMode.CanResizeWithGrip;
                    UseNoneWindowStyle = false;
                }
            }));
        }

        private void OnClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Instance.GetInstance().ShutdownApp();
        }

        internal void SetImmersiveScreen()
        {
            UseNoneWindowStyle = true;
            UseNoneWindowStyle = false;
        }
    }
}
