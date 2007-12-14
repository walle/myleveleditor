using System;
using System.Collections.Generic;
using System.Text;

namespace MapAPI
{
    public class MapLayer
    {
        public List<MapEntity> entites = new List<MapEntity>();

        public MapEntity this[int index]
        {
            get
            {
                if (index < entites.Count)
                {
                    return entites[index];
                }
                else if (entites.Count == 0)
                {
                    throw new Exception("Entity list is empty.");
                }
                else
                {
                    return entites[0];
                }
            }
            set
            {
                if (index < entites.Count)
                {
                    entites[index] = value;
                }
                else if (entites.Count == 0)
                {
                    entites.Add(value);
                    throw new Exception("Entity list is empty, value added to the list.");
                }
            }
        }
    }
}
