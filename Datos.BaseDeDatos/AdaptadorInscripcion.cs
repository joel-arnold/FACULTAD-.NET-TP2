using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class AdaptadorInscripcion : Adaptador
    {
        public List<AlumnoInscripciones> TraerTodos(int IDCurso)
        {
            List<AlumnoInscripciones> alumnoInscripciones = new List<AlumnoInscripciones>();
            try
            {
                AbrirConexion();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones", SqlCon);
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();
                while (drAlumnoInscripcion.Read())
                {
                    AlumnoInscripciones alumnoInscripcion = new AlumnoInscripciones();
                    alumnoInscripcion.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    alumnoInscripcion.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    if (drAlumnoInscripcion["nota"] != DBNull.Value)
                    {
                        alumnoInscripcion.Nota = (int)drAlumnoInscripcion["nota"];
                    }
                    alumnoInscripcion.Condicion = (string)drAlumnoInscripcion["condicion"];
                    alumnoInscripciones.Add(alumnoInscripcion);
                }
                drAlumnoInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CerrarConexion();
            }
            return alumnoInscripciones;
        }

        public List<AlumnoInscripciones> TraerTodosPorIdPersona(int IdPersona)
        {
            List<AlumnoInscripciones> alumnoInscripciones = new List<AlumnoInscripciones>();
            try
            {
                AbrirConexion();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno = @id_alumno", SqlCon);
                cmdAlumnoInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IdPersona;
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();
                while (drAlumnoInscripcion.Read())
                {
                    AlumnoInscripciones alumnoInscripcion = new AlumnoInscripciones();
                    alumnoInscripcion.ID = (int)drAlumnoInscripcion["id_inscripcion"];
                    alumnoInscripcion.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    alumnoInscripcion.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    if (drAlumnoInscripcion["nota"] != DBNull.Value)
                    {
                        alumnoInscripcion.Nota = (int)drAlumnoInscripcion["nota"];
                    }
                    alumnoInscripcion.Condicion = (string)drAlumnoInscripcion["condicion"];
                    alumnoInscripciones.Add(alumnoInscripcion);
                }
                drAlumnoInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CerrarConexion();
            }
            return alumnoInscripciones;
        }

        public AlumnoInscripciones TraerUno(int ID)
        {
            AlumnoInscripciones inscripcion = new AlumnoInscripciones();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", SqlCon);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                if (drInscripciones.Read())
                {
                    inscripcion.ID = (int)drInscripciones["id_inscripcion"];
                    inscripcion.IDCurso = (int)drInscripciones["id_curso"];
                    inscripcion.IDAlumno = (int)drInscripciones["id_alumno"];
                    inscripcion.Condicion = (string)drInscripciones["condicion"];
                    if (drInscripciones["nota"] != DBNull.Value)
                    {
                        inscripcion.Nota = (int)drInscripciones["nota"];
                    }
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return inscripcion;
        }

        public AlumnoInscripciones TraerUno(int IDAlumno, int IDCurso)
        {
            AlumnoInscripciones alumnoInscripcion = new AlumnoInscripciones();
            try
            {
                AbrirConexion();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("GetInscripcion", SqlCon);
                cmdAlumnoInscripcion.CommandType = CommandType.StoredProcedure;
                cmdAlumnoInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = IDAlumno;
                cmdAlumnoInscripcion.Parameters.Add("@idCurso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();
                if (drAlumnoInscripcion.Read())
                {
                    alumnoInscripcion.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    alumnoInscripcion.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    if (drAlumnoInscripcion["nota"] != DBNull.Value)
                    {
                        alumnoInscripcion.Nota = (int)drAlumnoInscripcion["nota"];
                    }
                    alumnoInscripcion.Condicion = (string)drAlumnoInscripcion["condicion"];
                }
                drAlumnoInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CerrarConexion();
            }
            return alumnoInscripcion;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdInscripciones = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @id", SqlCon);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdInscripciones.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Borrar(int IDAlumno, int IDCurso)
        {
            try
            {
                AbrirConexion();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("BajaInscripcion", SqlCon);
                cmdAlumnoInscripcion.CommandType = CommandType.StoredProcedure;
                cmdAlumnoInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = IDAlumno;
                cmdAlumnoInscripcion.Parameters.Add("@idCurso", SqlDbType.Int).Value = IDCurso;
                cmdAlumnoInscripcion.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void Actualizar(AlumnoInscripciones inscripcion)
        {
            try
            {
                AbrirConexion();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("UPDATE alumnos_inscripciones SET condicion=@condicion, " +
                    "nota=@nota WHERE id_alumno=@idAlumno AND id_curso=@idCurso", SqlCon);
                cmdAlumnoInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdAlumnoInscripcion.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscripcion.IDCurso;
                if (inscripcion.Nota <= 0)
                {
                    cmdAlumnoInscripcion.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                }
                else
                {
                    cmdAlumnoInscripcion.Parameters.Add("@nota", SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                cmdAlumnoInscripcion.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdAlumnoInscripcion.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void Agregar(AlumnoInscripciones inscripcion)
        {
            try
            {
                AbrirConexion();
                SqlCommand cmdInsertarInscripcion = new SqlCommand("INSERT INTO alumnos_inscripciones" +
                    "(id_alumno,id_curso, condicion) VALUES(@idAlumno, @idCurso, @condicion)", SqlCon);
                cmdInsertarInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdInsertarInscripcion.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdInsertarInscripcion.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdInsertarInscripcion.ExecuteNonQuery();
                SqlCommand cmdActualizarCupo = new SqlCommand("UPDATE cursos SET cupo = cupo - 1" +
                    " WHERE id_curso=@idCurso", SqlCon);
                cmdActualizarCupo.Parameters.Add("@idCurso", SqlDbType.VarChar, 50).Value = inscripcion.IDCurso;
                cmdActualizarCupo.ExecuteNonQuery();
            }
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al generar la inscripcion", Ex);
            //    throw ExcepcionManejada;
            //}
            finally
            {
                CerrarConexion();
            }
        }

        public void Guardar(AlumnoInscripciones inscripcion)
        {
            switch (inscripcion.Estado)
            {
                case Entidad.Estados.Borrado:
                    Borrar(inscripcion.IDAlumno, inscripcion.IDCurso);
                    break;
                case Entidad.Estados.Modificado:
                    Actualizar(inscripcion);
                    break;
                case Entidad.Estados.Nuevo:
                    Agregar(inscripcion);
                    break;
            }
        }


    }
}
