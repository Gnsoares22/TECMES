using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TECMES.Models;

namespace TECMES.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ContextDB _context;

        public PedidosController(ContextDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Faturamento()
        {
            //No Faturamento lista os pedidos liberados (porem para fechar a venda ele deve seguir os critérios de validações feitos no metódo "Faturar" na controller OrdemProducao )
            var contextDB = _context.Pedido.Include(p => p.cliente).Include(op => op.ordemProducao).Include(p => p.produto);
            return View(await contextDB.Where(c =>  _context.OrdemProducao.Any(op => op.PedidoID == c.Id && op.StatusID != 2)).ToListAsync());
        }


        public IActionResult CadastrarPedidos()
        {
            ViewData["ClienteID"] = new SelectList(_context.Set<Cliente>(), "Id", "Nome");
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarPedidos([Bind("Id,ProdutoID,ClienteID,Quantidade,Descricao")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                //Para criar adicionar a descrição do pedido concateno o nome do cliente + produto (simulação prova)

                var cliente = _context.Cliente.Where(cli => cli.Id == pedido.ClienteID).FirstOrDefault();
                var Produto = _context.Produto.Where(pro => pro.Id == pedido.ProdutoID).FirstOrDefault();


                pedido.Descricao = "Pedido # - " + cliente.Nome + " - Produto: " + Produto.Nome ;
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                ViewBag.Success = "Pedido criado com sucesso";
            }
            ViewData["ClienteID"] = new SelectList(_context.Set<Cliente>(), "Id", "Nome", pedido.ClienteID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome", pedido.ProdutoID);
            return View("CadastrarPedidos", pedido);
        }

       
    }
}
