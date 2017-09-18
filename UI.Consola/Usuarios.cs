using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Entidades;

namespace UI.Consola
{
    public class Usuarios
    {
        Negocio.LogicaUsuario _UsuarioNegocio;

        public Usuarios()
        {
            _UsuarioNegocio = new Negocio.LogicaUsuario();
            //Comentario de prueba
        }

        public LogicaUsuario UsuarioNegocio{get{ return _UsuarioNegocio;} set{ _UsuarioNegocio = value; }}

        public void Menu()
        {
            int rta;
            do
            {
                Console.WriteLine(
                    "1– Listado General\n" +
                    "2– Consulta\n" +
                    "3– Agregar\n" +
                    "4- Modificar\n" +
                    "5- Eliminar\n" +
                    "6- Salir");
                rta = int.Parse(Console.ReadLine());

                switch (rta)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                }

            } while (rta != 6);
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in _UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void Consultar() {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine("\nEl ID ingresado tiene que ser numérico.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine("");
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario que va a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingresá el nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingresá el apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingresá el nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingresá la clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingresá el correo electrónico: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingresá habilitación de usuario (1 - Si / Otro - No ): ");
                usuario.Habilitado = (Console.ReadLine()=="1");
                usuario.State = Entidad.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEl ID ingresado tiene que ser numérico.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            try
            {
                Usuario usuario = new Usuario();

                Console.Clear();
                Console.Write("Ingresá el nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingresá el apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingresá el nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingresá la clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingresá el correo electrónico: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingresá habilitación de usuario (1 - Si / Otro - No ): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = Entidad.States.New;
                UsuarioNegocio.Save(usuario);
                Console.Write("\nID: {0}", usuario.ID);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEl ID ingresado tiene que ser numérico.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingresá el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
                
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEl ID ingresado tiene que ser numérico.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

    }
}
