﻿using System;
using System.Collections.Generic;

namespace iHelpU.MODEL.Models;

public partial class ContratacaoServico
{
    public int Id { get; set; }

    public int? AnuncioServicoId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? DataContratacao { get; set; }

    public virtual AnuncioServico? AnuncioServico { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual Usuario? Usuario { get; set; }
}