using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.Data
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(b =>
            {
                b.HasKey(t => t.Id);
            });

            modelBuilder.Entity<Produto>(b =>
            {
                b.HasKey(t => t.Id);
            });
        }

        private List<Livro> GetLivros()
        {
            var json = File.ReadAllText("data/livros.json");
            return JsonConvert.DeserializeObject<List<Livro>>(json);
        }

        private List<Produto> GetProdutos()
        {
            var livros = GetLivros();

            var categorias = livros
                .Select(l => l.Categoria) //projeção ou transformação
                .Distinct()
                .Select((nomeCategoria, i) =>
                {
                    var categoria = new Categoria(nomeCategoria);
                    categoria.Id = i + 1;
                    return categoria;
                });
        }
    }
}
