using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iHelpU.MODEL.Models;

namespace iHelpU.MODEL.ViewModel
{
    public class HomePageVM
    {
        public string MensagemBemVindo { get; set; }
        public IEnumerable<AnuncioServico> Anuncios { get; set; }
    }
}
