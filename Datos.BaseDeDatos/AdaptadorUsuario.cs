using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AdaptadorUsuario:Adaptador
    {
        public List<Usuario> TraerTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlCon);
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
                    usr.Privilegio = (string)drUsuarios["privilegio"];
                    if (drUsuarios["id_persona"] != DBNull.Value)
                    {
                        usr.IDPersona = (int)drUsuarios["id_persona"];
                    }
                    else
                    {
                        usr.IDPersona = 99;
                    }
                    if (usr.Privilegio == null) usr.Privilegio = "invitado";
                                        
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
            //    throw ExcepcionManejada;
            //}
            finally
            {
                this.CerrarConexion();
            }
            return usuarios;
        }

        public Usuario TraerUno(int ID)
        {
            Usuario usuario = new Usuario();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlCon);
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
                    if (drUsuarios["id_persona"] != DBNull.Value)
                    {
                        usuario.IDPersona = (int)drUsuarios["id_persona"];
                    }
                    else
                    {
                        usuario.IDPersona = 99;
                    }
                    usuario.Privilegio = (string)drUsuarios["privilegio"];
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
                this.CerrarConexion();
            }
            return usuario;
        }

        public void Borrar(int ID)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdUsuarios = new SqlCommand("delete usuarios where id_usuario = @id", SqlCon);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdUsuarios.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Actualizar(Usuario usuario)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdActualizar = new SqlCommand(
                    "update usuarios set nombre_usuario = @nombre_usuario, clave = @clave, id_persona = @id_persona, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email, privilegio = @privilegio " +
                    "WHERE id_usuario = @id", SqlCon);

                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdActualizar.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdActualizar.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdActualizar.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdActualizar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdActualizar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdActualizar.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                cmdActualizar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                if (usuario.Privilegio != null)
                {
                    cmdActualizar.Parameters.Add("@privilegio", SqlDbType.VarChar, 20).Value = usuario.Privilegio;
                }
                else
                {
                    cmdActualizar.Parameters.Add("@privilegio", SqlDbType.VarChar, 20).Value = "invitado";
                }

               cmdActualizar.ExecuteNonQuery();
            }
            /*catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
               throw ExcepcionManejada;
            }*/
            finally
            {
                this.CerrarConexion();
            }
        }

        public void Agregar(Usuario usuario)
        {
            try
            {
                this.AbrirConexion();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into usuarios(nombre_usuario, clave, habilitado, nombre, apellido, email, privilegio, id_persona) " +
                    "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @privilegio, @id_persona) " +
                    "select @@identity", SqlCon);
                                
                cmdAgregar.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdAgregar.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdAgregar.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdAgregar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdAgregar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdAgregar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdAgregar.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                if (usuario.Privilegio != null)
                {
                    cmdAgregar.Parameters.Add("@privilegio", SqlDbType.VarChar, 20).Value = usuario.Privilegio;
                }
                else
                {
                    cmdAgregar.Parameters.Add("@privilegio", SqlDbType.VarChar, 20).Value = "invitado";
                }
                

                //Obtengo el ID que asignó la BD automáticamente
                usuario.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());
                
            }
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al crear el usuario", Ex);
            //    throw ExcepcionManejada;
            //}
            finally
            {
                this.CerrarConexion();
            }
        }

        public Usuario existeUsuario(string nombreUsuario, string clave)
        {
            Usuario usuario = new Usuario();
            try
            {
                this.AbrirConexion();
                SqlCommand cmdUsuario = new SqlCommand("select * from usuarios where nombre_usuario = @nombreUsuario and clave = @clave", SqlCon);
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
                    usuario.IDPersona = (int)drUsuario["id_persona"];
                    usuario.Privilegio = (string)drUsuario["privilegio"];
                }
                else
                {
                    usuario = null;
                }
                drUsuario.Close();
            }
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("No se encontró un usuario con esos datos", Ex);
            //    throw ExcepcionManejada;
            //}
            finally
            {
                this.CerrarConexion();
            }
            return usuario;
        }
    }
}