using System;
using Microsoft.Xna.Framework.Content;

namespace MalditosGoblins.Desktop.Goblin
{
    public interface IHasStats
    {
        [ContentSerializer]
        int combat { get; set; };

        [ContentSerializer]
        int knowledge { get; set; };

        [ContentSerializer]
        int dexterity { get; set; };

        [ContentSerializer]
        int luck { get; set; };
    }
}
