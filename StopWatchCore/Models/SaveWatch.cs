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
        private static string _path = @"C:\Users\" + Environment.UserName + "\\Documents\\Saves\\SaveWatches.txt";

        public static void Save(StopWatchItems saveItem)
        {
            // StreamWriter _file = new StreamWriter(path);         
            var saveString = string.Join(";", saveItem.RoundTime, saveItem.TimeStamp);
            var lstSave = new List<string> { saveString };
            using (var fileStream = new FileStream(_path, FileMode.Append, FileAccess.Write))
            using (var sw = new StreamWriter(fileStream))
            {
                sw.Write(Environment.NewLine + saveString);

            }
        }
        public static bool IsSaved(StopWatchItems saveItem)
        {
            if (saveItem != null)
            {
                using (var fileStream = new FileStream(_path, FileMode.Open, FileAccess.ReadWrite))
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
                var SaveString = "";
                using (var sr = new StreamReader(_path))
                {
                    SaveString = sr.ReadToEnd();

                }
                using (var fileStream = new FileStream(_path, FileMode.Open, FileAccess.ReadWrite))
                using (var sw = new StreamWriter(fileStream))
                {
                    var delete = string.Join(";", deleteItem.RoundTime, deleteItem.TimeStamp);
                    if (SaveString.Equals(delete))
                    {
                        SaveString.Replace(delete, "");
                        sw.WriteLine(SaveString);
                    }
                }
            }
            else
                throw new ArgumentException("keine SaveFile vorhanden");
        }

        public static List<StopWatchItems> LoadSaveGames()
        {
            if (File.Exists(_path))
            {
                // var file = File.ReadAllLines(_path);
                using (var sr = new StreamReader(_path))
                {
                    string[] file = new string[] { sr.ReadToEnd() };

                    var lines = file.Select(x => x.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
                    var list = new List<StopWatchItems>();
                    if (!string.IsNullOrWhiteSpace(file[0]))
                    {
                        foreach (var line in lines)
                        {
                            foreach (var item in line.Select(y => y.Split(new string[] { ";" }, StringSplitOptions.None)))
                            {
                                var ret = new StopWatchItems
                                {
                                    RoundTime = TimeSpan.Parse(item[0]),
                                    TimeStamp = DateTime.Parse(item[1])
                                };
                                list.Add(ret);
                            }
                        }
                        return list;
                    }
                    throw new ArgumentException("File ist leer");
                }

            }
            return null;
        }
    }
}
