using System;

namespace GoblinData
{
    public class Equipment
    {
        public int id;
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
