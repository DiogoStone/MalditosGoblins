using System;

namespace GoblinData
{
    public class Coloration
    {
        public int id;
        public string name = null;
        public int[] color = { 0, 0, 0 };
        public int combat = 0;
        public int knowledge = 0;
        public int dextirity = 0;
        public int luck = 0;

        public int R
        {
            get { return this.color[0]; }
        }

        public int G
        {
            get { return this.color[1]; }
        }

        public int B
        {
            get { return this.color[2]; }
        }
    }
}