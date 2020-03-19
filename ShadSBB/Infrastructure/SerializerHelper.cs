using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ShadSBB.Infrastructure
{
    public class SerializerHelper
    {
        public static T Load<T>(string Path)
        {
            if (File.Exists(Path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        return (T)formatter.Deserialize(fs);
                    }
                    catch (Exception)
                    {
                        return default;
                    }
                }
            }
            return default;
        }

        public static void Save(object ToSave, string FilePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FilePath))) Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, ToSave);
            }
        }
    }
}
