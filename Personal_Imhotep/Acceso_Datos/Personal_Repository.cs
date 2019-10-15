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
    }
}
