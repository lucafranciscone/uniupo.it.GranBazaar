using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GranBazar.Dto;
using GranBazar.Data;
using Microsoft.AspNetCore.Authorization;

namespace GranBazar.Controllers
{
    /**
     * E' una classe che viene utilizzata da tutti i controller che esibiscono
     * il comportamento CRUD
    */
    public abstract class CrudController<TContext, TId, TEntity> : Controller
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext Context;
        protected readonly ILogger Logger;

        //verrà ritornato da tutte le action che concettualmente ritornano void (Create, Update, Delete)
        protected static readonly IActionResult EmptyJson = new JsonResult(new { });

        protected abstract DbSet<TEntity> Entities { get; }
        protected abstract Func<TEntity, TId, bool> FilterById { get; }

        protected CrudController(TContext context, ILogger logger)
        {
            Context = context;
            Logger = logger;
        }

        
        //public IActionResult CatalogoProdotti() => View();

        [HttpGet]
        public virtual async Task<IActionResult> Read()
        {
            var data = Entities;
            return Json(new DataSourceResult
            {
                Total = await data.CountAsync(),
                Data = data
            });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return EmptyJson;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            Context.Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return EmptyJson;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(TId id)
        {
            var entity = await Entities.SingleOrDefaultAsync(s => FilterById(s, id));
            if (entity == null)
            {
                return NotFound();
            }
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return EmptyJson;
        }
    }

}