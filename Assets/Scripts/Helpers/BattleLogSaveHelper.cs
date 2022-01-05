using System.IO;
using UnityEngine;

namespace Helpers
{
    public static class BattleLogSaveHelper
    {
        private static int _index = 0;
        private  static string _basePath = "Assets/Battle";
        private  static string _baseFormat = ".txt";
        private static string Sufix 
        {
            get 
            {
                return  "(" + _index.ToString() + ")";
            }
        }
    
        public static void FileCreation(string battleLog)
        {
            string path = _basePath;
            string template = path + _baseFormat;
        
            FileInfo fi = new FileInfo(template);
            try
            {
                while (fi.Exists)
                {
                    _index++;
                    fi = new FileInfo(path + Sufix + _baseFormat);
                }

                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine(battleLog);
                }
            }
            catch
            {
                Debug.Log("Save Error");
            }
        }
    }
}
