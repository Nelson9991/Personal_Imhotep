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
    public partial class Certificacion : Form
    {
        public Certificacion()
        {
            InitializeComponent();
        }

        public byte[] buffer = null;
        public string nombCertif;
        public string rutaCertif;

        private void btnCargarCertifi_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg";

                if (ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
                {
                    string ruta = ofd.FileName;
                    rutaCertif = ruta;
                    nombCertif = Path.GetFileName(ruta);
                    buffer = File.ReadAllBytes(ruta);
                    webCertificacion.Navigate(ruta);
                }
            }
        }

        public void MostrarPreview()
        {
            try
            {
                webCertificacion.Navigate(rutaCertif);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async void MostrarCertificacion(string nombreCertif, object buffer)
        {

            byte[] buffer2;

            string ruta = @"C:\temp\";

            FileStream fs;

            Random random = new Random();

            int numrand = random.Next(1, 20);


            try
            {
                if (buffer.ToString() != "")
                {
                    ruta = Path.Combine(ruta, nombreCertif + numrand.ToString());

                    rutaCertif = ruta;

                    buffer2 = (byte[])buffer;


                    using (fs = File.Create(ruta))
                    {
                        fs.Write(buffer2, 0, buffer2.Length);
      
                    }
                    webCertificacion.Navigate(ruta);
                }
        }
            catch (IOException)
            {
                await Task.Delay(30);
            }
            catch (UnauthorizedAccessException)
            {
                await Task.Delay(30);
            }


        }


        private void btnCertif_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
