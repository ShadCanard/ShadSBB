using ShadSBB.Infrastructure;
using ShadSBB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadSBB.Repositories
{


    public class WebAppRepository
    {
        private List<WebApp> _WebAppList;
        private string Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "data.dat");
        public List<WebApp> List()
        {
            if (_WebAppList == null) _WebAppList = SerializerHelper.Load<List<WebApp>>(Path);
            return _WebAppList;
        }

        public WebApp Get(int ID)
        {
            return _WebAppList.FirstOrDefault(WebApp => WebApp.ID == ID);
        }

        public void Edit(WebApp WebApp)
        {
            WebApp toEdit = _WebAppList.FirstOrDefault(i => i.ID == WebApp.ID);
            if (toEdit != null)
            {
                toEdit.ID = WebApp.ID;
                toEdit.Name = WebApp.Name;
                toEdit.URL = WebApp.URL;
                toEdit.AccentColor = WebApp.AccentColor;
            }
            else
                throw new Exception("No WebApp with this ID exists !");
        }

        public void Delete(WebApp WebApp)
        {
            Delete(WebApp.ID);
        }

        public void Delete(int ID)
        {
            WebApp toDelete = _WebAppList.FirstOrDefault(i => i.ID == ID);
            if (toDelete == null) throw new Exception("No WebApp with this ID exists !");
            if (toDelete != null) _WebAppList.Remove(toDelete);
        }

        public void Add(WebApp WebApp)
        {
            if (_WebAppList.FirstOrDefault(i => i.ID == WebApp.ID) == null)
            {
                int newID = 0;
                if (_WebAppList.Count > 0)
                    newID = _WebAppList.OrderBy(i => i.ID).Last().ID;
                newID++;
                WebApp.ID = newID;
                _WebAppList.Add(WebApp);
            }
            else
            {
                throw new Exception("A WebApp with this ID already exists !");
            }
        }
    }

}
