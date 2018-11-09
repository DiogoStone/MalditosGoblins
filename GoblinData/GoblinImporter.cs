using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

using TImport = System.String;

namespace GoblinData
{
    [ContentImporter(".xml", DisplayName = "Goblin Data Importer", DefaultProcessor = "GoblinProcessor")]
    public class GoblinImporter : ContentImporter<TImport>
    {
        public override TImport Import(string filename, ContentImporterContext context)
        {
            context.Logger.LogMessage("Importing XML file: {0}", filename);
            using (var streamReader = new StreamReader(filename)) {
                var deserializer = new XmlSerializer((GoblinData));
                return (GoblinData)deserializer.Deserialize(streamReader);
            }
            return default(TImport);
        }
    }
}

