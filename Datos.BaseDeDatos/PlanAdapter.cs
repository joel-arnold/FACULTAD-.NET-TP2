using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter:Adaptador
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes", SqlConn);
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
                this.CloseConnection();
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan pl = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan = @id", SqlConn);
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
                this.CloseConnection();
            }
            return pl;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete planes where id_plan = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "update planes set desc_plan = @desc_plan, id_especialidad = @id_especialidad," +
                    "WHERE id_plan = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int, 50).Value = plan.IdEspecialidad;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into planes(desc_plan, id_especialidad) " +
                    "values(@desc_plan, @id_especialidad) " +
                    "select @@identity", SqlConn);

                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int, 50).Value = plan.IdEspecialidad;

                //Obtengo el ID que asignó la BD automáticamente
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        } 
    }
}
