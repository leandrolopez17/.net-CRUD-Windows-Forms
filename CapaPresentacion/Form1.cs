using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

/*
 * Esta es la capa de Presentacion la cual se encarga de recibir los datos visualmente y se los manda a la capa de negocio
 */

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Hacemos un objeto Producto de la capa de Negocio
        // Tambien un string idProducto = Null para usarlo en la logica de la app
        // Tambien un booleano Editar = False para usarlo en la logica de la app
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false;

        public Form1()
        {
            // Se inicializa el componente
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Arranca mostrando los productos
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            // hacmos un nuevo objeto Producto de la capa de negocio
            // Le metemos la tabla al data grid
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //En este caso vamos a buscar Insertar el producto ya que es necesario que la variable editar = false
            if (Editar == false)
            {
            try
            {
                // Hacemos un try de insertar productos usando el objeto que creamos al principio de la form
                // Hacemos un mensaje, Volovemos a mostrar los productos y limpiamos la hoja donde escribimos los datos
                objetoCN.InsertarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                MessageBox.Show("Se inserto correctamente");
                MostrarProductos();
                limpiarForm();
            }
            catch(Exception ex)
            {
                // Hacemos un catch por si hay un error 
                MessageBox.Show("no se pudo insertar los datos por: " + ex);
            }
            }
            // En este caso vamos a editar un producto ya que la variable editar = True
            if (Editar == true)
            {
                try{
                    // Hacemos un try de editar productos usando el objeto que creamos al principio de la form
                    // hacemos un mensaje, volvemos a mostrar los productos y limpiamos la hoja donde escribimos los datos
                    // Tambien ponemos la variable Editar devuelta en False para dejar de editar 
                    objetoCN.EditarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se edito correctamente");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    // hacemos un catch por si hay un error
                    MessageBox.Show("no se pudo Editar los datos por: " + ex);
                }
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // en este if vemos si elegimos una linea a editar o mas de una
            if(dataGridView1.SelectedRows.Count > 0)
            {
                // cambiamos a true editar para que despues en el boton guardar entre en editar
                // agarramos todos los valores de la tabla y los ponemos en la pestaña de datos
                // De esta manera se van a poder ver los datos y editarlos
                // idProducto se lo iguala al dato de id de la linea seleccionada
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                // Se muestra un mensaje si no se selecciono ninguna fila
                MessageBox.Show("seleccione una fila por favor");
            }
        }

        private void limpiarForm()
        {
            // Ponemos en blanco todos los valores de la hoja de datos
            txtDesc.Clear();
            txtMarca.Text = "";
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // se fija si se selecciono alguna fila
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // agarra el id de la fila seleccionada
                // usando el objeto de Producto de la capa de negocio elimina los registros asociados a ese id
                // Mensaje y refreshea mostrando devuelta los productos
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProd(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProductos();
            }
            else
            {
                // Se muestra un mensaje pidiendo que se seleccione una fila
                MessageBox.Show("seleccione una fila por favor");
            }
        }
    }
}
