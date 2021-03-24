using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Esta es la capa de datos de productos
 * Aca van a estar las funciones de Productos
 * Necessarias para Mostrar Insertar Editar y Eliminar Datos
 * Esto se relaciona directamente con la base de datos
 */


namespace CapaDatos
{
    public class CD_Productos
    {
        // Hacemos un objeto CD_Conexion que es una clase de la capa de datos
        private CD_Conexion conexion = new CD_Conexion();

        // Objetos necesarios para poder hacer los metodos (leer,tabla y comando)
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            // Abrimos la conexion, Llamamos al store prodecure de MostrarProductos que esta en la base de datos
            // Leemos la tabla, cerramos la conexion y hacemos un return de la tabla
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre,string desc,string marca,double precio,int stock)
        {
            //Abrimos la conexion, Llamamos al store prodecure de InsertarProductos que esta en la base de datos
            //Le pasamos los valores que trae la funcion y ejecutamos la query para que se inserten los valores
            //Finalmente hacemos un Clear de los parametros de comando
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Editar(string nombre, string desc, string marca, double precio, int stock,int id)
        {
            //Abrimos la conexion, Llamamos al store prodecure de EditarProductos que esta en la base de datos
            //Le pasamos los valores que trae la funcion y ejecutamos la query para que se Editen los valores
            //Finalmente hacemos un Clear de los parametros de comando
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Eiminar (int id)
        {
            //Abrimos la conexion, Llamamos al store prodecure de EliminarProductos que esta en la base de datos
            //Le pasamos el unico valor que el Id y ejecutamos la query y hacemos un clear de parametros
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro",id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

    }
}
