using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SimuladorExamenUPN.Servicios
{
    public class UsuarioService: IUsuarioService
    {
        public void GuardarUsuario(string username)
        {
            FormsAuthentication.SetAuthCookie(username, false);
            HttpContext.Current.Session["Usuario"] = new Usuario { Id = 1, Username = "admin" };
        }
    }
}