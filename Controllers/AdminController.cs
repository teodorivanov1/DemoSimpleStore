using Microsoft.AspNetCore.Mvc;
using SimpleStoreWeb.Attributes;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Enums;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using SimpleStoreWeb.ViewModels.Admin;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Controllers
{
    [AuthorizeRoles(ApplicationRoles.Administrator)]
    public class AdminController : UpsertController<Category, CategoryViewModel>
    {
        private readonly IRepository<Category> categoryRepository;

        public AdminController(
            IRepository<Category> categoryRepository) 
            : base(categoryRepository, new CategoryViewModel())
        {
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public override async Task<IActionResult> Index(int? pageNumber)
        {
            base.vmAsQueryable = categoryRepository
                    .Query()
                    .Select(x => (CategoryViewModel)x);

            return await base.Index(pageNumber);
        }

        public override async Task<IActionResult> Upsert(int id)
        {
            if (id > 0)
            {
                var cat = await categoryRepository.GetByIdAsync(id);
                base.vm = (CategoryViewModel)cat;
            }
            return await base.Upsert(id);
        }

        [HttpPost]
        public override async Task<IActionResult> Upsert(CategoryViewModel model)
        {
            base.entity = (Category)model;
            return await base.Upsert(model);
        }
    }
}
