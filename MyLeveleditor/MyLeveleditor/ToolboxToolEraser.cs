using System;
using System.Collections.Generic;
using System.Text;

using MapAPI;

namespace MyLeveleditor
{
    class ToolboxToolEraser : ToolboxTool
    {
        public ToolboxToolEraser()
        {

        }

        public void Execute(MapForm mapForm, MapEntity entity)
        {
            mapForm.RemoveEntity(entity.Location);
        }
    }
}
