using System;
using System.Collections.Generic;

namespace ProjetoIntegrador.Models
{
    public partial class Avaliacao
    {

        
        public int Id { get; set; }
        public string Comentario { get; set; } = null!;
        public int Avaliacao1 { get; set; }
        public int? IdDisciplina { get; set; }

        public virtual Disciplina? IdDisciplinaNavigation { get; set; }
    }
}
