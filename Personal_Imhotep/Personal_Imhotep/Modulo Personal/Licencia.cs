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
        public bool m_myFunctionCalled;

        public Licencia()
        {
            InitializeComponent();

            m_myFunctionCalled = false;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            m_myFunctionCalled = false;
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

        public void MostrarPreview()
        {
            try
            {
                webLicencia.Navigate(rutaLicen);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void myFunction()
        {
            m_myFunctionCalled = true;
            return;
        }

        public async void MostrarLicencia(string nombreLicen, object buffer)
        {
            myFunction();

            byte[] buffer2;

            string ruta = @"C:\temp\";

            FileStream fs;

            Random random = new Random();

            int numrand = random.Next(1, 20);


            try
            {
                if (buffer.ToString() != "")
                {
                    ruta = Path.Combine(ruta, nombreLicen + numrand.ToString());

                    rutaLicen = ruta;

                    buffer2 = (byte[])buffer;


                    using (fs = File.Create(ruta))
                    {
                        fs.Write(buffer2, 0, buffer2.Length);
    
                    }
                    webLicencia.Navigate(ruta);
                    
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


        private void btnLicencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            m_myFunctionCalled = false;
            this.Close();
        }
    }
}
