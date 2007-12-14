using System;
using System.Collections.Generic;
using System.Text;

using MapAPI;

namespace MyLeveleditor
{
    interface ToolboxTool
    {
        void Execute(MapForm mapForm, MapEntity entity);
    }
}
