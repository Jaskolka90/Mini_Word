using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_v3
{
    public class Model
    {
        string text;
        bool reverse;
        bool vowels;
        bool consonants;
        bool digit;
        Font font;//V2
        Color color;//V2

        public Model()
        {
            this.font =  SystemFonts.DialogFont;
        }

        public delegate void TextChange(string oldText, string newText); //delegat (mówi jak ma wyglądać funkcja)
        public event TextChange onTextChange; //jak sie tworzy EVENT
        public delegate void FontChange(Font oldFond, Font newFond);//V2
        public event FontChange onFontChange;//V2
        public delegate void ColorChange(Color oldColor, Color newColor);//V2
        public event ColorChange onColorChange;//V2

        internal void TextChanged(string text)
        {
            this.text = text;
            TextOptions();
        }

        internal void FontChanged(Font newFond)//V2
        {
            Font _oldFond = this.font;
            this.font = newFond;

            if (onFontChange != null)
            {
                onFontChange(_oldFond, this.font);
            }
        }

        internal void ColorChanged(Color color)//V2
        {
            this.color = color;
            TextOptionsColor();
        }

        internal void TextOptions()
        {
            string _oldText = text;
            string _newText = text;

            if (reverse)
            {
                _newText = "";
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    _newText += text[i];
                }
                if (onTextChange != null)
                {
                    onTextChange(_oldText, _newText);
                }
            }
            if (vowels)
            {
                string vow = "aeiouyAEIOUY";
                _newText = new string(_newText.Where(c => !vow.Contains(c)).ToArray());
                if (onTextChange != null)
                {
                    onTextChange(_oldText, _newText);
                }
            }
            if (consonants)
            {
                string con = "bcdfghjklmnprstwzqvxBCDFGHJKLMNPRSTWZQVX";
                _newText = new string(_newText.Where(c => !con.Contains(c)).ToArray());
                if (onTextChange != null)
                {
                    onTextChange(_oldText, _newText);
                }
            }
            if (digit)
            {
                string dig = "1234567890";
                _newText = new string(_newText.Where(c => !dig.Contains(c)).ToArray());
                if (onTextChange != null)
                {
                    onTextChange(_oldText, _newText);
                }
            }
            if (!reverse && !vowels && !consonants && !digit)
                if (onTextChange != null)
                {
                    onTextChange(_oldText, _newText);
                }
        }


        internal void TextOptionsColor()//V2
        {
            Color _oldColor = color;
            Color _newColor = color;

            if (onColorChange != null)
            {
                onColorChange(_oldColor, _newColor);
            }
        }

        internal void ReverseOption(bool reverse)
        {
            this.reverse = reverse;
            TextOptions();
        }

        internal void DeleteVowels(bool vowels)
        {
            this.vowels = vowels;
            TextOptions();
        }

        internal void DeleteConsonants(bool consonants)
        {
            this.consonants = consonants;
            TextOptions();
        }

        internal void DeleteDigit(bool digit)
        {
            this.digit = digit;
            TextOptions();
        }
    }    
}
