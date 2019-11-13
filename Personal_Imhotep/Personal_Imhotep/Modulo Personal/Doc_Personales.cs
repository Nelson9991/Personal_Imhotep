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
        public bool m_myFunctionCalled;

        public Doc_Personales()
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
        public string nombDocs;
        public string rutaDocs;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            { 
                ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg";

                if (ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
                {
                    string ruta = ofd.FileName;
                    rutaDocs = ruta;
                    nombDocs = Path.GetFileName(ruta);
                    buffer = File.ReadAllBytes(ruta);
                    webDocs.Navigate(ruta);
                }
            }
        }

        public void MostrarPreview()
        {
            try
            {
                webDocs.Navigate(rutaDocs);
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

        public async void MostrarDocs_Perso(string nombreDoc, object buffer)
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
                    ruta = Path.Combine(ruta, nombreDoc + numrand.ToString());

                    rutaDocs = ruta;

                    buffer2 = (byte[])buffer;


                    using (fs = File.Create(ruta))
                    {
                        fs.Write(buffer2, 0, buffer2.Length);

                    }
                    webDocs.Navigate(ruta);
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


        private void btnGuardarDocs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            m_myFunctionCalled = false;
            this.Close();
        }
    }
}
