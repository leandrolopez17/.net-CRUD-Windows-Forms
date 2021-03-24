using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

/*
 * Esta es la capa de Negocio que se encarga de Hacer un puente entre la Capa de Datos y la de Presentacion
 * Aca recibimos los datos que nos da presentacion y se los damos a la capa de datos
 * La capa de presentacion usa estos metodos y nosotros aca usamos los metodos de la capa de datos
 */

namespace CapaNegocio
{
    public class CN_Productos
    {
        // Hacemos un objeto Producto de la capa de datos
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarProd()
        {
            // Hacemos una tabla, usamos el metodo mostrar de la capa de datos Productos y returneamos la tabla
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarProd (string nombre, string desc, string marca, string precio, string stock)
        {
            // insertamos los datos en la capa de datos Productos
            objetoCD.Insertar(nombre,desc,marca,Convert.ToDouble(precio),Convert.ToInt32(stock));
        }

        public void EditarProd(string nombre, string desc, string marca, string precio, string stock,string id)
        {
            // Editamos los datos en la capa de datos Productos
            objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));
        }

        public void EliminarProd(string id)
        {
            // eliminamos los datos en la capa de datos productos
            objetoCD.Eiminar(Convert.ToInt32(id));
        }
    }
}
