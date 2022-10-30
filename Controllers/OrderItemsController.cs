using Microsoft.AspNetCore.Mvc;
using SimpleStoreWeb.Attributes;
using SimpleStoreWeb.Data.Common;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Enums;
using SimpleStoreWeb.Data.Repositories;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using SimpleStoreWeb.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Controllers
{
    [AuthorizeRoles(ApplicationRoles.User)]
    public class OrderItemsController : Controller
    {
        private readonly IRepository<OrderItem> orderItemRepository;

        public OrderItemsController(IRepository<OrderItem> orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id, int? pageNumber)
        {
            int pageSize = 10;
            var vm = ((OrderItemRepository)orderItemRepository)
                .GetByOrderIdQuery(id)
                .Select(x => (OrderItemViewModel)x);

            return View(await PaginatedList<OrderItemViewModel>.CreateAsync(
                vm,
                pageNumber ?? 1,
                pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Purchase(int id, int? pageNumber)
        {
            var target = await orderItemRepository.GetByIdAsync(id);
            target.IsPurchased = true;
            orderItemRepository.Update(target);
            await orderItemRepository.SaveAsync();
            return RedirectToAction(nameof(Index), new { id = target.OrderId, pageNumber });
        }
    }
}
