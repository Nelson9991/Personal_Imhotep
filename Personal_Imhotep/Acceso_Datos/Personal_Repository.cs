using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class Personal_Repository
    {
        public List<Mostrar_Personas_Result> MostrarPersonal()
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                var personNueva = contexto.Mostrar_Personas().ToList(); ;

                return personNueva;
            }
        }

        public int ActualizarPersona(Personal personaModificada)
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                contexto.Actualizar_Persona(personaModificada.Id, personaModificada.Nombre, personaModificada.Cédula, personaModificada.Formacion, personaModificada.Caducidad_licencia, personaModificada.Certificacion, personaModificada.Observaciones, personaModificada.hoja_de_vida, personaModificada.doc_personales, personaModificada.doc_Titulo, personaModificada.nombre_hojaV, personaModificada.nombre_titulo, personaModificada.nombre_docP, personaModificada.doc_Certificacion, personaModificada.Licencia_Riesgos, personaModificada.nom_docCertif, personaModificada.nom_Licencia, personaModificada.anio);

                return contexto.SaveChanges();
            }
        }

        public int InsertarPersona(Personal persona)
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                contexto.Insertar_Persona(persona.Nombre, persona.Cédula, persona.Formacion, persona.Caducidad_licencia, persona.Certificacion, persona.Observaciones, persona.hoja_de_vida, persona.doc_personales, persona.doc_Titulo, persona.nombre_hojaV, persona.nombre_docP, persona.nombre_titulo,
              "Activo",
              persona.doc_Certificacion, persona.Licencia_Riesgos, persona.nom_docCertif, persona.nom_Licencia, persona.anio);

                return contexto.SaveChanges();
            }
        }

        public int EliminarPersona(int id)
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                contexto.Eliminar_Persona(id);

                return contexto.SaveChanges();
            }
        }

        public List<buscar_person_nom_Result> BuscarNombPerso(string letra)
        {
            using(var contexto = new Personal_IMHOTEPEntities())
            {
               var resul = contexto.buscar_person_nom(letra);

                return resul.ToList();
            }
        }

        public List<buscar_formacion_Result> BuscarFormacionPerso(string letra)
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                var resul = contexto.buscar_formacion(letra);

                return resul.ToList();
            }
        }


        public List<mostrar_usuario_Result> MostrarUsuarios()
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                var usuarioNuevo = contexto.mostrar_usuario().ToList();

                return usuarioNuevo;
            }
        }

        public int ActualizarUsuario(USUARIO2 usuarioModificado)
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                contexto.editar_usuario(usuarioModificado.idUsuario, usuarioModificado.Nombres_y_Apellidos, usuarioModificado.Login, usuarioModificado.Password, usuarioModificado.Icono, usuarioModificado.Nombre_de_icono, usuarioModificado.Correo, usuarioModificado.Rol);

                return contexto.SaveChanges();

            }

        }

        public int EliminarUsuario(int id_Usuario, string login)
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                contexto.eliminar_usuario(id_Usuario, login);

                return contexto.SaveChanges();
            }
        }

        public List<buscar_usuario_Result> BuscarUsuario(string letra)
        {
            using (var contexto = new Personal_IMHOTEPEntities())
            {
                var usuarios = contexto.buscar_usuario(letra);

                return usuarios.ToList();
            }
        }
    }
}
