using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace MalditosGoblins.Desktop.Goblin
{
    public class Goblin
    {
        public string name;
        [ContentSerializer]
        public Coloration color;
        [ContentSerializer]
        public Ocupation ocupation;
        [ContentSerializer]
        public List<Feature> features;
        [ContentSerializer]
        public List<Equipment> equipments;
        [ContentSerializer]
        public List<CriticTest> critics;

        public int max_health = 4;
        public int current_health;
        public int max_mana = 8;
        public int current_mana;

        public Goblin(string name)
        {
            this.name = name;
            this.level = 1;
            this.current_health = max_health;
            this.current_mana = max_mana;
        }
    }
}
