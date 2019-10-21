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
    public partial class Doc_Personales : Form
    {
        public Doc_Personales()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public byte[] buffer = null;
        public string nombDocs;
        public string rutaDocs;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
            {
                string ruta = ofd.FileName;
                nombDocs = Path.GetFileName(ruta);
                buffer = File.ReadAllBytes(ruta);
                webDocs.Navigate(ruta);
            }
        }

        public void MostrarDocs_Perso(string nombreDoc, object buffer)
        {

            byte[] buffer2;

            string ruta = @"C:\temp\";

            if (buffer.ToString() != "")
            {
                ruta = Path.Combine(ruta, nombreDoc);

                rutaDocs = ruta;

                buffer2 = (byte[])buffer;

                File.WriteAllBytes(ruta, buffer2);

                webDocs.Navigate(ruta);
            }
        }

        private void btnGuardarDocs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            this.Close();
        }
    }
}
