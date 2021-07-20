using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidad;
using Negocio;

namespace Trabajo_Final_Grupo_8
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }
        void mantenimiento(String accion)
        {
            objent.ID = textID.Text;
            objent.Nombre = textName.Text;
            objent.Edad = Convert.ToInt32(textAge.Text);
            objent.Telefono = Convert.ToInt32(textPhone.Text);
            objent.accion = accion;
            String men = objneg.mantenimiento_cliente(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            textID.Text = "";
            textName.Text = "";
            textAge.Text = "";
            textPhone.Text = "";
            textFind.Text = "";
            dataGridView1.DataSource = objneg.listar_clientes();
        }
        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textFind.Text != "")
            {
                objent.Nombre = textFind.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.listar_clientes();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.listar_clientes();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (textID.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + textName.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
                
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textID.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + textName.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textID.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + textName.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            textID.Text = dataGridView1[0, fila].Value.ToString();
            textName.Text = dataGridView1[1, fila].Value.ToString();
            textAge.Text = dataGridView1[2, fila].Value.ToString();
            textPhone.Text = dataGridView1[3, fila].Value.ToString();
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
