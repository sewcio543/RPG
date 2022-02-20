using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public enum typeOfTerrain { plane, water, mountain }
    public class Terrain
    {
        string image;
        Building building;
        typeOfTerrain type;
        public string Image { get => image; set => image = value; }
        public Building Building { get => building; set => building = value; }
        public typeOfTerrain Type { get => type; set => type = value; }

        public bool build(Building building)
        {
            if (building.Terrain == Type)
            {
                Building = building;
                return true;
            }
            return false;
        }

    }
    public class Mountain : Terrain
    {
        public Mountain()
        {
            Image = $"/GUI;component/Resources/mountain.png";
            Type = typeOfTerrain.mountain;
        }
    }

    public class Water : Terrain
    {
        public Water()
        {
            Image = $"/GUI;component/Resources/water.png";
            Type = typeOfTerrain.water;
        }
    }
    public class Plane : Terrain
    {
        public Plane()
        {
            Image = "";
            Type = typeOfTerrain.plane;
        }
    }
}
