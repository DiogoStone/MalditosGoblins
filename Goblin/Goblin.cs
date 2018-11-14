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
        public List<Skill> skills;

        public int level = 1;
        public int max_health = 4;
        public int current_health;
        public int max_mana = 8;
        public int current_mana;

        public int combat { get { return this.coloration.combat + this.ocupation.combat; } }
        public int knowledge { get { return this.coloration.knowledge + this.ocupation.knowledge; } }
        public int dextirity { get { return this.coloration.dextirity + this.ocupation.dextirity; } }
        public int luck { get { return this.coloration.luck + this.ocupation.luck; } }



        public Goblin()
        {
            this.name = "";
            this.current_health = max_health;
            this.current_mana = max_mana;
            this.coloration = GoblinLoader.Instance.GetRandomColoration();
            this.ocupation = GoblinLoader.Instance.GetRandomOcupation();
            this.equipments = GoblinLoader.Instance.GetRandomEquipmentsByType(this.ocupation.equipType);
            this.skills = new List<Skill>();
            foreach(int skillId in this.ocupation.skills)
            {
                this.skills.Add(GoblinLoader.Instance.GetSkillsById(skillId));
            }
        }

        public Color GetColor()
        {
            return this.coloration.color;
        }
    }
}
