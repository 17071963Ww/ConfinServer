using ConfinServer.model;
using Microsoft.AspNetCore.Mvc;
 
namespace ConfinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EstadoController : ControllerBase
    {
        private static List<Estado> lista = new List<Estado>();

        [HttpGet]
        public String GetEstado()
        {
            var valor = "teste";
            valor = valor + " - bsn";
            return valor;
        }

        [HttpGet("Get2")]
        public String GetEstado2()
        {

            var valor = "teste";
            valor = valor + " - bsn";
            return valor;
        }

        [HttpGet("Lista")]
        public List<Estado> GetLista() { 
            return lista;
        }

        [HttpPost]
        public string PostEstado(Estado estado)
        {
            lista.Add(estado);
            return "estado cadastrado com sucesso!";
        }

        [HttpPut]
        public string PutEstado(Estado estado)
        {   
            /* select * from estado where sigla = "SC" */
            var estadoExiste = lista.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                estadoExiste.Sigla = estado.Sigla;
                estadoExiste.Nome = estado.Nome;

            }
            else
            {
                return "estado nao encontrado";
            }

            return "estado alterado com sucesso";
        }

        [HttpDelete]
        public string DeleteEstado(string sigla)
        {
            var estadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();

            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
            }
            else
            {
                return "estado nao encontrado";
            }

            return "estado excluido com sucesso";
        }

        [HttpDelete("{sigla}")]
        public string DeleteEstado3([FromRoute] string sigla)
        {
            var estadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();

            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
            }
            else
            {
                return "estado nao encontrado";
            }

            return "estado excluido com sucesso";
        }
    }
}
