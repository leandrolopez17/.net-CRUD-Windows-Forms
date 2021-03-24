using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Esta es la capa de datos de Conexion
// Se encarga de Armar la conexion y de tener los metodos de Apertura y Cierre de Conexion
// Tambien se usa en la capa de datos de Productos para poder comunicarnos con la base de datos

namespace CapaDatos
{
    public class CD_Conexion
    {
        // Arma la conexion 
        private SqlConnection Conexion = new SqlConnection("server=(local);DataBase=Practica;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
