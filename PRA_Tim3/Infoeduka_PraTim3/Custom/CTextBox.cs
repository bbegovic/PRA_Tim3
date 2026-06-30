using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoeduka_PraTim3.Custom
{
    public class CTextBox:TextBox
    {
        //Varijable
        private string placeholderText = "Unesi tekst...";
        private Color placeholderColor;
        private Color normalTextColor = Color.Black;
        private bool isPlaceholder = true;
        private bool isPassword = false;

        public CTextBox()
        {
            placeholderColor = this.ForeColor;
            SetPlaceHolder();

            this.Enter += txt_Enter;
            this.Leave += txt_Leave;
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                SetPlaceHolder();
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            if (isPlaceholder)
            {
                this.Text = "";
                this.ForeColor = normalTextColor;
                this.UseSystemPasswordChar = IsPassword;
                isPlaceholder = false;
            }
        }



        //Pomoćna metoda
        private void SetPlaceHolder()
        {
            if (!this.Focused && string.IsNullOrWhiteSpace(this.Text))
            {
                isPlaceholder = true;
                this.UseSystemPasswordChar = false;
                this.ForeColor = placeholderColor;
                this.Text = placeholderText;
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                if (this.ForeColor != normalTextColor)
                    placeholderColor = value;
            }
        }

        //Propertes
        [Category("Custom")]
        public string PlaceholdeText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                SetPlaceHolder();
            }
        }

        [Category("Custom")]
        public Color NormalTextColor
        {
            get => normalTextColor;
            set => normalTextColor = value;
        }

        [Category("Custom")]
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                isPassword = value;
                if (!isPlaceholder)
                    this.UseSystemPasswordChar = value;
            }
        }

        public string RealText => isPlaceholder ? "" : this.Text;

    }
}
