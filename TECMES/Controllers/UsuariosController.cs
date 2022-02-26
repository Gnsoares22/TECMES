using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TECMES.Models;

namespace TECMES.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ContextDB _context;

        public UsuariosController(ContextDB context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(string Email, string Senha)
        {
            var buscaUsuario = (from u in _context.Usuario
                                where u.Email == Email && u.Senha == Senha
                                select u).SingleOrDefault();

            if (buscaUsuario == null)
            {
                ViewBag.Erro = "E-mail ou senha incorreto(s)";
                return View("Login");

            }
            else
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("Email", Email,cookie);

                switch (buscaUsuario.Tipo.Trim()) {

                    case "PED":
                        return RedirectToAction("CadastrarPedidos", "Pedidos");
                    case "OP":
                        return RedirectToAction("Pedidos", "OrdemProducao");
                    case "PRO":
                        return RedirectToAction("ListaOrdens", "OrdemProducao");
                    default:
                        break;
                }
              
            }
           
            ViewBag.Erro = "E-mail ou senha incorreto(s)";
            return View("Login");

        }


        public IActionResult Sair()
        {
            //deleta todos cookies armazenados quando efetuado a autenticação

            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }

            return RedirectToAction("Login", "Usuarios");
        }
      
    }
}
