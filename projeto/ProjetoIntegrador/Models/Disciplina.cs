using System;
using System.Collections.Generic;

namespace ProjetoIntegrador.Models
{
    public partial class Disciplina
    {
        public Disciplina()
        {
            Avaliacaos = new HashSet<Avaliacao>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Professor { get; set; }

        public virtual ICollection<Avaliacao> Avaliacaos { get; set; }

    }
}