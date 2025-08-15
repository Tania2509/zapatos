using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formularios
{
    public partial class frmMantenimientoZapatos : Form
    {
        public frmMantenimientoZapatos()
        {
            InitializeComponent();
        }

        private void frmMantenimientoZapatos_Load(object sender, EventArgs e)
        {
            cargarEspecialidades();
            CargarZapatos();
        }

        private void CargarZapatos()
        {
            dgvAlmacen.DataSource = null;
            dgvAlmacen.DataSource = Modelos.Entidades.Zapato.CargarZapatos();

            dgvEdit.DataSource = null;
            dgvEdit.DataSource = Modelos.Entidades.Zapato.CargarZapatos();
        }

        private void cargarEspecialidades()
        {
            cbCategoria.DataSource = null;
            cbCategoria.DataSource = Modelos.Entidades.Categoria.CargarCategoria();
            //usar displaymenber
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "Id";
            cbCategoria.SelectedIndex = -1; // Para que no seleccione nada al inicio

            //---------------------------Actualizar

            cbActualizar.DataSource = null;
            cbActualizar.DataSource = Modelos.Entidades.Categoria.CargarCategoria();
            cbActualizar.DisplayMember = "Nombre";
            cbActualizar.ValueMember = "Id";
            cbActualizar.SelectedIndex = -1;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones de campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || cbCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("No puedes dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                Zapato zap = new Zapato();
                zap.Nombre = txtNombre.Text;
                zap.Precio = double.Parse(txtPrecio.Text);
                zap.FechaCreacion = dtpFecha.Value;
                zap.IdCategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                zap.ImagenURL = "";
                zap.insertarZapatos();
                CargarZapatos();
                MessageBox.Show("Se registró correctamente el zapato", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el zapato: " + ex.Message, "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Zapato zapatoEliminar = new Zapato();
            int id = int.Parse(dgvAlmacen.CurrentRow.Cells[0].Value.ToString());
            string registroEliminar = dgvAlmacen.CurrentRow.Cells[1].Value.ToString();
            DialogResult respueta = MessageBox.Show("¿Quieres eliminar este registro?" + registroEliminar, "Advertencia eliminaras un regsitro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respueta == DialogResult.Yes) {           
                if (zapatoEliminar.eliminarZapato(id) == true)
                {
                    MessageBox.Show("Se elimino correctamente el registro", "Registro eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarZapatos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
