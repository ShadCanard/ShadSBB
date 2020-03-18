using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ShadSBB.Infrastructure
{
    public class Instance
    {
        private static Instance _instance;
        private List<UserControl> _fragments;
        private List<Window> _windows;

        public static Instance GetInstance()
        {
            if (_instance == null) _instance = new Instance();
            return _instance;
        }

        public T GetWindow<T>(params object[] arguments) where T : Window
        {
            if (_windows == null) _windows = new List<Window>();
            if (arguments != null && arguments.Length > 0)
            {
                T toDelete = (T)_windows.FirstOrDefault(w => w.GetType() == typeof(T));
                if (toDelete != null) _windows.Remove(toDelete);
            }
            if (_windows.FirstOrDefault(w => w.GetType() == typeof(T)) == null) _windows.Add((T)Activator.CreateInstance(typeof(T),arguments));
            return (T)_windows.First(w => w.GetType() == typeof(T));
        }

        public T GetFragment<T>() where T : UserControl
        {
            if (_fragments == null) _fragments = new List<UserControl>();
            if (_fragments.FirstOrDefault(f => f.GetType() == typeof(T)) == null) _fragments.Add(Activator.CreateInstance<T>());
            return (T)_fragments.First(f => f.GetType() == typeof(T));
        }

        internal void ShutdownApp()
        {
            _windows = null;
            _fragments = null;
            App.Current.Shutdown();
        }
    }
}
