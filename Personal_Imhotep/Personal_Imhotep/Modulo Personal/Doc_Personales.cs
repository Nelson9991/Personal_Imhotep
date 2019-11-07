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
                    using (FileStream fs = File.OpenRead(ruta))
                    {
                        fs.Read(buffer, 0, int.MaxValue);
                    }
                    webDocs.Navigate(ruta);
                }
            }
        }

        public void MostrarPreview(string ruta)
        {
            webDocs.Navigate(ruta);
        }

        

        public void MostrarDocs_Perso(string nombreDoc, object buffer)
        {

            byte[] buffer2;

            string ruta = Directory.CreateDirectory(@"C:\temp\").FullName;

            Random random = new Random();

            int numrand = random.Next(1, 20);


            try
            {
                if (buffer.ToString() != "")
                {
                    ruta = Path.Combine(ruta, nombreDoc + numrand.ToString());

                    rutaDocs = ruta;

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

            webDocs.Navigate(ruta);

        }


        private void btnGuardarDocs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            this.Close();
        }
    }
}
