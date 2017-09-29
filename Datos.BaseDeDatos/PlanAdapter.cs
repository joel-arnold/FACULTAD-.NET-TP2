using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter:Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                                        
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usuario = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usuario.ID = (int)drUsuarios["id_usuario"];
                    usuario.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usuario.Clave = (string)drUsuarios["clave"];
                    usuario.Habilitado = (bool)drUsuarios["habilitado"];
                    usuario.Nombre = (string)drUsuarios["nombre"];
                    usuario.Apellido = (string)drUsuarios["apellido"];
                    usuario.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuario;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete usuarios where id_usuario = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "update usuarios set nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
                    "WHERE id_usuario = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into usuarios(nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                    "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) " +
                    "select @@identity", SqlConn);
                                
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;

                //Obtengo el ID que asignó la BD automáticamente
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Usuario existeUsuario(string nombreUsuario, string clave)
        {
            Usuario usuario = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("select * from usuarios where nombre_usuario = @nombreUsuario and clave = @clave", SqlConn);
                cmdUsuario.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = nombreUsuario;
                cmdUsuario.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
                if (drUsuario.Read())
                {
                    usuario.ID = (int)drUsuario["id_usuario"];
                    usuario.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usuario.Clave = (string)drUsuario["clave"];
                    usuario.Habilitado = (bool)drUsuario["habilitado"];
                    usuario.Nombre = (string)drUsuario["nombre"];
                    usuario.Apellido = (string)drUsuario["apellido"];
                    usuario.Email = (string)drUsuario["email"];
                    usuario.Privilegio = (string)drUsuario["privilegio"];
                }
                else
                {
                    usuario = null;
                }
                drUsuario.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se encontró un usuario con esos datos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuario;
        }
    }
}