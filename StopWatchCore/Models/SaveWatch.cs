using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    public static class SaveWatch
    {
        private static string _path = @"C:\tmp\" + Environment.UserName + "\\Saves\\SaveWatches.txt";
        private static string _dir = @"C:\tmp\" + Environment.UserName + "\\Saves";

        public static void Save(StopWatchItems saveItem)
        {
            if (!Directory.Exists(_dir))
                Directory.CreateDirectory(_dir);

            var saveString = string.Join(";", saveItem.RoundTime, saveItem.TimeStamp);
            var lstSave = new List<string> { saveString };

            using (var sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(saveString);
            }
        }
        public static bool IsSaved(StopWatchItems saveItem)
        {
            if (saveItem != null && File.Exists(_path))
            {
                using (var fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read))
                using (var sr = new StreamReader(fileStream))
                {
                    var compareString = string.Join(";", saveItem.RoundTime, saveItem.TimeStamp);
                    string[] saveString = new string[] { sr.ReadToEnd() };
                    var lines = saveString.Select(x => x.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
                    foreach (var line in lines)
                    {
                        foreach (var l in line)
                        {
                            if (l.Equals(compareString))
                                return true;
                        }
                    }
                }
            }

            return false;
        }
        public static void Delete(StopWatchItems deleteItem)
        {
            if (File.Exists(_path))
            {
                var lstDelete = new List<string>();
                var lstSave = ParseFile();
                lstDelete.AddRange(lstSave);

                var delete = string.Join(";", deleteItem.RoundTime, deleteItem.TimeStamp);

                var deletedList = lstDelete.Where(x => x.Equals(delete)).ToList();
                File.WriteAllLines(_path, deletedList.ToArray());
            }
            else
                throw new ArgumentException("keine SaveFile vorhanden");
        }

        private static List<string> ParseFile()
        {
            if (File.Exists(_path))
            {
                var fileStream = File.Open(_path, FileMode.Open, FileAccess.ReadWrite);
                using (var reader = new StreamReader(fileStream))
                {
                    var lstSave = new List<string>();
                    var str = reader.ReadToEnd().TrimEnd();
                    var lines = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    foreach (var l in lines)
                    {
                        lstSave.Add(l);
                    }

                    return lstSave;
                }
            }
            else
                throw new ArgumentNullException("File not found");

        }

        public static List<StopWatchItems> LoadSaveGames()
        {
            var lstSave = ParseFile();

            if (lstSave.Count > 0)
            {
                var lstStopWatchItems = new List<StopWatchItems>();
                foreach (var item in lstSave)
                {
                    var items = item.Split(';');
                    var ret = new StopWatchItems
                    {
                        RoundTime = TimeSpan.Parse(items[0]),
                        TimeStamp = DateTime.Parse(items[1])
                    };
                    lstStopWatchItems.Add(ret);
                }
                return lstStopWatchItems;
            }
            else
                throw new ArgumentException("keine StopWatchItems");
        }

    }
}
