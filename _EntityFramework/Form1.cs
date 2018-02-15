using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _EntityFramework.Models;

namespace _EntityFramework
{
    public partial class Form1 : Form
    {
        private Alumno model = new Alumno();
        public Form1()
        {
            InitializeComponent();
            //dgvLista.AutoGenerateColumns = false;
        }

        public void ListarAlumnos()
        {
            dgvLista.DataSource = model.Listar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarAlumnos();
        }

        private void dgvLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            new Form2(Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells[0].Value), this).ShowDialog();
            ListarAlumnos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new Form2(0, this).ShowDialog();
            ListarAlumnos();
        }
    }
}
