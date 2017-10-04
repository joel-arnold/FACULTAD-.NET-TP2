using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    class AdaptadorInscripcion
    {
        //public List<AlumnoInscripcion> GetAll(int IdCurso)
        //{
        //    List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
        //    try
        //    {
        //        OpenConnection();
        //        SqlCommand cmdAlumnoInscripcion = new SqlCommand("GetAlumnos", sqlConn);
        //        cmdAlumnoInscripcion.CommandType = CommandType.StoredProcedure;
        //        cmdAlumnoInscripcion.Parameters.Add("@idCurso", SqlDbType.Int).Value = IdCurso;
        //        SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();
        //        while (drAlumnoInscripcion.Read())
        //        {
        //            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
        //            alumnoInscripcion.IdAlumno = (int)drAlumnoInscripcion["id_alumno"];
        //            alumnoInscripcion.IdCurso = (int)drAlumnoInscripcion["id_curso"];
        //            if (drAlumnoInscripcion["nota"] != DBNull.Value)
        //            {
        //                alumnoInscripcion.Nota = (int)drAlumnoInscripcion["nota"];
        //            }
        //            alumnoInscripcion.Condicion = (string)drAlumnoInscripcion["condicion"];
        //            alumnoInscripciones.Add(alumnoInscripcion);
        //        }
        //        drAlumnoInscripcion.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones", Ex);
        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //    return alumnoInscripciones;
        //}
    }
}
