using CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class CarrosselPaginaViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IList<Produto> produtosNaCategoria, int indicePagina, int tamanhoPagina)
        {
            var produtosNaPagina =
                produtosNaCategoria
                .Skip(indicePagina * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();

            return View("Default",
                new CarrosselPaginaViewModel(produtosNaPagina, indicePagina));
        }
    }
}
