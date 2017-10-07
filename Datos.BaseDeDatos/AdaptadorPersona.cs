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
                    
                    //if (per.Privilegio == null) per.Privilegio = "invitado";

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

        //public Personas TraerUno(int ID)
        //{
        //    Personas persona = new Personas();
        //    try
        //    {
        //        this.AbrirConexion();
        //        SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_usuario = @id", SqlCon);
        //        cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
        //        SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
        //        if (drPersonas.Read())
        //        {
        //            persona.ID = (int)drPersonas["id_usuario"];
        //            persona.NombreUsuario = (string)drPersonas["nombre_usuario"];
        //            persona.Clave = (string)drPersonas["clave"];
        //            persona.Habilitado = (bool)drPersonas["habilitado"];
        //            persona.Nombre = (string)drPersonas["nombre"];
        //            persona.Apellido = (string)drPersonas["apellido"];
        //            persona.Email = (string)drPersonas["email"];
        //            persona.Privilegio = (string)drPersonas["privilegio"];
        //        }
        //        drPersonas.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al recuperar los datos de la persona", Ex);
        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CerrarConexion();
        //    }
        //    return persona;
        //}

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdPersonas = new SqlCommand("delete personas where id_usuario = @id", SqlCon);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPersonas.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        //public void Actualizar(Personas persona)
        //{
        //    try
        //    {
        //        this.AbrirConexion();
        //        SqlCommand cmdActualizar = new SqlCommand(
        //            "update personas set nombre_usuario = @nombre_usuario, clave = @clave, " +
        //            "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email, privilegio = @privilegio" +
        //            "WHERE id_usuario = @id", SqlCon);

        //        cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
        //        cmdActualizar.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
        //        cmdActualizar.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
        //        cmdActualizar.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;
        //        cmdActualizar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
        //        cmdActualizar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
        //        cmdActualizar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
        //        cmdActualizar.Parameters.Add("@privilegio", SqlDbType.VarChar, 20).Value = persona.Privilegio;

        //        cmdActualizar.ExecuteNonQuery();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
        //       throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CerrarConexion();
        //    }
        //}

        //public void Agregar(Personas persona)
        //{
        //    try
        //    {
        //        this.AbrirConexion();
        //        SqlCommand cmdAgregar = new SqlCommand(
        //            "insert into personas(nombre_usuario, clave, habilitado, nombre, apellido, email, privilegio) " +
        //            "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @privilegio) " +
        //            "select @@identity", SqlCon);

        //        cmdAgregar.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
        //        cmdAgregar.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
        //        cmdAgregar.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;
        //        cmdAgregar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
        //        cmdAgregar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
        //        cmdAgregar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
        //        cmdAgregar.Parameters.Add("@privilegio", SqlDbType.VarChar, 20).Value = persona.Privilegio;

        //        //Obtengo el ID que asignó la BD automáticamente
        //        persona.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CerrarConexion();
        //    }
        //}
    }
}
