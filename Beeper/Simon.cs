using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beeper
{
    public class Simon
    {
        Node root;
        Dictionary<string, string> morseByMeaning;

        public Simon()
        {
            root = new Node();

            Learn(morse: ".-", meaning: "a");
            Learn(morse: "-...", meaning: "b");
            Learn(morse: "-.-.", meaning: "c");
            Learn(morse: "-..", meaning: "d");
            Learn(morse: ".", meaning: "e");
            Learn(morse: "..-.", meaning: "f");
            Learn(morse: "--.", meaning: "g");
            Learn(morse: "....", meaning: "h");
            Learn(morse: "..", meaning: "i");
            Learn(morse: ".---", meaning: "j");
            Learn(morse: "-.-", meaning: "k");
            Learn(morse: ".-..", meaning: "l");
            Learn(morse: "--", meaning: "m");
            Learn(morse: "-.", meaning: "n");
            Learn(morse: "---", meaning: "o");
            Learn(morse: ".--.", meaning: "p");
            Learn(morse: "--.-", meaning: "q");
            Learn(morse: ".-.", meaning: "r");
            Learn(morse: "...", meaning: "s");
            Learn(morse: "-", meaning: "t");
            Learn(morse: "..-", meaning: "u");
            Learn(morse: "...-", meaning: "v");
            Learn(morse: ".--", meaning: "w");
            Learn(morse: "-..-", meaning: "x");
            Learn(morse: "-.--", meaning: "y");
            Learn(morse: "--..", meaning: "z");
            Learn(morse: ".----", meaning: "1");
            Learn(morse: "..---", meaning: "2");
            Learn(morse: "...--", meaning: "3");
            Learn(morse: "....-", meaning: "4");
            Learn(morse: ".....", meaning: "5");
            Learn(morse: "-....", meaning: "6");
            Learn(morse: "--...", meaning: "7");
            Learn(morse: "---..", meaning: "8");
            Learn(morse: "----.", meaning: "9");
            Learn(morse: "-----", meaning: "0");
            Learn(morse: ".-.-.-", meaning: ".");
            Learn(morse: "--..--", meaning: ",");
            Learn(morse: "..--..", meaning: "?");
            Learn(morse: ".----.", meaning: "'");
            Learn(morse: "-.-.--", meaning: "!");
            Learn(morse: "-..-.", meaning: "/");
            Learn(morse: "-.--.", meaning: "(");
            Learn(morse: "-.--.-", meaning: ")");
            Learn(morse: ".-...", meaning: "&");
            Learn(morse: "---...", meaning: ":");
            Learn(morse: "-.-.-.", meaning: ";");
            Learn(morse: "-...-", meaning: "=");
            Learn(morse: ".-.-.", meaning: "+");
            Learn(morse: "..--.-", meaning: "_");
            Learn(morse: ".-..-.", meaning: "'\"");
            Learn(morse: "...-..-", meaning: "$");
            Learn(morse: ".--.-.", meaning: "@");

            morseByMeaning = root.GeneratePermutations();
        }


        public void Learn(string morse, string meaning)
        {
            var current = root;
            foreach (var c in morse)
            {
                switch (c)
                {
                    case '.':
                    case '·':
                        current = current.AddDit();
                        break;
                    case '-':
                    case '_':
                        current = current.AddDah();
                        break;
                }
            }
            current.Text = meaning;
        }

        public string Encode(string input)
        {
            var output = new StringBuilder();
            foreach (var c in input)
            {
                string morse;
                if (morseByMeaning.TryGetValue(c.ToString(), out morse))
                {
                    output.Append(morse);
                    output.Append(" ");
                }
                else
                {
                    output.Append("   ");
                }
            }
            return output.ToString();
        }

        public string Decode(string input)
        {
            var output = new StringBuilder();
            var current = root;
            var delayBeat = 0;
            var spaceOutputed = false;
            foreach (var c in input)
            {
                switch (c)
                {
                    case '.':
                    case '·':
                        current = current.Dit;
                        delayBeat = 0;
                        spaceOutputed = false;
                        break;
                    case '-':
                    case '_':
                        current = current.Dah;
                        delayBeat = 0;
                        spaceOutputed = false;
                        break;
                    default:
                        delayBeat++;
                        if (current.Text != null)
                        {
                            output.Append(current.Text);
                        }
                        else if (!spaceOutputed &&
                            delayBeat > 3)
                        {
                            output.Append(" ");
                            spaceOutputed = true;
                        }
                        current = root;
                        break;
                }
            }
            if (current.Text != null)
            {
                output.Append(current.Text);
            }
            return output.ToString();
        }
    }

}
