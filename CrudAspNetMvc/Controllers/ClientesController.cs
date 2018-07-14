using CrudAspNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace CrudAspNetMvc.Controllers
{
    public class ClientesController : Controller
    {
        private CadastroContext db = new CadastroContext();

        private List<object> estados = new List<object>
        {
                new {Sigla = "AC", Nome = "Acre" },
                new {Sigla = "AL", Nome = "Alagoas" },
                new {Sigla = "AP", Nome = "Amapa" },
                new {Sigla = "AM", Nome = "Amazonas" },
                new {Sigla = "BA", Nome = "Bahia" },
                new {Sigla = "CE", Nome = "Ceara" },
                new {Sigla = "DF", Nome = "Distrito Federal" },
                new {Sigla = "ES", Nome = "Espirito Santo" },
                new {Sigla = "GO", Nome = "Goias" },
                new {Sigla = "MA", Nome = "Maranhao" },
                new {Sigla = "MT", Nome = "Mato Grosso" },
                new {Sigla = "MS", Nome = "Mato Grosso do Sul" },
                new {Sigla = "MG", Nome = "Minas Gerais" },
                new {Sigla = "PA", Nome = "Para" },
                new {Sigla = "PB", Nome = "Paraiba" },
                new {Sigla = "PR", Nome = "Parana" },
                new {Sigla = "PE", Nome = "Pernambuco" },
                new {Sigla = "PI", Nome = "Piaui" },
                new {Sigla = "RJ", Nome = "Rio de Janeiro" },
                new {Sigla = "RN", Nome = "Rio Grande do Norte" },
                new {Sigla = "RS", Nome = "Rio Grande do Sul" },
                new {Sigla = "RO", Nome = "Rondonia" },
                new {Sigla = "RR", Nome = "Roraima" },
                new {Sigla = "SC", Nome = "Santa Catarina" },
                new {Sigla = "SP", Nome = "Sao Paulo" },
                new {Sigla = "SE", Nome = "Sergipe" },
                new {Sigla = "TO", Nome = "Tocantins" }
         };

        public ActionResult Index(string busca = "",int pagina = 1)
        {
            if (!String.IsNullOrWhiteSpace(busca))
            {
                ViewBag.Busca = busca;
                return View(db.Clientes
                              .Where(c => c.Nome.Contains(busca) || c.CPF == busca)
                              .OrderBy(c => c.Nome)
                              .ToPagedList(pagina,10));
            }
            else
                return View(new List<Cliente>().ToPagedList(1,1));
        }

        public ActionResult Create()
        {
            ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");
            return View();
        }
    }
}