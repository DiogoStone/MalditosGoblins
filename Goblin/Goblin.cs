using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GoblinData;

namespace MalditosGoblins.Desktop.Goblin
{
    public class Goblin
    {
        public string name;
        public Coloration coloration;
        public Ocupation ocupation;
        public List<Feature> features;
        public List<Equipment> equipments;

        public int level = 1;
        public int max_health = 4;
        public int current_health;
        public int max_mana = 8;
        public int current_mana;

        public Goblin(string name)
        {
            this.name = name;
            this.current_health = max_health;
            this.current_mana = max_mana;
        }

        public static Goblin GenerateRandomGoblin()
        {
            Goblin goblin = new Goblin("");

            return goblin;
        }

        public Color GetColor()
        {
            return this.coloration.color;
        }
    }
}
