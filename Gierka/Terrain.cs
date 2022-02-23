using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public enum typeOfTerrain { plane, water, mountain, field }

    [Serializable]
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
                return true;
            return false;
        }

    }
    [Serializable]
    public class Mountain : Terrain
    {
        public Mountain()
        {
            Image = $"/GUI;component/Resources/mountain.png";
            Type = typeOfTerrain.mountain;
        }
        public override string ToString()
        {
            return "You can build Mine here";
        }
    }

    [Serializable]
    public class Water : Terrain
    {
        public Water()
        {
            Image = $"/GUI;component/Resources/water.png";
            Type = typeOfTerrain.water;
        }
        public override string ToString()
        {
            return "You can build Port here";
        }
    }
    [Serializable]
    public class Plane : Terrain
    {
        public Plane()
        {
            Image = "";
            Type = typeOfTerrain.plane;
        }
    }

    [Serializable]
    public class Field : Terrain
    {
        public Field()
        {
            Image = $"/GUI;component/Resources/field.png";
            Type = typeOfTerrain.field;
        }
        public override string ToString()
        {
            return "You can build Farm here";
        }
    }
}
