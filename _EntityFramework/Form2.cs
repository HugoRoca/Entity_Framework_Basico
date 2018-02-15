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
    public partial class Form2 : Form
    {
        public int id = 0;
        public Form1 form;
        Alumno model = new Alumno();

        public Form2(int id, Form1 frm1)
        {
            this.id = id;
            this.form = frm1;
            InitializeComponent();
        }

        private void LlenaDatos()
        {
            txtCodigo.Text = id.ToString();
            if (id > 0)
            {
                btnEliminar.Visible = false;
                var alumnos = new Alumno();
                alumnos = model.Obtener(id);
                txtNombre.Text = alumnos.Nombre;
                txtApellido.Text = alumnos.Apellido;
                txtFechaNacimiento.Text = alumnos.FechaNacimiento;
                if (alumnos.Sexo == 1)
                {
                    rbMasculino.Checked = true;
                    rbFemenino.Checked = false;
                }
                else
                {
                    rbMasculino.Checked = false;
                    rbFemenino.Checked = true;
                }
            }            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LlenaDatos();
        }

        private void btnGuadar_Click(object sender, EventArgs e)
        {
            var alumno = new Alumno {
                id = id,
                Nombre = txtNombre.Text,
                Apellido=txtApellido.Text,
                FechaNacimiento= txtFechaNacimiento.Text,
                Sexo=rbMasculino.Checked ? 1:0
            };

            model.Guardar(alumno);
            this.form.ListarAlumnos();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea anular este registro?", "Validación", MessageBoxButtons.YesNo) == DialogResult.No) return;
            model.Eliminar(id);
            this.form.ListarAlumnos();
            this.Close();
        }
    }
}
