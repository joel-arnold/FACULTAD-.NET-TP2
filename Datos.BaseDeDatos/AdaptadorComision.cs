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
    public class AdaptadorComision : Adaptador
    {
        public List<Comision> TraerTodos()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdComisions = new SqlCommand("select * from comisiones", SqlCon);
                SqlDataReader drComisions = cmdComisions.ExecuteReader();
                while (drComisions.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisions["id_comision"];
                    com.Descripcion = (string)drComisions["desc_comision"];
                    com.AnioEspecialidad = (int)drComisions["anio_especialidad"];
                    com.IDPlan= (int)drComisions["id_plan"];

                    comisiones.Add(com);
                }
                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return comisiones;
        }

        public List<Comision> TraerTodosPorIdPlan(int ID)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdComisions = new SqlCommand("select * from comisiones where id_plan = @id", SqlCon);
                cmdComisions.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisions = cmdComisions.ExecuteReader();
                while (drComisions.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisions["id_comision"];
                    com.Descripcion = (string)drComisions["desc_comision"];
                    com.AnioEspecialidad = (int)drComisions["anio_especialidad"];
                    com.IDPlan = (int)drComisions["id_plan"];

                    comisiones.Add(com);
                }
                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return comisiones;
        }

        public Comision TraerUno(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdComisions = new SqlCommand("select * from comisiones where id_plan = @id", SqlCon);
                cmdComisions.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisions = cmdComisions.ExecuteReader();
                if (drComisions.Read())
                {
                    com.ID = (int)drComisions["id_comision"];
                    com.Descripcion = (string)drComisions["desc_comision"];
                    com.AnioEspecialidad = (int)drComisions["anio_especialidad"];
                    com.IDPlan = (int)drComisions["id_plan"];
                }
                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return com;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdBorrar = new SqlCommand("delete comisiones where id_comision = @id", SqlCon);
                cmdBorrar.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdBorrar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Actualizar(Comision com)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdActualizar = new SqlCommand(
                    "update comisiones set desc_comision = @desc_comision," +
                    "anio_especialidad = @anio_especialidad, id_plan = @id_plan WHERE id_comision = @id", SqlCon);

                cmdActualizar.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdActualizar.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdActualizar.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;

                cmdActualizar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Agregar(Comision com)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into comisiones(desc_comision, hs_semanales, hs_totales, id_plan) " +
                    "values(@desc_comeria, @hs_semanales, @hs_totales, @id_plan) " +
                    "select @@identity", SqlCon);

                cmdAgregar.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdAgregar.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdAgregar.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;

                //Obtengo el ID que asignó la BD automáticamente
                com.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }
    }
}
