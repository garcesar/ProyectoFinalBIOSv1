using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static void Agregar(Usuario pUsuario)
        {
            PersistenciaUsuario.AltaUsuario((Usuario)pUsuario);
        }
        public static Usuario Buscar(string pNombre)
        {
            Usuario usuario = null;
            usuario = (Usuario)PersistenciaUsuario.BuscarUsuario(pNombre);
            return usuario;
        }
    }
}
