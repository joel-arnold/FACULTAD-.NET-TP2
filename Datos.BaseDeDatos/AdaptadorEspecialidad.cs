using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AdaptadorEspecialidad:Adaptador
    {
        public List<Especialidad> TraerTodos()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", SqlCon);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                                        
                    especialidades.Add(esp);
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return especialidades;
        }

        public Especialidad TraerUno(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad = @id", SqlCon);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return esp;
        }

        public void Borrar(int ID)
        {
            
        }

        public void Actualizar(Especialidad esp)
        {
            
        }

        public void Agregar(Especialidad esp)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into especialidades(desc_especialidad) " +
                    "values(@desc_especialidad) " +
                    "select @@identity", SqlCon);

                cmdAgregar.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.Descripcion;

                //Obtengo el ID que asignó la BD automáticamente
                esp.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

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