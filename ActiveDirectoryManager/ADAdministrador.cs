using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Collections;

namespace ActiveDirectoryManager
{

    /// <summary>
    /// Clase que administra las funciones del Active Directory
    /// </summary>
    class ADAdministrador
    {
        /// <summary>
        /// Dominio
        /// </summary>
        private PrincipalContext _dominio;

        /// <summary>
        /// Inicializa el administrador, conectándose a la máquina local
        /// </summary>
        public ADAdministrador()
        {
            try
            {
                // _dominio = new PrincipalContext(ContextType.Machine, "WINSERVER", "Administrator", "Operativos123");
                _dominio = new PrincipalContext(ContextType.Machine);
            }
            catch (System.Runtime.InteropServices.COMException comex)
            {
                throw comex;
            }
        }

        /// <summary>
        /// Inicializa el administrador, conectándos al servidor con los credenciales dados
        /// </summary>
        /// <param name="nombreServidor">Servidor al que se quiere conectar</param>
        /// <param name="usuario">Nombre del usuario</param>
        /// <param name="contraseña">Contraseña del usuario</param>
        public ADAdministrador(string nombreServidor, string usuario, string contraseña)
        {
            try
            {
                _dominio = new PrincipalContext(ContextType.Machine, nombreServidor, usuario, contraseña);
            }
            catch (System.Runtime.InteropServices.COMException comex)
            {
                throw comex;
            }
        }

        #region Grupos

        public List<GroupPrincipal> ObtenerGrupos()
        {
            List<GroupPrincipal> resultado = new List<GroupPrincipal>();

            GroupPrincipal grupo = new GroupPrincipal(_dominio);
            grupo.Name = "*";
            PrincipalSearcher buscador = new PrincipalSearcher();
            buscador.QueryFilter = grupo;
            PrincipalSearchResult<Principal> resultados = buscador.FindAll();
            foreach (Principal p in resultados)
            {
                resultado.Add((GroupPrincipal)p);
            }

            return resultado;
        }

        /// <summary>
        /// Agrega un grupo dados su nombre y descripción
        /// </summary>
        /// <param name="nombre">Nombre del grupo</param>
        /// <param name="descripción">Descripción del grupo</param>
        public void AgregarGrupo(string nombre, string descripción)
        {
            GroupPrincipal nuevoGrupo = new GroupPrincipal(_dominio);

            nuevoGrupo.Name = nombre;
            nuevoGrupo.Description = descripción;

            nuevoGrupo.Save();
            nuevoGrupo.Dispose();
        }

        /// <summary>
        /// Edita la información de un grupo
        /// </summary>
        /// <param name="grupo">Grupo que se quiere editar</param>
        /// <param name="descripción">Nueva descripción</param>
        public void EditarGrupo(GroupPrincipal grupo, string descripción)
        {
            grupo.Description = descripción;
            grupo.Save();
        }

        /// <summary>
        /// Busca un grupo por su nombre
        /// </summary>
        /// <param name="nombre">Nombre del grupo</param>
        /// <returns>Grupo encontrado</returns>
        public GroupPrincipal BuscarGrupo(string nombre)
        {
            GroupPrincipal grupo = new GroupPrincipal(_dominio);
            grupo.Name = nombre.Replace("$", "*");
            PrincipalSearcher buscador = new PrincipalSearcher();
            buscador.QueryFilter = grupo;
            Principal resultado = buscador.FindOne();
            return (GroupPrincipal)resultado;
        }

        /// <summary>
        /// Retorna una lista con los miembros de un grupo dado
        /// </summary>
        /// <param name="grupo">Grupo cuyos miembros se quieren encontrar</param>
        /// <returns></returns>
        public List<UserPrincipal> MiembrosDelGrupo(GroupPrincipal grupo)
        {
            List<UserPrincipal> resultado = new List<UserPrincipal>();
            foreach (Principal p in grupo.Members)
            {
                if (p is UserPrincipal)
                    resultado.Add((UserPrincipal)p);
            }
            return resultado;
        }

