using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Entidad;
using Datos;

namespace Negocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable listar_clientes()
        {
            return objd.listar_clientes();
        }

        public DataTable N_buscar_clientes(ClassEntidad obje)
        {
            return objd.find_clientes(obje);
        }

        public String mantenimiento_cliente(ClassEntidad obje)
        {
            return objd.mantenimiento_clientes(obje);
        }
    }
}
