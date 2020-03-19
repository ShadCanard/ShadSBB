using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadSBB.Infrastructure
{
    [Serializable]
    public class Settings
    {
        public static Settings Load()
        {
            return SerializerHelper.Load<Settings>(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "settings.dat"));
        }
    }
}
