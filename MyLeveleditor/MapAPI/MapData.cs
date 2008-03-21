using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MapAPI
{
    public class MapData
    {
        private string name = "undefined";
        private string version = "undefined";
        private string author = "undefined";
        private string backgroundImage = "undefined";
        private string backgroundMusic = "undefined";
        private string width = "undefined";
        private string height = "undefined";
        public List<MapLayer> layers = new List<MapLayer>();

        [CategoryAttribute("Mapdata"), DescriptionAttribute("The name of the map")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [CategoryAttribute("Mapdata"), DescriptionAttribute("The version of the map")]
        public string Version
        {
            get { return this.version; }
            set { this.version = value; }
        }

        [CategoryAttribute("Mapdata"), DescriptionAttribute("The name of the author of the map")]
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        [CategoryAttribute("Mapdata"), DescriptionAttribute("The filenamename of the background image file")]
        public string BackgroundImage
        {
            get { return this.backgroundImage; }
            set { this.backgroundImage = value; }
        }

        [CategoryAttribute("Mapdata"), DescriptionAttribute("The filenamename of the background music file")]
        public string BackgroundMusic
        {
            get { return this.backgroundMusic; }
            set { this.backgroundMusic = value; }
        }

        [CategoryAttribute("Mapdata"), DescriptionAttribute("The width of the map in pixels")]
        public string Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        [CategoryAttribute("Mapdata"), DescriptionAttribute("The height of the map in pixels")]
        public string Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

	    public MapLayer this[int index]
	    {
		    get 
            {
                if (index < layers.Count)
                {
                    return layers[index];
                }
                else if (layers.Count == 0)
                {
                    throw new Exception("Layer list is empty.");
                }
                else
                {
                    return layers[0];
                }
            }
		    set 
            {
                if (index < layers.Count)
                {
                    layers[index] = value;
                }
                else if (layers.Count == 0)
                {
                    layers.Add(value);
                    throw new Exception("Layer list is empty, value added to the list.");
                }
            }
	    }
    }
}
