using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AdaptadorCurso:Adaptador
    {
        public List<Curso> TraerTodos()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", SqlCon);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cu = new Curso();
                    cu.ID = (int)drCursos["id_curso"];
                    cu.IDMateria = (int)drCursos["id_materia"];
                    cu.IDComision = (int)drCursos["id_comision"];
                    cu.AnioCalendario = (int)drCursos["anio_calendario"];
                    cu.Cupo = (int)drCursos["cupo"];
                                        
                    cursos.Add(cu);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return cursos;
        }

        public List<Comision> TraerComisiones(int idMateria)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdComisiones = new SqlCommand("SELECT co.id_comision, co.desc_comision " + 
                                                        "FROM comisiones co " +
                                                        "INNER JOIN cursos cu " +
                                                        "ON co.id_comision = cu.id_comision " +
                                                        "where cu.id_materia = @id_materia", SqlCon);
                cmdComisiones.Parameters.Add("@id_materia", SqlDbType.Int).Value = idMateria;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision comision = new Comision();
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];

                    comisiones.Add(comision);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return comisiones;
        }

        public Curso TraerUno(int ID)
        {
            Curso cu = new Curso();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", SqlCon);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cu.ID = (int)drCursos["id_curso"];
                    cu.IDMateria = (int)drCursos["id_materia"];
                    cu.IDComision = (int)drCursos["id_comision"];
                    cu.AnioCalendario = (int)drCursos["anio_calendario"];
                    cu.Cupo = (int)drCursos["cupo"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return cu;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdBorrar =
                    new SqlCommand("delete cursos where id_curso = @id", SqlCon);
                cmdBorrar.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdBorrar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Actualizar(Curso curso)
        {
            //falta desarrollo
        }

        public void Agregar(Curso curso)
        {
            //falta desarrollo
        } 
    }
}
