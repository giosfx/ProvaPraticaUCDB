using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prova.Bussiness.Interfaces;
using Prova.Bussiness.Models;
using Prova.Data.Context;

namespace Prova.Data.Repository
{
    public class PedidoRepository : IRepository<Pedido>
    {
        protected readonly ProvaContext Db;
        protected readonly DbSet<Pedido> DbSet;

        public PedidoRepository(ProvaContext db)
        {
            Db = db;
            DbSet = db.Set<Pedido>();
        }

        public async Task<IEnumerable<Pedido>> Buscar(Expression<Func<Pedido, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<Pedido>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public async Task Adicionar(Pedido entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(Pedido entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            DbSet.Remove(new Pedido {Id = id});
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}