using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Models;
 
namespace ProjetoIntegrador.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private BDContexto contexto;
 
        public DisciplinaController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }




        [HttpGet]
        public List<Avaliacao> ListarPorDisciplina(string nome)
        {
            return contexto.Avaliacaos.Include(v => v.IdDisciplinaNavigation).Where(p => p.IdDisciplinaNavigation.Nome == nome).Select
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
        public List<Avaliacao> Listar(string? order = "padrao")
        {
            if(order == "c"){
                return contexto.Avaliacaos.OrderBy(c => c.Avaliacao1).Include(v => v.IdDisciplinaNavigation).Select
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

            else if(order == "d"){
                return contexto.Avaliacaos.OrderByDescending(c => c.Avaliacao1).Include(v => v.IdDisciplinaNavigation).Select
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
                ).ToList();;
            }

            else{
                return contexto.Avaliacaos.ToList();
            }
            
        }
    }


    


}