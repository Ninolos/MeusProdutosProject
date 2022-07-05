using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevIO.AppMvc.Models;
using DevIO.AppMvc.ViewModels;
using DevIO.Business.Models.Produtos;
using DevIO.Business.Models.Produtos.Services;
using DevIO.Infra.Data.Repository;
using DevIO.Business.Core.Notificacoes;
using AutoMapper;

namespace DevIO.AppMvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository; //para fazer leitura
        private readonly IProdutoService _produtoService; // para fazer a persistencia dos dados
        private readonly IMapper _mapper;

        public ProdutosController()
        {
            
        }

        [Route("lista-de-produtos")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _produtoRepository.ObterTodos());
        }

        [Route("dados-do-produto/{id:guid}")]
        public async Task<ActionResult> Details(Guid id)
        {
           var produtoViewModel = await ObterProduto(id);
            
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("novo-produtos")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Route("novo-produtos")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));
               
                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {

            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);

            await _produtoService.Remover(id);
            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
            return produto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoRepository.Dispose();
                _produtoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
