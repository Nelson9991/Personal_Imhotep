using Acceso_Datos;
using Personal_Imhotep.Modulo_Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Imhotep
{
    public partial class Form1 : Form
    { 
        Personal_Repository pr = new Personal_Repository();

        Hoja_de_Vida hoja = new Hoja_de_Vida();

        Doc_Personales doc = new Doc_Personales();

        TituloEdu titulo = new TituloEdu();

        Licencia licencia = new Licencia();

        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMostrarHoja_Click(object sender, EventArgs e)
        {
            hoja.ShowDialog();
        }

        byte[] buffer = null;

        public Personal ObtenerDatosPersona()
        {
            Personal persona = new Personal();

            persona.Nombre = txtNombre.Text;

            persona.Cédula = txtCédula.Text;

            persona.Formacion = dropFormacion.Text;

            persona.Caducidad_licencia = dtFechaCaduc.Value;

            persona.Certificacion = dtFechCertifica.Value;  
            
            persona.Observaciones = txtObservacion.Text;

            persona.hoja_de_vida = hoja.buffer;

              persona.doc_personales 
              persona.doc_Titulo 
              persona.nombre_hojaV persona.nombre_titulo persona.nombre_docP
              persona.doc_Certificacion persona.Licencia_Riesgos
              persona.nom_docCertif persona.nom_Licencia 
              persona.anio
        }

        private void rtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")
            {
                pr.InsertarPersona()
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrarDatosP_Click(object sender, EventArgs e)
        {
            doc.ShowDialog();
        }

        private void btnMostrarTitulo_Click(object sender, EventArgs e)
        {
            titulo.ShowDialog();
        }

        private void btnMostrarLicen_Click(object sender, EventArgs e)
        {
            licencia.ShowDialog();
        }
    }
}
