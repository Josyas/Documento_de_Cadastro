using ArquivoDoc.Infraestrutura;
using ArquivoDoc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArquivoDoc.Controllers
{
    public class ArquivosController : Controller
    {
        private readonly ArquivoContext _arquivoContext;

        public ArquivosController(ArquivoContext arquivoContext)
        {
            _arquivoContext = arquivoContext;
        }

        public IActionResult Index()
        {
            var doc = _arquivoContext.Arquivos.ToList();
            return View(doc);
        }

        [HttpPost]
        public IActionResult CadastroDocumento(IList<IFormFile> arquivos, int codigo, string titulo, string categoria, string processo)
        {
            IFormFile imagemCarregada = arquivos.FirstOrDefault();
     
            if (ModelState.IsValid)
            {
                MemoryStream ms = new MemoryStream();
                imagemCarregada.OpenReadStream().CopyTo(ms);

                Arquivos arqui = new Arquivos()
                {
                    Codigo = codigo,
                    Titulo = titulo,
                    Processo = processo,
                    Categoria = categoria,
                    Descricao = imagemCarregada.FileName,
                    Dados = ms.ToArray(),
                    ContentType = imagemCarregada.ContentType
                };

                _arquivoContext.Arquivos.Add(arqui);
                _arquivoContext.SaveChanges();
            }

            TempData["AlertMessage"] = "Salvo com Sucesso...";
            return RedirectPermanent("https://localhost:44302/Home/Index");
        }
        
        public IActionResult Visualizar(int id)
        {
            var documentoBanco = _arquivoContext.Arquivos.FirstOrDefault(a => a.Id == id);

            return File(documentoBanco.Dados, documentoBanco.ContentType);
        }

        public IActionResult Apagar(int id)
        {
            if (ModelState.IsValid)
            {
                var ApagarDocumento = _arquivoContext.Arquivos.Where(x => x.Id == id).FirstOrDefaultAsync();

                _arquivoContext.Arquivos.Remove(ApagarDocumento.Result);
                _arquivoContext.SaveChanges();
            }

            TempData["Message"] = "Apagado com sucesso";
            return RedirectPermanent("https://localhost:44302/Arquivos");
        }
    }
}
