using System;
using System.Collections.Generic;
using System.Text;

using MapAPI;

namespace MyLeveleditor
{
    class ToolboxToolHand : ToolboxTool
    {
        public ToolboxToolHand()
        {

        }

        public void Execute(MapForm mapForm, MapEntity entity)
        {
            mapForm.AutoScrollPosition = entity.Location;
        }
    }
}