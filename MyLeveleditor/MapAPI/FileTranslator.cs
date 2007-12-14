using System;
using System.Collections.Generic;
using System.Text;

namespace MapAPI
{
    public interface FileTranslator
    {
        void Export(string filename, MapData data, bool showDialog);
        void Import(string filename, MapData data, bool showDialog);
        string Extension();
        string Information();
    }
}
