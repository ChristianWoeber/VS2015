using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    public static class SaveWatch
    {
        const string path = @"C:\Users\Kathi\Documents\Saves\SaveWatches.txt";

        public static void Save(StopWatchItems saveItem)
        {
            StreamWriter _file = new StreamWriter(path);
            var saveString = string.Join(";", saveItem.Id.ToString(), saveItem.RoundTime, saveItem.TimeStamp);
            _file.WriteLine(saveString);
        }

        public static void Delete(StopWatchItems deleteItem)
        {
            if (Directory.Exists(path))
            {
                StreamReader _file = new StreamReader(path);
                var SaveString=_file.ReadToEnd();
                var delete = string.Join(";", deleteItem.Id, deleteItem.RoundTime, deleteItem.TimeStamp);

                if (SaveString.Contains(delete))
                    SaveString.Replace(delete, "");
            }
            throw new ArgumentException("keine SaveFile vorhanden");
        }

        public static StopWatchItems LoadSaveGames()
        {
            if (Directory.Exists(path))
            {
                StreamReader _file = new StreamReader(path);
                var saveString = _file.ReadToEnd();
                saveString.Split(';');

                var id = saveString[0];
                var roundTime = saveString[1];
                var timestamp = saveString[2]; ;

                return new StopWatchItems
                {
                    Id = (int)id,
                    RoundTime = TimeSpan.Parse(roundTime.ToString()),
                    TimeStamp = DateTime.Parse(timestamp.ToString())
                };
            }
            return null;
        }
    }
}
