using System;
using Microsoft.Xna.Framework.Content;

namespace GoblinData
{
    public class Equipment
    {
        public int id;
        public string name;
        [ContentSerializer(Optional = true)]
        public int protection = 0;
        [ContentSerializer(Optional = true)]
        public int damage = 0;
        [ContentSerializer(Optional = true)]
        public string description = null;
    }

    public class EquipmentSet
    {
        public int id;
        public EquipType type;
        public int[] equipments;
    }

    public enum EquipType {
        LIGHT, HEAVY, EXPLOSIVE, MAGIC
    }
}
