using ShadSBB.Infrastructure;
using ShadSBB.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShadSBB
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool SBBLaunched;

        protected override void OnStartup(StartupEventArgs e)
        {
            if(e.Args != null && e.Args.Length > 0)
            {
                SBBLaunched = true;
                string url = e.Args[0];
                Instance.GetInstance().GetWindow<SBBWindow>(url).Show();
            }
            else
            {
                base.OnStartup(e);
            }
        }
    }
}
