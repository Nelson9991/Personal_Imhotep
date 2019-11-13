using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public bool m_myFunctionCalled;

        public Hoja_de_Vida()
        {
            InitializeComponent();

            m_myFunctionCalled = false;
        }

        public byte[] buffer = null;
        public string nombHoja;
        public string rutaHoja;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {


                ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg";

                if (ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
                {
                    string ruta = ofd.FileName;
                    rutaHoja = ruta;
                    nombHoja = Path.GetFileName(ruta);
                    buffer = File.ReadAllBytes(ruta);
                    webHojaV.Navigate(ruta);
                }
            }
        }

        public void MostrarPreview()
        {
            try
            {
                webHojaV.Navigate(rutaHoja);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            m_myFunctionCalled = false;
            this.Close();
        }

        private void btnGuardarHoja_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            m_myFunctionCalled = false;
            this.Close();
        }

        public void myFunction()
        {
            m_myFunctionCalled = true;
            return;
        }

    public async void MostrarHojaV(string nombreHoja, object buffer)
        {
            myFunction();

            byte[] buffer2;

            string ruta = @"C:\temp\";

            FileStream fs;

            Random random = new Random();

            int numrand = random.Next( 1, 20);

            try
            {
                if (buffer.ToString() != "")
                {
                    ruta = Path.Combine(ruta, nombreHoja + numrand.ToString());

                    rutaHoja = ruta;

                    buffer2 = (byte[])buffer;


                    using (fs = File.Create(ruta))
                    {
                        fs.Write(buffer2, 0, buffer2.Length);

                    }
                    webHojaV.Navigate(ruta);
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


    }
}
