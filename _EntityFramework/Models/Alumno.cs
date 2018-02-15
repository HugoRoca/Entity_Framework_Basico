namespace _EntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        public int Sexo { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaNacimiento { get; set; }

        // creando m�todo listar
        public  List<Alumno> Listar()
        {
            var alumnos = new List<Alumno>();
            try
            {
                using (var ctx = new TestContext())
                {
                    alumnos = ctx.Alumno.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }

        // creando metodo guardar
        public void Guardar(Alumno alumno)
        {
            try
            {
                using (var ctx = new TestContext())
                {
                    /* registro que ya existe*/
                    if(alumno.id > 0)
                    {
                        ctx.Entry(alumno).State = EntityState.Modified;
                    }else
                    {
                        ctx.Entry(alumno).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var ctx = new TestContext())
                {
                    ctx.Entry(new Alumno { id = id }).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Alumno Obtener(int id)
        {
            var alumno = new Alumno();
            try
            {
                using (var ctx = new TestContext())
                {
                    alumno = ctx.Alumno.Where(x => x.id == id).SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumno;
        }

    }
}
