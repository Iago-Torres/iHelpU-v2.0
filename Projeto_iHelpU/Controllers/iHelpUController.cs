using iHelpU.MODEL.Models;
using iHelpU.MODEL.Services;
using Microsoft.AspNetCore.Mvc;
using Projeto_iHelpU.Models; // Certifique-se de ajustar o namespace
using System.Threading.Tasks;
using iHelpU.MODEL.ViewModel;
namespace Projeto_iHelpU.Controllers
{
    public class iHelpUController : Controller
    {
        private readonly AnuncioServico_Service _serviceAnuncio;

        public iHelpUController(AnuncioServico_Service serviceAnuncio)
        {
            _serviceAnuncio = serviceAnuncio;
        }

        public async Task<IActionResult> HomePage()
        {
            var anuncios = await _serviceAnuncio.GetAllAsync();
            var viewModel = new HomePageVM
            {
                MensagemBemVindo = "Bem-vindo ao iHelpU!",
                Anuncios = await _serviceAnuncio.oRepositoryAnuncioServico.SelecionarTodosAsync()
            };
            return View(viewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
