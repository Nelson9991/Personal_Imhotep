using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Imhotep.Modulo_Personal
{
    public partial class Hoja_de_Vida : Form
    {

        Form1 form1;

        public Hoja_de_Vida()
        {
            InitializeComponent();
        }

        public byte[] buffer = null;
        public string nombHoja;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg" ;

            if(ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
            {
                string ruta = ofd.FileName;
                nombHoja = Path.GetFileName(ruta);
                buffer = File.ReadAllBytes(ruta);
                webHojaV.Navigate(ruta);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardarHoja_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            this.Close();
        }

        public void MostrarHojaV()
        {
            byte[] buffer2;

            var grilla = form1.ObetnerGrid();

            string nombreHoja = grilla.SelectedCells[11].Value.ToString();

            string ruta = @"C:\";

            if (grilla.SelectedCells[8].Value.ToString() != "")
            {
                ruta = Path.Combine(ruta, nombHoja);

                buffer2 = (byte[])grilla.SelectedCells[8].Value;

                File.WriteAllBytes(ruta, buffer2);

                webHojaV.Navigate(ruta);
            }
        }
    }
}
