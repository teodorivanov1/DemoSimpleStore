using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SimpleStoreWeb.Attributes;
using SimpleStoreWeb.Data.Common;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Enums;
using SimpleStoreWeb.Data.Repositories;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using SimpleStoreWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Controllers
{
    [AuthorizeRoles(ApplicationRoles.User)]
    public class ProductsController : UpsertController<Product, ProductsViewModel>
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IList<Category> categories;
        private readonly UserManager<ApplicationUser> userManager;
        private int ApplicationUserId => userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult().Id;
        public ProductsController(
            IRepository<Product> productRepository,
            IRepository<Category> categoryRepository,
            IRepository<OrderItem> orderItemRepository,
            UserManager<ApplicationUser> userManager)
            : base(productRepository, new ProductsViewModel())
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
            ArgumentNullException.ThrowIfNull(nameof(categoryRepository));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            categories = categoryRepository.GetAllAsync().Result.ToList();
        }

        [HttpGet]
        public override async Task<IActionResult> Index(int? pageNumber)
        {
            // This unwanted cast shold be removed with properly registration on DI container.
            // also mvAsQuerible code smell should be removed (e.g. map with automapper inside a base class)
            base.vmAsQueryable = ((ProductRepository)productRepository)
                .GetByUserIdQuery(ApplicationUserId)
                .Select(x => (ProductsViewModel)x);

            return await base.Index(pageNumber);
        }

        [HttpGet]
        public override async Task<IActionResult> Upsert(int id)
        {
            ProductsViewModel viewModel = new();
            if (id > 0)
            {
                var entity = await productRepository.GetByIdAsync(id);
                viewModel = (ProductsViewModel)entity;
            }
            viewModel.ApplicationUserId = ApplicationUserId;
            viewModel.Categories = categories;

            base.vm = viewModel;
            return await base.Upsert(id);
        }

        [HttpPost]
        public override async Task<IActionResult> Upsert(ProductsViewModel model)
        {
            base.entity = (Product)model;
            base.entity.ApplicationUserId = ApplicationUserId;
            model.Categories = categories;
            return await base.Upsert(model);
        }

        [HttpGet]
        public async Task<IActionResult> Order(int id, int? pageNumber)
        {
            var model = ((ProductRepository)productRepository)
                .GetNotOrderedExcludeByUserIdQuery(ApplicationUserId, id)
                .Select(x => (ProductsViewModel)x);

            var result = await PaginatedList<ProductsViewModel>.CreateAsync(
                model,
                pageNumber ?? 1,
                10);
            result.IsOrder = true;
            result.OrderListId = id;

            return View(nameof(Index), result);
        }

        [HttpGet]
        public async Task<IActionResult> AddToList(int productId, int orderListId, int? pageNumber)
        {
            await orderItemRepository.InsertAsync(
                new()
                {
                    ProductId = productId,
                    OrderId = orderListId,
                });
            await orderItemRepository.SaveAsync();

            return RedirectToAction(nameof(Order), new { id = orderListId, pageNumber });
        }
    }
}
