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
    public class AdaptadorMateria : Adaptador
    {
        public List<Materia> TraerTodos()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias", SqlCon);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan= (int)drMaterias["id_plan"];

                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return materias;
        }

        public List<Materia> TraerTodosPorIdPlan(int ID)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_plan = @id", SqlCon);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return materias;
        }

        public Materia TraerUno(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia = @id", SqlCon);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return mat;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdBorrar = new SqlCommand("delete materias where id_materia = @id", SqlCon);
                cmdBorrar.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdBorrar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Actualizar(Materia mat)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdActualizar = new SqlCommand(
                    "update materias set desc_materia = @desc_materia, hs_semanales = @hs_semanales, " +
                    "hs_totales = @hs_totales, id_plan = @id_plan WHERE id_materia = @id", SqlCon);

                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdActualizar.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdActualizar.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdActualizar.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdActualizar.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;

                cmdActualizar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Agregar(Materia mat)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into materias(desc_materia, hs_semanales, hs_totales, id_plan) " +
                    "values(@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                    "select @@identity", SqlCon);

                cmdAgregar.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdAgregar.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdAgregar.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdAgregar.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;

                //Obtengo el ID que asignó la BD automáticamente
                mat.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }
    }
}