        /// <summary>
        /// Busca los miembros de un grupo dado
        /// </summary>
        /// <param name="nombre">Nombre del grupo cuyos miembros se quieren buscar</param>
        /// <returns></returns>
        public List<UserPrincipal> MiembrosDelGrupo(string nombre)
        {
            GroupPrincipal grupo = BuscarGrupo(nombre);
            if (grupo != null)
                return MiembrosDelGrupo(grupo);
            else
                return null;
        }

        /// <summary>
        /// Elimina un grupo
        /// </summary>
        /// <param name="grupo">Grupo a eliminar</param>
        public void EliminarGrupo(GroupPrincipal grupo)
        {
            grupo.Delete();
        }

        /// <summary>
        /// Elimina un grupo
        /// </summary>
        /// <param name="nombre">Nombre del grupo a eliminar</param>
        public void EliminarGrupo(string nombre)
        {
            GroupPrincipal grupo = BuscarGrupo(nombre);
            if (grupo != null)
            {
                grupo.Delete();
            }
        }
        #endregion

        #region Usuarios

        /// <summary>
        /// Agrega un nuevo usuario
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="contraseña">Contraseña</param>
        /// <param name="descripción">Descripción de usuario</param>
        public void AgregarUsuario(string nombre, string contraseña, string descripción)
        {
            UserPrincipal nuevoUsuario = new UserPrincipal(_dominio);

            nuevoUsuario.Name = nombre;
            nuevoUsuario.SetPassword(contraseña);
            nuevoUsuario.Description = descripción;

            nuevoUsuario.Save();
            nuevoUsuario.Dispose();
        }

