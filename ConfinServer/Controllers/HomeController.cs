using ConfinServer.model;
using Microsoft.AspNetCore.Mvc;

namespace ConfinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CidadeController : ControllerBase
    {
        private static List<Cidade> lista = new List<Cidade>();

        [HttpGet]
        public List<Cidade> GetLista()
        {
            return lista;
        }

        [HttpPost]
        public string PostCidade(Cidade cidade)
        {
            lista.Add(cidade);
            return "cidade cadastrada com sucesso!";
        }

        [HttpPut]
        public string PutCidade(Cidade cidade)
        {
            
            var cidadeExiste = lista.Where(l => l.Codigo == cidade.Codigo).FirstOrDefault();
            if (cidadeExiste != null)
            {
                cidadeExiste.Codigo = cidade.Codigo;
                cidadeExiste.Nome = cidade.Nome;

            }
            else
            {
                return "Cidade nao encontrada";
            }

            return "Cidade alterada com sucesso";
        }

        [HttpDelete("{codigo}")]
        public string DeleteCidade([FromRoute] int codigo)  
        {
            var cidadeExiste = lista.Where(l => l.Codigo == codigo).FirstOrDefault();

            if (cidadeExiste != null)
            {
                lista.Remove(cidadeExiste);
            }
            else
            {
                return "cidade nao encontrada";
            }

            return "cidade excluida com sucesso";
        }
    }
}
