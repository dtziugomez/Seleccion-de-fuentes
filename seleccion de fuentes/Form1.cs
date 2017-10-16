using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace seleccion_de_fuentes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboFuentes.Items.AddRange(FontFamily.Families);
            
        }
        private FontStyle GetFontStyle(FontFamily ff)
        {
            FontStyle fontStyle = FontStyle.Regular;
            if (!ff.IsStyleAvailable(FontStyle.Regular))
                fontStyle = FontStyle.Italic;
            if (!ff.IsStyleAvailable(FontStyle.Italic))
                fontStyle = FontStyle.Bold;
            return fontStyle;


        }

        private void cboFuentes_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cboFuentes = (ComboBox)sender;
            if (e.Index == -1)
                return;
            if (sender == null)
                return;
            FontFamily fontFamily = (FontFamily)cboFuentes.Items[e.Index];
            Font fuente = new Font(fontFamily.Name, 12, GetFontStyle(fontFamily));
            e.DrawBackground();
            e.DrawFocusRectangle();
            Graphics g = e.Graphics;
            g.DrawString(fontFamily.Name, fuente, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 4);
        }

        private void cboFuentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily fontFamily = (FontFamily)cboFuentes.SelectedItem;
            label2.Font = new Font(fontFamily.Name, label1.Font.Size, GetFontStyle(fontFamily));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Font = new Font(label2.Font.Name, int.Parse(comboBox1.SelectedItem.ToString()), label2.Font.Style);
            
        }
    }
}