        /// <summary>
        /// Edita la información de un usuario
        /// </summary>
        /// <param name="usuario">Usuario que se quiere editar</param>
        /// <param name="nombre">Nuevo nombre</param>
        /// <param name="descripción">Nueva descripción</param>
        public void EditarUsuario(UserPrincipal usuario, string descripción)
        {
            usuario.Description = descripción;
            usuario.Save();
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en el directorio
        /// </summary>
        /// <returns>Todos los usuarios</returns>
        public List<UserPrincipal> ObtenerUsuarios()
        {
            List<UserPrincipal> resultado = new List<UserPrincipal>();

            UserPrincipal usuario = new UserPrincipal(_dominio);
            usuario.Name = "*";
            PrincipalSearcher buscador = new PrincipalSearcher();
            buscador.QueryFilter = usuario;
            PrincipalSearchResult<Principal> resultados = buscador.FindAll();
            foreach (Principal p in resultados)
            {
                if (p is UserPrincipal)
                    resultado.Add((UserPrincipal)p);
            }

            return resultado;
        }

        /// <summary>
        /// Busca un usuario a partir de su nombre
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <returns>Usuario encontrado</returns>
        public UserPrincipal BuscarUsuario(string nombre)
        {
            UserPrincipal usuario = new UserPrincipal(_dominio);
            //UserPrincipal usuario = UserPrincipal.FindByIdentity(_dominio, IdentityType.Name, nombre);
            usuario.Name = nombre.Replace("$","*");
            PrincipalSearcher buscador = new PrincipalSearcher();
            buscador.QueryFilter = usuario;
            Principal resultado = buscador.FindOne();

            return (UserPrincipal)resultado;
            //return usuario;
        }

        /// <summary>
        /// Agrega un usuario a un grupo
        /// </summary>
        /// <param name="usuario">Usuario que se quiere agregar</param>
        /// <param name="grupo">Grupo al que se quiere agregar</param>
        public void AgregarUsuarioAGrupo(UserPrincipal usuario, GroupPrincipal grupo)
        {
            if (!grupo.Members.Contains(usuario))
            {
                grupo.Members.Add(usuario);
                grupo.Save();
            }
        }

        /// <summary>
        /// Agrega un usuario a un grupo
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario que se quiere agregar</param>
        /// <param name="nombreGrupo">Nombre del grupo al que se quiere agregar</param>
        public void AgregarUsuarioAGrupo(string nombreUsuario, string nombreGrupo)
        {
            UserPrincipal usuario = BuscarUsuario(nombreUsuario);
            GroupPrincipal grupo = BuscarGrupo(nombreGrupo);
            if (usuario != null && grupo != null)
                AgregarUsuarioAGrupo(usuario, grupo);
        }

        /// <summary>
        /// Elimina un usuario de un grupo
        /// </summary>
        /// <param name="usuario">Usuario que se quiere eliminar del grupo</param>
        /// <param name="grupo">Grupo del que se desea eliminar el usuario</param>
        public void EliminarUsuarioDeGrupo(UserPrincipal usuario, GroupPrincipal grupo)
        {
            if (grupo.Members.Contains(usuario))
            {
                grupo.Members.Remove(usuario);
                grupo.Save();
            }
        }

        /// <summary>
        /// Elimina un usuario de un grupo
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario que se quiere eliminar del grupo</param>
        /// <param name="nombreGrupo">Nombre del grupo del que se quiere eliminar el usuario</param>
        public void EliminarUsuarioDeGrupo(string nombreUsuario, string nombreGrupo)
        {
            UserPrincipal usuario = BuscarUsuario(nombreUsuario);
            GroupPrincipal grupo = BuscarGrupo(nombreGrupo);
            if (usuario != null && grupo != null)
                EliminarUsuarioDeGrupo(usuario, grupo);
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="usuario">Usuario a eliminar</param>
        public void EliminarUsuario(UserPrincipal usuario)
        {
            usuario.Delete();
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="nombre">Nombre del usuario que se quiere eliminar</param>
        public void EliminarUsuario(string nombre)
        {
            UserPrincipal usuario = BuscarUsuario(nombre);
            if (usuario != null)
                EliminarUsuario(usuario);
        }

        /// <summary>
        /// Autentifica un usuario mediante su nombre y contraseña
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="contraseña">Contraseña del usuario</param>
        /// <returns>Verdadero si se pudo autentificar con el servidor, falso de otra forma</returns>
        public bool AutentificarUsuario(string nombre, string contraseña)
        {
            return _dominio.ValidateCredentials(nombre, contraseña);
        }

        /// <summary>
        /// Establece la contraseña para un usuario
        /// </summary>
        /// <param name="usuario">Usuario al que se le cambiará la contraseña</param>
        /// <param name="contraseña">Contraseña que se quiere asignar</param>
        public void EstablecerContraseña(UserPrincipal usuario, string contraseña)
        {
            usuario.SetPassword(contraseña);
            usuario.Save();
        }

        /// <summary>
        /// Establece la contraseña para un usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario al que se le cambiará la contraseña</param>
        /// <param name="contraseña">Contraseña que se quiere asignar</param>
        public void EstablecerContraseña(string nombreUsuario, string contraseña)
        {
            UserPrincipal usuario = BuscarUsuario(nombreUsuario);
            if (usuario != null)
                EstablecerContraseña(usuario, contraseña);
        }

        /// <summary>
        /// Habilita un usuario
        /// </summary>
        /// <param name="usuario">Usuario que se quiere habilitar</param>
        public void HabilitarUsuario(UserPrincipal usuario)
        {
            usuario.Enabled = true;
            usuario.UnlockAccount();
            usuario.Save();
        }

        /// <summary>
        /// Habilita un usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario que se quiere habilitar</param>
        public void HabilitarUsuario(string nombreUsuario)
        {
            UserPrincipal usuario = BuscarUsuario(nombreUsuario);
            if (usuario != null)
                HabilitarUsuario(usuario);
        }

        #endregion
    }
}
