using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beeper
{
    class Node
    {
        public Node DitChildOf { get; protected set; }
        public Node DahChildOf { get; protected set; }

        public Node Dit { get; protected set; }
        public Node Dah { get; protected set; }

        public Node AddDit()
        {
            if (Dit == null)
            {
                Dit = new Node() { DitChildOf = this }; 
            }

            return Dit;
        }

        public Node AddDah()
        {
            if (Dah == null)
            {
                Dah = new Node() { DahChildOf = this };
            }

            return Dah;
        }

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text != null)
                {
                    throw new Exception("Unable to set text to '" + value + "' as it's already set to '" + text + "'");
                }
                text = value;
            }
        }

        public Dictionary<string, string> GeneratePermutations()
        {
            var morseByCharacter = new Dictionary<string, string>();

            Populate(morseByCharacter);

            return morseByCharacter;
        }

        protected void Populate(Dictionary<string, string> morseByMeaning)
        {
            if (Text != null)
            {
                var morse = new StringBuilder();

                var current = this;

                while (true)
                {
                    if (current.DitChildOf != null)
                    {
                        morse.Insert(0, ".");
                        current = current.DitChildOf;
                        continue;
                    }

                    if (current.DahChildOf != null)
                    {
                        morse.Insert(0, "-");
                        current = current.DahChildOf;
                        continue;
                    }

                    break;
                }
                morseByMeaning[Text] = morse.ToString();
            }

            if (Dit != null)
            {
                Dit.Populate(morseByMeaning);
            }
            if (Dah != null)
            {
                Dah.Populate(morseByMeaning);
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
