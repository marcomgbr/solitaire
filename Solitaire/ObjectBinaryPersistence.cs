using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    class ObjectBinaryPersistence<T>
    {
        readonly string filePath;
        public T PersistentObject { get; set; }

        public ObjectBinaryPersistence(string filePath)
        {
            this.filePath = filePath;
        }

        public T Load()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                this.PersistentObject = (T)formatter.Deserialize(fs);
            }
            fs.Close();

            return this.PersistentObject;
        }

        public void Save()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, this.PersistentObject);
            fs.Close();
        }
    }
}
