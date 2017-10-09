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
    public class AdaptadorPersona : Adaptador
    {
        public List<Personas> TraerTodos()
        {
            List<Personas> personas = new List<Personas>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlCon);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Personas per = new Personas();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            per.Tipo= Personas.TipoPersona.Alumno;
                            break;
                        case 2:
                            per.Tipo = Personas.TipoPersona.Profesor;
                            break;
                        case 3:
                            per.Tipo = Personas.TipoPersona.Administrativo;
                            break;
                    }
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return personas;
        }

        public Personas TraerUno(int ID)
        {
            Personas persona = new Personas();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", SqlCon);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            persona.Tipo = Personas.TipoPersona.Alumno;
                            break;
                        case 2:
                            persona.Tipo = Personas.TipoPersona.Profesor;
                            break;
                        case 3:
                            persona.Tipo = Personas.TipoPersona.Administrativo;
                            break;
                    }
                    persona.IDPlan = (int)drPersonas["id_plan"];
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
            return persona;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdPersonas = new SqlCommand("delete personas where id_persona = @id", SqlCon);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPersonas.ExecuteNonQuery();
            }
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al eliminar la persona", Ex);
            //    throw ExcepcionManejada;
            //}
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Actualizar(Personas persona)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdActualizar = new SqlCommand(
                    "update personas set nombre = @nombre, apellido = @apellido, " +
                    "direccion = @direccion, email = @email, telefono = @telefono, " +
                    "fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona = @tipo_persona, " +
                    "id_plan = @id_plan WHERE id_persona = @id", SqlCon);

                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdActualizar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdActualizar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdActualizar.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdActualizar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdActualizar.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                if (persona.FechaNacimiento == null)
                {
                    cmdActualizar.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = DateTime.Now;
                }
                else
                {
                    cmdActualizar.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = persona.FechaNacimiento;
                }
                cmdActualizar.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                int tipo = 0;
                switch (persona.Tipo)
                {
                    case Personas.TipoPersona.Alumno:
                        tipo = 1;
                        break;
                    case Personas.TipoPersona.Profesor:
                        tipo = 2;
                        break;
                    case Personas.TipoPersona.Administrativo:
                        tipo = 3;
                        break;
                }
                cmdActualizar.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.Tipo;
                cmdActualizar.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                cmdActualizar.ExecuteNonQuery();
            }
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
            //    throw ExcepcionManejada;
            //}
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Agregar(Personas persona)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                    "values(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
                    "select @@identity", SqlCon);

                cmdAgregar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdAgregar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdAgregar.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdAgregar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdAgregar.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdAgregar.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdAgregar.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                int tipo = 0;
                switch (persona.Tipo)
                {
                    case Personas.TipoPersona.Alumno:
                        tipo = 1;
                        break;
                    case Personas.TipoPersona.Profesor:
                        tipo = 2;
                        break;
                    case Personas.TipoPersona.Administrativo:
                        tipo = 3;
                        break;
                }
                cmdAgregar.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                //Obtengo el ID que asignó la BD automáticamente
                persona.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }
    }
}
