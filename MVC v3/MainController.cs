using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_v3
{
    class MainController
    {
        private MainView mainView;
        private Model model;

        public MainController(MainView mainView, Model model)
        {
            this.mainView = mainView;
            this.model = model;
            this.model.onTextChange += Model_onTextChange;//podpiecie handlera do EVENTU(może być kilka)
            this.model.onFontChange += Model_onFontChange;//V2
            this.model.onColorChange += Model_onColorChange;//V2
            mainView.Init(this);
        }

        private void Model_onTextChange(string oldText, string newText)
        {
            this.mainView.TextChange(newText);
        }

        private void Model_onFontChange(Font oldFont, Font newFont)//V2
        {
            this.mainView.FontChange(oldFont, newFont);
        }

        private void Model_onColorChange(Color oldColor, Color newColor)//V2
        {
            this.mainView.ColorChange(newColor);
        }

        internal void Run()
        {
            Application.Run(this.mainView);
        }

        internal void TextChanged(string text)
        {
            this.model.TextChanged(text);
        }

        internal void ReverseOption(bool reverse)
        {
            this.model.ReverseOption(reverse);
        }

        internal void DeleteVowels(bool vowels)
        {
            this.model.DeleteVowels(vowels);
        }

        internal void DeleteConsonants(bool consonants)
        {
            this.model.DeleteConsonants(consonants);
        }

        internal void DeleteDigit(bool digit)
        {
            this.model.DeleteDigit(digit);
        }

        internal void SetFont(Font font)//V2
        {
            this.model.FontChanged(font);
        }

        internal void SetColor(Color color)//V2
        {
            this.model.ColorChanged(color);
        }
    }
}
