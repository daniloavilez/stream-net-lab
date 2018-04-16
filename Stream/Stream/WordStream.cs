using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream
{
    public class WordStream : IStream
    {
        private string word = "AhJeFEKlMaKalicI";

        public char getNext()
        {
            char carac = word[0];
            word = word.Remove(0, 1);
            return carac;
        }

        public bool hasNext()
        {
            return word.Length > 0 ? true : false;
        }
    }
}
