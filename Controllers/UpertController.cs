using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SimpleStoreWeb.Data.Common;
using SimpleStoreWeb.Data.Entities.Abstraction;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using SimpleStoreWeb.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Controllers
{
    public abstract class UpsertController<TEntity, TViewModel> : Controller
        where TViewModel : IIdNameCompatable
        where TEntity : Entity
    {
        protected readonly IRepository<TEntity> repo;
        protected TViewModel vm;
        protected IQueryable<TViewModel> vmAsQueryable;
        protected TEntity entity;

        protected UpsertController(IRepository<TEntity> repo, TViewModel vm)
        {
            this.repo = repo;
            this.vm = vm;
        }

        public virtual async Task<IActionResult> Index(int? pageNumber)
        {
            // pageSize cam be expoused as an appsettings.json configuration property.
            int pageSize = 10;
            
            return View(await PaginatedList<TViewModel>.CreateAsync(
                vmAsQueryable,
                pageNumber ?? 1,
                pageSize));
        }

        // LSP violation, not every time derived methods require to be async.
        public virtual async Task<IActionResult> Upsert(int id) => View(nameof(Upsert), vm);

        [HttpPost]
        public virtual async Task<IActionResult> Upsert(TViewModel model)
        {
            // Operation like upsert maybe is kind of SRP violation.
            if (model.Id > 0)
            {
                // In order to be more scalable and secure here, an entity must be taken
                // from repository by id.
                repo.Update(entity);
            }
            else
            {
                await repo.InsertAsync(entity);
            }

            try
            {
                await repo.SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                // will be better to override SaveChanges and add global exception handler and
                // avoiding showing unhandled exceptions on user.
                if(ex.InnerException is NpgsqlException inner && inner.SqlState == "23505")
                {
                    return AddError(model, "името вече е използвано.");
                }
                return AddError(model, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
        private IActionResult AddError(TViewModel model, string message)
        {
            ModelState.AddModelError(string.Empty, message);
            return View(nameof(Upsert), model);
        }
    }
}
