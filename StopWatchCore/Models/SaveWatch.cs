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

                foreach (var item in lstDelete)
                {
                    if (string.Equals(item, delete))
                    {
                        lstDelete.Remove(item);
                    }
                }
                File.WriteAllLines(_path, lstDelete.ToArray());
            }
            else
                throw new ArgumentException("keine SaveFile vorhanden");
        }

        private static List<string> ParseFile()
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

        public static List<StopWatchItems> LoadSaveGames()
        {
            if (File.Exists(_path) && !string.IsNullOrWhiteSpace(File.ReadAllText(_path)))
            {
                // var file = File.ReadAllLines(_path);
                using (var sr = new StreamReader(_path))
                {
                    string[] file = new string[] { sr.ReadToEnd().Trim() };

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
