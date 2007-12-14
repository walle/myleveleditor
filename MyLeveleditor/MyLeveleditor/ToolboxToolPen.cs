using System;
using System.Collections.Generic;
using System.Text;

using MapAPI;

namespace MyLeveleditor
{
    class ToolboxToolPen : ToolboxTool
    {
        public ToolboxToolPen()
        {

        }

        public void Execute(MapForm mapForm, MapEntity entity)
        {
            mapForm.AddEntity(entity);
        }
    }
}
