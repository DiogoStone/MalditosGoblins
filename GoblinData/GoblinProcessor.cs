using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

using TInput = System.String;
using TOutput = System.String;

namespace GoblinData
{
    [ContentProcessor(DisplayName = "Goblin Processor")]
    class GoblinProcessor : ContentProcessor<TInput, TOutput>
    {
        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            return default(TOutput);
        }
    }
}

