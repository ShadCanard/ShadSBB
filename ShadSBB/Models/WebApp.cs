using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadSBB.Models
{
    [Serializable]
    public class WebApp
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AccentColor { get; set; }
        public string URL { get; set; }
    }
}
