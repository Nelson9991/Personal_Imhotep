﻿using Acceso_Datos;
using Personal_Imhotep.Modulo_Personal;
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

namespace Personal_Imhotep
{
    public partial class Form1 : Form
    { 
        Personal_Repository pr = new Personal_Repository();

        Hoja_de_Vida hoja = new Hoja_de_Vida();

        Doc_Personales doc = new Doc_Personales();

        TituloEdu titulo = new TituloEdu();

        Licencia licencia = new Licencia();

        Certificacion certif = new Certificacion();

        public Form1()
        {
            InitializeComponent();
        }

        public DataGridView ObetnerGrid()
        {
            var grilla = GridPersonal;

            return grilla;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMostrarHoja_Click(object sender, EventArgs e)
        {
            try
            {
                hoja.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


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

            persona.doc_personales = doc.buffer;

            persona.doc_Titulo = titulo.buffer;

            persona.nombre_hojaV = hoja.nombHoja;

            persona.nombre_titulo = titulo.nombTitulo;

            persona.nombre_docP = doc.nombDocs;

            persona.doc_Certificacion = certif.buffer;

            persona.Licencia_Riesgos = licencia.buffer;

            persona.nom_docCertif = certif.nombCertif;

            persona.nom_Licencia = licencia.nombLicen;

            persona.anio = Convert.ToInt32(dpAnio.Text);

            return persona;
        }

        private void rtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")
            {
                try
                {
                    var persona = ObtenerDatosPersona();

                    pr.InsertarPersona(persona);

                    MessageBox.Show("Datos guardados");

                    Mostrar();
                    panel_Usuarios.Visible = false;
                    btnNuevo.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
            }
        }

        private void Mostrar()
        {
            try
            {

                var personal = pr.MostrarPersonal();
                GridPersonal.DataSource = personal;

                GridPersonal.Columns[0].DisplayIndex = 18;
                GridPersonal.Columns[1].Visible = false;
                GridPersonal.Columns[5].HeaderText = "Caducidad Licencia";
                GridPersonal.Columns[8].Visible = false;
                GridPersonal.Columns[9].Visible = false;
                GridPersonal.Columns[10].Visible = false;
                GridPersonal.Columns[11].Visible = false;
                GridPersonal.Columns[12].Visible = false;
                GridPersonal.Columns[13].Visible = false;
                GridPersonal.Columns[14].Visible = false;
                GridPersonal.Columns[15].Visible = false;
                GridPersonal.Columns[16].Visible = false;
                GridPersonal.Columns[17].Visible = false;
                GridPersonal.Columns[18].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar();
            panel_Usuarios.Visible = false;

        }

        private void btnMostrarDatosP_Click(object sender, EventArgs e)
        {
            try
            {
                doc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarTitulo_Click(object sender, EventArgs e)
        {
            try
            {
                titulo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarLicen_Click(object sender, EventArgs e)
        {
            try
            {
                licencia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel_Usuarios.Visible = true;
            txtNombre.Text = "";
            txtCédula.Text = "";
            txtObservacion.Text = "";
            dtFechaCaduc.Value = DateTime.Today;
            dtFechCertifica.Value = DateTime.Today;
            dropFormacion.Text = "Formación";
            dpAnio.Text = "Año del Personal";
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            btnNuevo.Visible = false;
        }
        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            CerrarArchivosTemp();
            EliminarArchivosTemp(hoja.rutaHoja);
            EliminarArchivosTemp(doc.rutaDocs);
            EliminarArchivosTemp(titulo.rutaTitulo);
            EliminarArchivosTemp(certif.rutaCertif);
            EliminarArchivosTemp(licencia.rutaLicen);
            panel_Usuarios.Visible = false;

        }

        private void GridPersonal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel_Usuarios.Visible = true;

            lblIdPerson.Text = GridPersonal.SelectedCells[1].Value.ToString();

            txtNombre.Text = GridPersonal.SelectedCells[2].Value.ToString();

            txtCédula.Text = GridPersonal.SelectedCells[3].Value.ToString();

            dropFormacion.Text = GridPersonal.SelectedCells[4].Value.ToString();

            dtFechaCaduc.Value = Convert.ToDateTime(GridPersonal.SelectedCells[5].Value);

            dtFechCertifica.Value = Convert.ToDateTime(GridPersonal.SelectedCells[6].Value);

            txtObservacion.Text = GridPersonal.SelectedCells[7].Value.ToString();

            dpAnio.Text = GridPersonal.SelectedCells[18].Value.ToString();
  
            if(GridPersonal.SelectedCells[8].Value != null)
            {
                hoja.MostrarHojaV(GridPersonal.SelectedCells[11].Value.ToString(), GridPersonal.SelectedCells[8].Value);
            }
            
            if (GridPersonal.SelectedCells[9].Value != null)
            {
                doc.MostrarDocs_Perso(GridPersonal.SelectedCells[13].Value.ToString(), GridPersonal.SelectedCells[9].Value);
            }
            
            if(GridPersonal.SelectedCells[10].Value != null)
            {
                titulo.MostrarTitulo(GridPersonal.SelectedCells[12].Value.ToString(), GridPersonal.SelectedCells[10].Value);
            }
            
            if (GridPersonal.SelectedCells[14].Value != null)
            {
                certif.MostrarCertificacion(GridPersonal.SelectedCells[16].Value.ToString(), GridPersonal.SelectedCells[14].Value);
            }
            
            if(GridPersonal.SelectedCells[15].Value != null)
            {
                licencia.MostrarLicencia(GridPersonal.SelectedCells[17].Value.ToString(), GridPersonal.SelectedCells[15].Value);
            }
            

        }

        private void btnMostrarCerti_Click(object sender, EventArgs e)
        {
            try
            {
                certif.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void CerrarArchivosTemp()
        {
            foreach (var process in Process.GetProcessesByName("AcroRd32")) //whatever you need to close 
            {     
                    process.Kill();
                         
            }

        }

        private void EliminarArchivosTemp(string path)
        {
            // Delete a file by using File class static method...
            if (File.Exists(path))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    File.Delete(path);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            EliminarArchivosTemp(hoja.rutaHoja);
            EliminarArchivosTemp(doc.rutaDocs);
            EliminarArchivosTemp(titulo.rutaTitulo);
            EliminarArchivosTemp(certif.rutaCertif);
            EliminarArchivosTemp(licencia.rutaLicen);
        }
    }
}
