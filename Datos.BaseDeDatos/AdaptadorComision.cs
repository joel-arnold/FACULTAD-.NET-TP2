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

        public List<Comision> TraerComisiones(int idMateria, int anio)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdComisiones = new SqlCommand("SELECT co.id_comision, co.desc_comision, co.anio_especialidad, co.id_plan " +
                                                        "FROM comisiones co " +
                                                        "INNER JOIN cursos cu " +
                                                        "ON co.id_comision = cu.id_comision " +
                                                        "where cu.id_materia = @id_materia and cu.anio_calendario=@anio", SqlCon);
                cmdComisiones.Parameters.Add("@id_materia", SqlDbType.Int).Value = idMateria;
                cmdComisiones.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision comision = new Comision();
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];

                    comisiones.Add(comision);
                }
                drComisiones.Close();
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
                SqlCommand cmdComision = new SqlCommand("select * from comisiones where id_comision = @id", SqlCon);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComision.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
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

                SqlCommand cmdActualizar = new SqlCommand("update comisiones " +
                "set desc_comision = @desc_comision, anio_especialidad = @anio_especialidad " +
                "id_plan = @id_plan WHERE id_comision = @id", SqlCon);

                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
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
                    "insert into comisiones(desc_comision, anio_especialidad, id_plan) " +
                    "values(@desc_comision, @anio_especialidad, @id_plan) " +
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