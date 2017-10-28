using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Data.Database
{
    public class AdaptadorDocenteCurso : Adaptador
    {
        public List<DocenteCurso> TraerTodos()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos", SqlCon);
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                while (drDocenteCurso.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Cargo = (int)drDocenteCurso["cargo"];

                    docentesCursos.Add(dc);
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes y cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return docentesCursos;
        }

        public List<DocenteCurso> TraerTodos(int idProfesor)
        {
            List<DocenteCurso> docenteCurso = new List<DocenteCurso>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * " +
                    "from docentes_cursos WHERE id_docente = @id_docente", SqlCon);
                cmdDocenteCurso.Parameters.Add("@id_docente", SqlDbType.Int).Value = idProfesor;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                while (drDocenteCurso.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Cargo = (int)drDocenteCurso["cargo"];

                    docenteCurso.Add(dc);
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes y cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return docenteCurso;
        }

        public DocenteCurso TraerUno(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos where id_dictado = @id", SqlCon);
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Cargo = (int)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de docentes-cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return dc;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdBorrar = new SqlCommand("delete docentes_cursos where id_dictado = @id", SqlCon);
                cmdBorrar.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdBorrar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la relación docente-curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Actualizar(DocenteCurso dc)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdActualizar = new SqlCommand("update docentes_cursos " +
                    "set id_curso = @id_curso, id_docente = @id_docente, " +
                    "cargo = @cargo WHERE id_dictado = @id", SqlCon);

                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdActualizar.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdActualizar.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.IDDocente;
                cmdActualizar.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;

                cmdActualizar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Agregar(DocenteCurso dc)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into docentes_cursos(id_curso, id_docente, cargo) " +
                    "values(@id_curso, @id_docente, @cargo) " +
                    "select @@identity", SqlCon);

                cmdAgregar.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdAgregar.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdAgregar.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.IDDocente;
                cmdAgregar.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;

                //Obtengo el ID que asignó la BD automáticamente
                dc.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al relacionar curso y docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }
    }
}
