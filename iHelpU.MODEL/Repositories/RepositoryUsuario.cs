using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace iHelpU.MODEL.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>
    {
        public RepositoryUsuario(BancoTccContext context, bool saveChanges = true) : base(context, saveChanges)
        {
            _context = context;
        }
        public async Task<Usuario> ObterUsuarioPorId(int usuarioId)
        {
            return await _context.Usuarios
                                 .FirstOrDefaultAsync(u => u.Id == usuarioId);
        }
    }
}