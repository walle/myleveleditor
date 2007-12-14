using System;
using System.Collections.Generic;
using System.Text;

namespace MapAPI
{
    public static class FileTranslatorManager
    {
        private static List<FileTranslator> fileTranslators;

        public static void Export(string filename, MapData data, bool showDialog)
        {
            foreach (FileTranslator ft in fileTranslators)
            {
                if (filename.EndsWith(ft.Extension()))
                {
                    ft.Export(filename, data, showDialog);
                    return;
                }
            }

            throw new Exception("No FileTranslator found for the specified file.");
        }

        public static void Import(string filename, MapData data, bool showDialog)
        {
            foreach (FileTranslator ft in fileTranslators)
            {
                if (filename.EndsWith(ft.Extension()))
                {
                    ft.Import(filename, data, showDialog);
                    return;
                }
            }

            throw new Exception("No FileTranslator found for the specified file.");
        }

        public static void RegisterTranslator(FileTranslator ft)
        {
            foreach (FileTranslator t in fileTranslators)
            {
                if (ft.Extension() == t.Extension())
                {
                    throw new Exception("Name clash, previusly entered FileTranslator with extension: " + t.Extension() + "."); 
                }
            }

            fileTranslators.Add(ft);
        }

        public static string BuildFileFilter()
        {
            string s = "";
            foreach (FileTranslator t in mFileTranslators)
            {
                s += t.information();
                s += "|*.";
                s += t.extension();
                s += "|";
            }
            s += "All Files (*.*)|*.*";
            return s;

        }
    }
}
