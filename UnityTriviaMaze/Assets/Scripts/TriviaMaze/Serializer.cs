using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TriviaMaze
{
    class Serializer
    {
        public Serializer() { }

        public void Serialize(string filename, SaveData save)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, save);
            stream.Close();
        }

        public SaveData Deserialize(string filename)
        {
            SaveData save;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            save = (SaveData)bFormatter.Deserialize(stream);
            stream.Close();
            return save;

        }

    }
}
