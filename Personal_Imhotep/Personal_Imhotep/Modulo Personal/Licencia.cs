using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Imhotep.Modulo_Personal
{
    public partial class Licencia : Form
    {
        public Licencia()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public byte[] buffer = null;

        public string nombLicen;

        public string rutaLicen;

        private void btnlicen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg";

                if (ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
                {
                    string ruta = ofd.FileName;
                    rutaLicen = ruta;
                    nombLicen = Path.GetFileName(ruta);
                    buffer = File.ReadAllBytes(ruta);
                    webLicencia.Navigate(ruta);
                }
            }
        }

        public void MostrarPreview(string ruta)
        {
            webLicencia.Navigate(ruta);
        }


        public void MostrarLicencia(string nombreLicen, object buffer)
        {
            byte[] buffer2;

           string ruta = Directory.CreateDirectory(@"C:\temp\").FullName;

            Random random = new Random();

            int numrand = random.Next(1, 20);


            try
            {
                if (buffer.ToString() != "")
                {
                    ruta = Path.Combine(ruta, nombreLicen + numrand.ToString());

                    rutaLicen = ruta;

                    buffer2 = (byte[])buffer;


                    using (FileStream fs = File.Create(ruta))
                    {
                        fs.Write(buffer2, 0, buffer2.Length);
                        fs.Close();
                        
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            webLicencia.Navigate(ruta);

            
        }
        

        private void btnLicencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            this.Close();
        }
    }
}
