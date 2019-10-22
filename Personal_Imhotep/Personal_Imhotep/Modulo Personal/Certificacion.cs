﻿using System;
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
            OpenFileDialog ofd = new OpenFileDialog();
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

        public void MostrarPreview(string ruta)
        {
            webCertificacion.Navigate(ruta);
        }

        public void MostrarCertificacion(string nombreCertif, object buffer)
        {

            byte[] buffer2;

            string ruta = @"C:\temp\";

            if (buffer.ToString() != "")
            {
                ruta = Path.Combine(ruta, nombreCertif);

                rutaCertif = ruta;

                buffer2 = (byte[])buffer;

                File.WriteAllBytes(ruta, buffer2);

                webCertificacion.Navigate(ruta);
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
