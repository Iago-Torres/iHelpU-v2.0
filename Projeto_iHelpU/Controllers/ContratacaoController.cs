using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using iHelpU.MODEL.Repositories;

namespace Projeto_iHelpU.Controllers
{
    public class ContratacaoController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var db = new BancoTCCContext();
            var listaContratacao = await db.ContratacaoServicos.ToListAsync();
            return View(listaContratacao);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContratacaoServico contratacaoServico)
        {
            var db = new BancoTCCContext();
            if (ModelState.IsValid)
            {
                db.Entry(contratacaoServico).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(contratacaoServico);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var db = new BancoTCCContext();
            var usuario = await db.TipoServicos.FindAsync(id);
            return View(usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContratacaoServico contratacaoServico)
        {
            var db = new BancoTCCContext();
            if (ModelState.IsValid)
            {
                db.Entry(contratacaoServico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(contratacaoServico);
        }
        public async Task<IActionResult> Details(int id)
        {
            var db = new BancoTCCContext();
            var contratacaoServico = await db.ContratacaoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(contratacaoServico);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new BancoTCCContext();
            var contratacaoServico = await db.ContratacaoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(contratacaoServico);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ContratacaoServico contratacaoServico)
        {
            var db = new BancoTCCContext();
            db.Entry(contratacaoServico).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
