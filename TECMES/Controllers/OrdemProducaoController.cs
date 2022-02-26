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
    public class OrdemProducaoController : Controller
    {
        private readonly ContextDB _context;

        public OrdemProducaoController(ContextDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Pedidos()
        {
            var contextDB = _context.OrdemProducao.Include(o => o.maquinas).Include(o => o.pedido).Include(o => o.produtos).Include(o => o.status);
            return View(await contextDB.ToListAsync());
        }

        public async Task<IActionResult> ListaOrdens()
        {
            var contextDB = _context.OrdemProducao.Include(o => o.maquinas).Include(o => o.pedido).Include(o => o.produtos).Include(o => o.status);
            return View(await contextDB.ToListAsync());
        } 

        
        public IActionResult CriarOrdem()
        {
            ViewData["MaquinaID"] = new SelectList(_context.Maquina, "Id", "Nome");
            ViewData["PedidoID"] = new SelectList(_context.Pedido.Where(ped => !_context.OrdemProducao.Any(op => op.PedidoID == ped.Id)), "Id", "Descricao");
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome");
            ViewData["StatusID"] = new SelectList(_context.OrdemProducaoStatus, "Id", "Status");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarOrdem([Bind("Id,quantidade,Prazo,ProdutoID,StatusID,MaquinaID,PedidoID")] OrdemProducao ordemProducao)
        {
            if (ordemProducao.PedidoID == 0)
            {
                ViewBag.Error = "Informe um Pedido ou espere até que seja liberado um novo pedido";
                ViewData["PedidoID"] = new SelectList(_context.Pedido.Where(ped => !_context.OrdemProducao.Any(op => op.PedidoID == ped.Id)), "Id", "Descricao");
                ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome");
                ViewData["StatusID"] = new SelectList(_context.OrdemProducaoStatus, "Id", "Status");
                return View(ordemProducao);
            }
            else
            {

                if (ModelState.IsValid)
                {
                    _context.Add(ordemProducao);
                    await _context.SaveChangesAsync();
                    ViewBag.Success = "Ordem de Produção criada com sucesso";

                }
                ViewData["PedidoID"] = new SelectList(_context.Pedido.Where(ped => !_context.OrdemProducao.Any(op => op.PedidoID == ped.Id)), "Id", "Descricao");
                ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome");
                ViewData["StatusID"] = new SelectList(_context.OrdemProducaoStatus, "Id", "Status");
                return View(ordemProducao);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AlterarOrdemStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemProducao = await _context.OrdemProducao.FindAsync(id);
            if (ordemProducao == null)
            {
                return NotFound();
            }
            ViewData["MaquinaID"] = new SelectList(_context.Maquina, "Id", "Nome", ordemProducao.MaquinaID);
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "Id", "Descricao", ordemProducao.PedidoID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome", ordemProducao.ProdutoID);
            ViewData["StatusID"] = new SelectList(_context.OrdemProducaoStatus, "Id", "Status", ordemProducao.StatusID);
            return View(ordemProducao);
        }

        public async Task<IActionResult> ConfigurarOrdem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"];
            }
            else if(TempData["error"] != null)
            {
                ViewBag.Error = TempData["error"];
            }

            var ordemProducao = await _context.OrdemProducao.FindAsync(id);
            if (ordemProducao == null)
            {
                return NotFound();
            }
            ViewData["MaquinaID"] = new SelectList(_context.Maquina, "Id", "Nome", ordemProducao.MaquinaID);
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "Id", "Descricao", ordemProducao.PedidoID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome", ordemProducao.ProdutoID);
            ViewData["StatusID"] = new SelectList(_context.OrdemProducaoStatus, "Id", "Status", ordemProducao.StatusID);
            ViewBag.ListaSequencia = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).ToList();
            ViewBag.Soma = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).Sum(s => s.Quantidade);
            return View(ordemProducao);
        }


        public async Task<IActionResult> VisualizarOP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"];
            }
            else
            {
                ViewBag.Error = TempData["error"];
            }

            var ordemProducao = await _context.OrdemProducao.FindAsync(id);
            if (ordemProducao == null)
            {
                return NotFound();
            }
            ViewData["MaquinaID"] = new SelectList(_context.Maquina, "Id", "Nome", ordemProducao.MaquinaID);
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "Id", "Descricao", ordemProducao.PedidoID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome", ordemProducao.ProdutoID);
            ViewData["StatusID"] = new SelectList(_context.OrdemProducaoStatus, "Id", "Status", ordemProducao.StatusID);
            ViewBag.ListaSequencia = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).ToList();
            return View(ordemProducao);
        }



        [HttpPost]
        public JsonResult SalvarItensOP(int id, int produto, int quantidade)
        {
            try
            {
                //númera o sequenciamento de forma correta na hora de listar na tabela (Sêquandia da Ordem X)
                var NumSeq = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).Select(e => e.NumeroSequencia).ToList();

                OrdemProducaoSequencia ops = new OrdemProducaoSequencia();
                ops.OrdemProducaoID = id;
                ops.ProdutoID = produto;
                ops.Quantidade = quantidade;
                ops.NumeroSequencia = NumSeq.Count == 0 ? 1 : NumSeq.Max() + 1;
                _context.OrdemProducaoSequencia.Add(ops);
                _context.SaveChanges();
                ViewBag.Soma = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).Sum(s => s.Quantidade);
                ViewBag.Success = "Item Salvo com sucesso";
                TempData["error"] = null;
                return Json("Sequência salva com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarOrdemStatus(int id, [Bind("StatusID", "PedidoID","ProdutoID")] OrdemProducao ordemProducao)
        {

            var status = _context.OrdemProducao.Where(op => op.Id == id).SingleOrDefault();

            if (ModelState.IsValid)
            {
                try
                {
                    status.ProdutoID = ordemProducao.ProdutoID;
                    status.StatusID = ordemProducao.StatusID;
                    _context.Attach(status);
                    _context.Entry(status).Property(r => r.StatusID).IsModified = true;
                    _context.Entry(status).Property(r => r.ProdutoID).IsModified = true;
                    await _context.SaveChangesAsync();
                    ViewBag.Success = "Ordem de Produção editada com sucesso";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemProducaoExists(ordemProducao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "Id", "Descricao", ordemProducao.PedidoID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "Id", "Nome", ordemProducao.ProdutoID);
            ViewData["StatusID"] = new SelectList(_context.OrdemProducaoStatus, "Id", "Status", ordemProducao.StatusID);
            return View(ordemProducao);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Faturar(int id, OrdemProducao ordemProducao)
        {

            //Se a ordem não for condizente com o que foi pedido
            var ordemNaoCondizente = _context.OrdemProducao.Join(_context.Pedido, op => op.PedidoID, p => p.Id, (op, p) => new { Op = op, P = p }).Where(op => op.P.ProdutoID != ordemProducao.ProdutoID && op.Op.Id == id).Count();

            //verifica se a ordem está totalmente produzida
            var somaSeq = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).Sum(x => x.Quantidade);


            if (ordemNaoCondizente > 0)
            {
                TempData["error"] = "Ordem não condizente com o que foi pedido !!!";
                return RedirectToAction("VisualizarOP", "OrdemProducao", new { id = id });
            } 
            else if (somaSeq != ordemProducao.pedido.Quantidade)
            {
                TempData["error"] = "Ordem em produção, aguarde o termino !!!";
                return RedirectToAction("VisualizarOP", "OrdemProducao", new { id = id });
            }
            else
            {
                //Neste caso não registrei no banco só exibi um alerta informando que a ordem está ok e a venda poderá ser liberada
                //respeitando toda validação proposta na prova

                TempData["success"] = "Ordem de Liberada para Venda";
                return RedirectToAction("VisualizarOP", "OrdemProducao", new { id = id });
            }
        }


        [HttpPost]
        public IActionResult ConfigurarOrdem(int id, OrdemProducao ordemProducao)
        {
            var status = _context.OrdemProducao.Where(op => op.Id == id).SingleOrDefault();
            var quantidade = _context.OrdemProducao.Join(_context.Pedido, op => op.PedidoID, p => p.Id, (op, p) => new { Op = op, P = p }).Where(op => op.Op.Id == id).SingleOrDefault();
            var somaSeq = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).Sum(x => x.Quantidade);

            ViewBag.ListaSequencia = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == id).ToList();

            if (status.StatusID == 2)
            {
                TempData["error"] = "Ordem não liberada !!!";
                return RedirectToAction("ConfigurarOrdem", "OrdemProducao", new { id = id });
            }
            if (ordemProducao.quantidade > quantidade.P.Quantidade)
            {
                TempData["error"] = "Quantidade Maior que a requisitada na ordem de Produção !!!";
                return RedirectToAction("ConfigurarOrdem", "OrdemProducao", new { id = id });
            }
            if (ordemProducao.quantidade == null)
            {
                TempData["error"] = "Informe a Quantidade !!!";
                return RedirectToAction("ConfigurarOrdem", "OrdemProducao", new { id = id });
            }
            if (somaSeq > quantidade.P.Quantidade)
            {
                TempData["error"] = "Quantidade da sequência não pode ser maior que a solicitada na ordem !!!";
                return RedirectToAction("ConfigurarOrdem", "OrdemProducao", new { id = id });
            }

            else
            {
                var op = _context.OrdemProducao.Where(op => op.Id == id).SingleOrDefault();
                op.MaquinaID = ordemProducao.MaquinaID;
                op.quantidade = ordemProducao.quantidade;
                _context.Attach(op);
                _context.Entry(op).Property(r => r.MaquinaID).IsModified = true;
                _context.Entry(op).Property(r => r.quantidade).IsModified = true;
                _context.Update(op);
                _context.SaveChanges();
                TempData["success"] = "Ordem de Produção registrada";
                return RedirectToAction("ConfigurarOrdem", "OrdemProducao", new { id = id });

            }
        }


        [HttpPost]
        public JsonResult DeletarSequencia(int numSeq, int idOrdem)
        {
            try
            {
                var ordemProducao = _context.OrdemProducaoSequencia.Where(os => os.NumeroSequencia == numSeq && os.OrdemProducaoID == idOrdem).FirstOrDefault();
                _context.OrdemProducaoSequencia.Remove(ordemProducao);
                _context.SaveChanges();
                ViewBag.Soma = _context.OrdemProducaoSequencia.Where(os => os.OrdemProducaoID == idOrdem).Sum(s => s.Quantidade);
                TempData["error"] = null;
                return Json("Sequência deltada com sucesso");
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private bool OrdemProducaoExists(int id)
        {
            return _context.OrdemProducao.Any(e => e.Id == id);
        }
    }
}
