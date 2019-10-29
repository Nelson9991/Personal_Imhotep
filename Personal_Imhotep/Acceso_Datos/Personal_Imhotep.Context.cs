﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Acceso_Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Personal_IMHOTEPEntities : DbContext
    {
        public Personal_IMHOTEPEntities()
            : base("name=Personal_IMHOTEPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<USUARIO2> USUARIO2 { get; set; }
    
        public virtual int Actualizar_Persona(Nullable<int> id, string nombre, string cedula, string formacion, Nullable<System.DateTime> caducidad_licencia, Nullable<System.DateTime> caducidad_certif, string observaciones, byte[] hoja_vida, byte[] doc_personales, byte[] titulo, string nom_hojaV, string nom_Titulo, string nom_docP, byte[] doc_Certif, byte[] licen_riesgo, string nom_docCertif, string nom_licencia, Nullable<int> anio, string tipo_bachiller)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            var formacionParameter = formacion != null ?
                new ObjectParameter("formacion", formacion) :
                new ObjectParameter("formacion", typeof(string));
    
            var caducidad_licenciaParameter = caducidad_licencia.HasValue ?
                new ObjectParameter("caducidad_licencia", caducidad_licencia) :
                new ObjectParameter("caducidad_licencia", typeof(System.DateTime));
    
            var caducidad_certifParameter = caducidad_certif.HasValue ?
                new ObjectParameter("caducidad_certif", caducidad_certif) :
                new ObjectParameter("caducidad_certif", typeof(System.DateTime));
    
            var observacionesParameter = observaciones != null ?
                new ObjectParameter("Observaciones", observaciones) :
                new ObjectParameter("Observaciones", typeof(string));
    
            var hoja_vidaParameter = hoja_vida != null ?
                new ObjectParameter("hoja_vida", hoja_vida) :
                new ObjectParameter("hoja_vida", typeof(byte[]));
    
            var doc_personalesParameter = doc_personales != null ?
                new ObjectParameter("doc_personales", doc_personales) :
                new ObjectParameter("doc_personales", typeof(byte[]));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("titulo", titulo) :
                new ObjectParameter("titulo", typeof(byte[]));
    
            var nom_hojaVParameter = nom_hojaV != null ?
                new ObjectParameter("nom_hojaV", nom_hojaV) :
                new ObjectParameter("nom_hojaV", typeof(string));
    
            var nom_TituloParameter = nom_Titulo != null ?
                new ObjectParameter("nom_Titulo", nom_Titulo) :
                new ObjectParameter("nom_Titulo", typeof(string));
    
            var nom_docPParameter = nom_docP != null ?
                new ObjectParameter("nom_docP", nom_docP) :
                new ObjectParameter("nom_docP", typeof(string));
    
            var doc_CertifParameter = doc_Certif != null ?
                new ObjectParameter("doc_Certif", doc_Certif) :
                new ObjectParameter("doc_Certif", typeof(byte[]));
    
            var licen_riesgoParameter = licen_riesgo != null ?
                new ObjectParameter("licen_riesgo", licen_riesgo) :
                new ObjectParameter("licen_riesgo", typeof(byte[]));
    
            var nom_docCertifParameter = nom_docCertif != null ?
                new ObjectParameter("nom_docCertif", nom_docCertif) :
                new ObjectParameter("nom_docCertif", typeof(string));
    
            var nom_licenciaParameter = nom_licencia != null ?
                new ObjectParameter("nom_licencia", nom_licencia) :
                new ObjectParameter("nom_licencia", typeof(string));
    
            var anioParameter = anio.HasValue ?
                new ObjectParameter("anio", anio) :
                new ObjectParameter("anio", typeof(int));
    
            var tipo_bachillerParameter = tipo_bachiller != null ?
                new ObjectParameter("tipo_bachiller", tipo_bachiller) :
                new ObjectParameter("tipo_bachiller", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Actualizar_Persona", idParameter, nombreParameter, cedulaParameter, formacionParameter, caducidad_licenciaParameter, caducidad_certifParameter, observacionesParameter, hoja_vidaParameter, doc_personalesParameter, tituloParameter, nom_hojaVParameter, nom_TituloParameter, nom_docPParameter, doc_CertifParameter, licen_riesgoParameter, nom_docCertifParameter, nom_licenciaParameter, anioParameter, tipo_bachillerParameter);
        }
    
        public virtual ObjectResult<Buscar_Anio_Personal_Result> Buscar_Anio_Personal(string letra)
        {
            var letraParameter = letra != null ?
                new ObjectParameter("letra", letra) :
                new ObjectParameter("letra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Buscar_Anio_Personal_Result>("Buscar_Anio_Personal", letraParameter);
        }
    
        public virtual ObjectResult<buscar_formacion_Result> buscar_formacion(string letra)
        {
            var letraParameter = letra != null ?
                new ObjectParameter("letra", letra) :
                new ObjectParameter("letra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_formacion_Result>("buscar_formacion", letraParameter);
        }
    
        public virtual ObjectResult<buscar_person_nom_Result> buscar_person_nom(string letra)
        {
            var letraParameter = letra != null ?
                new ObjectParameter("letra", letra) :
                new ObjectParameter("letra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_person_nom_Result>("buscar_person_nom", letraParameter);
        }
    
        public virtual ObjectResult<buscar_tipo_Bachiller_Result> buscar_tipo_Bachiller(string letra)
        {
            var letraParameter = letra != null ?
                new ObjectParameter("letra", letra) :
                new ObjectParameter("letra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_tipo_Bachiller_Result>("buscar_tipo_Bachiller", letraParameter);
        }
    
        public virtual ObjectResult<buscar_usuario_Result> buscar_usuario(string letra)
        {
            var letraParameter = letra != null ?
                new ObjectParameter("letra", letra) :
                new ObjectParameter("letra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_usuario_Result>("buscar_usuario", letraParameter);
        }
    
        public virtual int editar_usuario(Nullable<int> idUsuario, string nombres, string login, string password, byte[] icono, string nombre_de_icono, string correo, string rol)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("nombres", nombres) :
                new ObjectParameter("nombres", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var iconoParameter = icono != null ?
                new ObjectParameter("Icono", icono) :
                new ObjectParameter("Icono", typeof(byte[]));
    
            var nombre_de_iconoParameter = nombre_de_icono != null ?
                new ObjectParameter("Nombre_de_icono", nombre_de_icono) :
                new ObjectParameter("Nombre_de_icono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("editar_usuario", idUsuarioParameter, nombresParameter, loginParameter, passwordParameter, iconoParameter, nombre_de_iconoParameter, correoParameter, rolParameter);
        }
    
        public virtual int Eliminar_Persona(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Eliminar_Persona", idParameter);
        }
    
        public virtual int eliminar_usuario(Nullable<int> idusuario, string login)
        {
            var idusuarioParameter = idusuario.HasValue ?
                new ObjectParameter("idusuario", idusuario) :
                new ObjectParameter("idusuario", typeof(int));
    
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("eliminar_usuario", idusuarioParameter, loginParameter);
        }
    
        public virtual int Insertar_Persona(string nombre, string cedula, string formacion, Nullable<System.DateTime> caducidad, Nullable<System.DateTime> certificacion, string observaciones, byte[] hoja_vida, byte[] doc_perso, byte[] titulo, string nom_hoja, string nom_docs, string nombre_titulo, string estado, byte[] doc_Certificacion, byte[] licencia_riesgos, string nom_docCertif, string nom_licencia, Nullable<int> anio, string tipo_Bachiller)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            var formacionParameter = formacion != null ?
                new ObjectParameter("Formacion", formacion) :
                new ObjectParameter("Formacion", typeof(string));
    
            var caducidadParameter = caducidad.HasValue ?
                new ObjectParameter("Caducidad", caducidad) :
                new ObjectParameter("Caducidad", typeof(System.DateTime));
    
            var certificacionParameter = certificacion.HasValue ?
                new ObjectParameter("Certificacion", certificacion) :
                new ObjectParameter("Certificacion", typeof(System.DateTime));
    
            var observacionesParameter = observaciones != null ?
                new ObjectParameter("Observaciones", observaciones) :
                new ObjectParameter("Observaciones", typeof(string));
    
            var hoja_vidaParameter = hoja_vida != null ?
                new ObjectParameter("hoja_vida", hoja_vida) :
                new ObjectParameter("hoja_vida", typeof(byte[]));
    
            var doc_persoParameter = doc_perso != null ?
                new ObjectParameter("doc_perso", doc_perso) :
                new ObjectParameter("doc_perso", typeof(byte[]));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("titulo", titulo) :
                new ObjectParameter("titulo", typeof(byte[]));
    
            var nom_hojaParameter = nom_hoja != null ?
                new ObjectParameter("nom_hoja", nom_hoja) :
                new ObjectParameter("nom_hoja", typeof(string));
    
            var nom_docsParameter = nom_docs != null ?
                new ObjectParameter("nom_docs", nom_docs) :
                new ObjectParameter("nom_docs", typeof(string));
    
            var nombre_tituloParameter = nombre_titulo != null ?
                new ObjectParameter("nombre_titulo", nombre_titulo) :
                new ObjectParameter("nombre_titulo", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var doc_CertificacionParameter = doc_Certificacion != null ?
                new ObjectParameter("doc_Certificacion", doc_Certificacion) :
                new ObjectParameter("doc_Certificacion", typeof(byte[]));
    
            var licencia_riesgosParameter = licencia_riesgos != null ?
                new ObjectParameter("licencia_riesgos", licencia_riesgos) :
                new ObjectParameter("licencia_riesgos", typeof(byte[]));
    
            var nom_docCertifParameter = nom_docCertif != null ?
                new ObjectParameter("nom_docCertif", nom_docCertif) :
                new ObjectParameter("nom_docCertif", typeof(string));
    
            var nom_licenciaParameter = nom_licencia != null ?
                new ObjectParameter("nom_licencia", nom_licencia) :
                new ObjectParameter("nom_licencia", typeof(string));
    
            var anioParameter = anio.HasValue ?
                new ObjectParameter("anio", anio) :
                new ObjectParameter("anio", typeof(int));
    
            var tipo_BachillerParameter = tipo_Bachiller != null ?
                new ObjectParameter("tipo_Bachiller", tipo_Bachiller) :
                new ObjectParameter("tipo_Bachiller", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insertar_Persona", nombreParameter, cedulaParameter, formacionParameter, caducidadParameter, certificacionParameter, observacionesParameter, hoja_vidaParameter, doc_persoParameter, tituloParameter, nom_hojaParameter, nom_docsParameter, nombre_tituloParameter, estadoParameter, doc_CertificacionParameter, licencia_riesgosParameter, nom_docCertifParameter, nom_licenciaParameter, anioParameter, tipo_BachillerParameter);
        }
    
        public virtual int insertar_usuario(string nombres, string login, string password, byte[] icono, string nombre_de_icono, string correo, string rol, string estado)
        {
            var nombresParameter = nombres != null ?
                new ObjectParameter("nombres", nombres) :
                new ObjectParameter("nombres", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var iconoParameter = icono != null ?
                new ObjectParameter("Icono", icono) :
                new ObjectParameter("Icono", typeof(byte[]));
    
            var nombre_de_iconoParameter = nombre_de_icono != null ?
                new ObjectParameter("Nombre_de_icono", nombre_de_icono) :
                new ObjectParameter("Nombre_de_icono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertar_usuario", nombresParameter, loginParameter, passwordParameter, iconoParameter, nombre_de_iconoParameter, correoParameter, rolParameter, estadoParameter);
        }
    
        public virtual ObjectResult<Mostrar_Personas_Result> Mostrar_Personas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Mostrar_Personas_Result>("Mostrar_Personas");
        }
    
        public virtual ObjectResult<mostrar_usuario_Result> mostrar_usuario()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrar_usuario_Result>("mostrar_usuario");
        }
    }
}
