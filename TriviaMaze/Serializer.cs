//Daniel Heffley
//Sam Gronhovd
//Kevin Reynolds
//Triva Maze / Final Project
//Last Modified: 12/9/12

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

        public void Serialize(string other_filename, SaveData other_save)
        {
            Stream stream = File.Open(other_filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, other_save);
            stream.Close();
        }

        public SaveData Deserialize(string other_filename)
        {
            SaveData save;
            Stream stream = File.Open(other_filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            save = (SaveData)bFormatter.Deserialize(stream);
            stream.Close();
            return save;

        }

    }
}
