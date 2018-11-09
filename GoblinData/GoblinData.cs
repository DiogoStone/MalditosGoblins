using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GoblinData
{

    [Serializable]
    [XmlRoot("MalditoGoblin")]
    public class GoblinData
    {
        [XmlArray("Colorations")]
        [XmlArrayItem("Coloration")]
        public List<Coloration> Color { get; set; }

        [XmlArray("Ocupations")]
        [XmlArrayItem("Ocupation")]
        public List<Ocupation> Ocupations { get; set; }

        [XmlArray("Features")]
        [XmlArrayItem("Feature")]
        public List<Feature> Features { get; set; }

        [XmlArray("Anomalies")]
        [XmlArrayItem("anomaly")]
        public List<Anomaly> Anomalies { get; set; }

        [XmlArray("EquipmentSets")]
        [XmlArrayItem("EquipmentSet")]
        public List<EquipmentSet> EquipmentSets { get; set; }

        [XmlArray("Equipments")]
        [XmlArrayItem("Equipment")]
        public List<Equipment> Equipments { get; set; }

        [XmlArray("CriticTests")]
        [XmlArrayItem("CriticTest")]
        public List<CriticTest> Critics { get; set; }
    }

    [Serializable]
    public class Coloration
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
        [XmlAttribute("combat")]
        public int Combat { get; set; }
        [XmlAttribute("knowledge")]
        public int Knowledge { get; set; }
        [XmlAttribute("dexterity")]
        public int Dexterity { get; set; }
        [XmlAttribute("luck")]
        public int Luck { get; set; }
    }

    [Serializable]
    public class Ocupation
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
        [XmlAttribute("combat")]
        public int Combat { get; set; }
        [XmlAttribute("knowledge")]
        public int Knowledge { get; set; }
        [XmlAttribute("dexterity")]
        public int Dexterity { get; set; }
        [XmlAttribute("luck")]
        public int Luck { get; set; }
    }

    [Serializable]
    public class Feature
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
        [XmlAttribute("description")]
        public String Description { get; set; }
    }

    [Serializable]
    public class Anomaly
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
    }

    [Serializable]
    public class EquipmentSet
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
    }

    [Serializable]
    public class Equipment
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
        [XmlAttribute("description")]
        public Int32 Damage { get; set; }
        public Int32 Protection { get; set; }
        public bool Distance { get; set; }
    }

    [Serializable]
    public class CriticTest
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
    }
}
