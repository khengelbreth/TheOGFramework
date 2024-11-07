using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FramworkCheck.Div
{
    public class GameConfigReader
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<CreatureConfigReader> Creatures { get; set; }

        public GameConfigReader()
        {
            Creatures = new List<CreatureConfigReader>();
        }

        public void LoadFromXml(string filePath)
        {
            XDocument xDocument = XDocument.Load(filePath);

            var worldElement = xDocument.Element("Configuration")?.Element("World");
            if (worldElement != null)
            {
                MaxX = (int)worldElement.Element("MaxX");
                MaxY = (int)worldElement.Element("MaxY");
            }

            var creatureElements = xDocument.Element("Configuration")?.Elements("Creature");
            foreach (var creature in creatureElements)
            {
                var creatureConfig = new CreatureConfigReader
                {
                    Name = (string)creature.Element("Name"),
                    HitPoints = (int)creature.Element("HitPoints")
                };
                Creatures.Add(creatureConfig);
            }
        }
    }
}
