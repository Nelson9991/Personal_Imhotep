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

        public Hoja_de_Vida()
        {
            InitializeComponent();
        }

        public byte[] buffer = null;
        public string nombHoja;
        public string rutaHoja;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg" ;

            if(ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
            {
                string ruta = ofd.FileName;
                rutaHoja = ruta;
                nombHoja = Path.GetFileName(ruta);
                buffer = File.ReadAllBytes(ruta);
                webHojaV.Navigate(ruta);
            }
        }

        public void MostrarPreview(string ruta)
        {
            webHojaV.Navigate(ruta);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarHoja_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos Guardados");
            this.Close();
        }

        FileStream fs;

        public void MostrarHojaV(string nombreHoja, object buffer)
        {

                byte[] buffer2;

            string ruta = @"C:\temp\";

            if (buffer.ToString() != "")
            {
                ruta = Path.Combine(ruta, nombreHoja);

                rutaHoja = ruta;

                buffer2 = (byte[])buffer;

                try
                {
                    using(FileStream fs = File.Create(ruta))
                    {
                        fs.Write(buffer2, 0, buffer2.Length);

                       
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
 
               
                webHojaV.Navigate(ruta);
            }
        }
            
        
    }
}
