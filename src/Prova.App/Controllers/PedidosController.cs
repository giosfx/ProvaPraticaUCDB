using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prova.App.ViewModels;
using Prova.Bussiness.Interfaces;
using Prova.Bussiness.Models;

namespace Prova.App.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IRepository<Pedido> _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidosController(IRepository<Pedido> pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPorId(id));

            if (pedidoViewModel == null)
            {
                return NotFound();
            }

            return View(pedidoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoViewModel pedidoViewModel)
        { 
            if (!ModelState.IsValid) return View(pedidoViewModel);

            var pedido = _mapper.Map<Pedido>(pedidoViewModel);
            await _pedidoRepository.Adicionar(pedido);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPorId(id));

            if (pedidoViewModel == null)
            {
                return NotFound();
            }

            return View(pedidoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PedidoViewModel pedidoViewModel)
        {
            if (id != pedidoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pedidoViewModel);

            var pedido = _mapper.Map<Pedido>(pedidoViewModel);

            await _pedidoRepository.Atualizar(pedido);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Desconto(Guid id)
        {
            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPorId(id));

            if (pedidoViewModel == null)
            {
                return NotFound();
            }

            return View(pedidoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desconto(Guid id, PedidoViewModel pedidoViewModel)
        {
            if (id != pedidoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pedidoViewModel);

            var pedido = _mapper.Map<Pedido>(await AplicarDesconto(id, pedidoViewModel));
            
            await _pedidoRepository.Atualizar(pedido);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPorId(id));

            if (pedidoViewModel == null)
            {
                return NotFound();
            }

            return View(pedidoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPorId(id));

            if (pedidoViewModel == null) return NotFound();

            await _pedidoRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<PedidoViewModel> AplicarDesconto(Guid id, PedidoViewModel pedido)
        {
            var pedidoAtual = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPorId(id));

            pedidoAtual.Valor -= pedido.Valor;

            return pedidoAtual;
        }

    }
}
