using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AdaptadorPlan:Adaptador
    {
        public List<Plan> TraerTodos()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes", SqlCon);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan pl = new Plan();
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IdEspecialidad= (int)drPlanes["id_especialidad"];
                                        
                    planes.Add(pl);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return planes;
        }

        public Plan TraerUno(int ID)
        {
            Plan pl = new Plan();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan = @id", SqlCon);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IdEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return pl;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdBorrar =
                    new SqlCommand("delete planes where id_plan = @id", SqlCon);
                cmdBorrar.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdBorrar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Actualizar(Plan plan)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdActualizar = new SqlCommand(
                    "update planes set desc_plan = @desc_plan, id_especialidad = @id_especialidad," +
                    "WHERE id_plan = @id", SqlCon);

                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdActualizar.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdActualizar.Parameters.Add("@id_especialidad", SqlDbType.Int, 50).Value = plan.IdEspecialidad;

                cmdActualizar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Agregar(Plan plan)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into planes(desc_plan, id_especialidad) " +
                    "values(@desc_plan, @id_especialidad) " +
                    "select @@identity", SqlCon);

                cmdAgregar.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdAgregar.Parameters.Add("@id_especialidad", SqlDbType.Int, 50).Value = plan.IdEspecialidad;

                //Obtengo el ID que asignó la BD automáticamente
                plan.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        } 
    }
}
