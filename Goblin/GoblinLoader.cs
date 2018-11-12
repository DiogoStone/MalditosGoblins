using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using GoblinData;

namespace MalditosGoblins.Desktop.Goblin
{
    public sealed class GoblinLoader
    {
        static GoblinLoader instance = null;
        static readonly object padlock = new object();

        GoblinLoader()
        {
        }

        public static GoblinLoader Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GoblinLoader();
                    }
                    return instance;
                }
            }
        }
        private Random rnd = new Random();
        public Coloration[] colorations;
        public Ocupation[] ocupations;
        public EquipmentSet[] equipmentSets;
        public Equipment[] equipments;
        public Feature[] features;
        public Skill[] skills;
        public Anomaly[] anomalies;


        public void Load(ContentManager contentManager) {
            colorations = contentManager.Load<Coloration[]>("Xml\\Colorations");
            ocupations = contentManager.Load<Ocupation[]>("Xml\\Ocupations");
            equipmentSets = contentManager.Load<EquipmentSet[]>("Xml\\EquipmentSets");
            equipments = contentManager.Load<Equipment[]>("Xml\\Equipments");
            features = contentManager.Load<Feature[]>("Xml\\Features");
            skills = contentManager.Load<Skill[]>("Xml\\Skills");
            anomalies = contentManager.Load<Anomaly[]>("Xml\\Anomalies");
        }

        public List<Equipment> GetRandomEquipmentsByType(EquipType equipType) {
            List<EquipmentSet> equipsets = this.equipmentSets.Where(t => t.type == equipType).ToList<EquipmentSet>();
            // get random EquipmentSet
            int index = rnd.Next(0, equipsets.Count);
            //get Equipment list
            List<Equipment> equip = new List<Equipment>();
            foreach(int id in equipsets[index].equipments) {
                equip.Add(Array.Find<Equipment>(this.equipments, eq => eq.id == id));
            }
            return equip;
        }

        public Ocupation GetRandomOcupation()
        {
            int index = rnd.Next(0, this.ocupations.Length);
            return this.ocupations[index];
        }

        public Coloration GetRandomColoration()
        {
            int index = rnd.Next(0, this.colorations.Length);
            return this.colorations[index];
        }
    }
}
