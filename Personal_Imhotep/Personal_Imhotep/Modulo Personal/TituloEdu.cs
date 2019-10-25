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
    public partial class TituloEdu : Form
    {
        public TituloEdu()
        {
            InitializeComponent();
        }


        public byte[] buffer = null;
        public string nombTitulo;
        public string rutaTitulo;

        private void btnCargarTitulo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
            {
                string ruta = ofd.FileName;
                rutaTitulo = ruta;
                nombTitulo = Path.GetFileName(ruta);
                buffer = File.ReadAllBytes(ruta);
                webTitulo.Navigate(ruta);
            }
        }

        public void MostrarPreview(string ruta)
        {
            webTitulo.Navigate(ruta);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        FileStream fs = null;

        public void MostrarTitulo(string nombreTitulo, object buffer)
        {
            byte[] buffer2;

            string ruta = @"C:\temp\";

            try
            {
                if (buffer.ToString() != "")
                {
                    ruta = Path.Combine(ruta, nombreTitulo);

                    rutaTitulo = ruta;

                    buffer2 = (byte[])buffer;


                    using (fs = File.Create(ruta))
                    {
                        fs.Write(buffer2, 0, buffer2.Length);
                    }
                }
            }
            catch
            {
              
            }

            webTitulo.Navigate(ruta);
        }

        private void btnGuardarTitulo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            this.Close();
        }
    }
}
