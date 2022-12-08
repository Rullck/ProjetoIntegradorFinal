using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Models;
 
namespace ProjetoIntegrador.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private BDContexto contexto;
 
        public AvaliacaoController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }
 
        [HttpGet]
        public List<Avaliacao> Listar()
        {
            return contexto.Avaliacaos.Include(v => v.IdDisciplinaNavigation).Select
                (
                    v => new Avaliacao 
                    { 
                        Id = v.Id,
                        Comentario = v.Comentario,
                        Avaliacao1 = v.Avaliacao1,
                        IdDisciplina = v.IdDisciplina,
                        IdDisciplinaNavigation = new Disciplina 
                        { 
                            Id = v.IdDisciplinaNavigation.Id, 
                            Nome = v.IdDisciplinaNavigation.Nome,
                            Professor = v.IdDisciplinaNavigation.Professor
                        }, 
                    }
                ).ToList();
        }



        [HttpGet] 
        public Avaliacao Visualizar(int id)
        {
            return contexto.Avaliacaos.FirstOrDefault(p => p.Id == id);
        }



        [HttpPost]
        public string Enviar([FromBody] Avaliacao novoAvalicao)
        {
            contexto.Add(novoAvalicao);
            contexto.SaveChanges();
            return "Avaliação enviada com sucesso!";
        }

        

        [HttpDelete("{id}")]
        public string Excluir(int id)
        {
            Avaliacao dados = contexto.Avaliacaos.FirstOrDefault(p => p.Id == id);

            if (dados == null)
            {
                return "Não foi encontrado a Avaliação para o ID informado";
            }
            else
            {
                contexto.Remove(dados);
                contexto.SaveChanges();

                return "Avaliação removida com sucesso!"; 
            }
        }


        [HttpPut]
        public string Alterar([FromBody] Avaliacao avaliacaoAtualizada)
        {
            contexto.Update(avaliacaoAtualizada);
            contexto.SaveChanges();

            return "Avaliação atualizada com sucesso!";
        }

        [HttpGet]
        public List<string> ListarDisciplina()
        {

            var consultaDisciplina = (from Avaliacao in contexto.Avaliacaos select Avaliacao.IdDisciplinaNavigation.Nome).Distinct().ToList();

            return consultaDisciplina;
        }



        

    }


}