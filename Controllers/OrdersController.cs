using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleStoreWeb.Attributes;
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
    public class OrdersController : UpsertController<Order, OrderViewModel>
    {
        private readonly IRepository<Order> orderRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private int ApplicationUserId => userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult().Id;

        public OrdersController(
            IRepository<Order> orderRepository,
            UserManager<ApplicationUser> userManager)
            : base(orderRepository, new OrderViewModel())
        {
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public override async Task<IActionResult> Index(int? pageNumber)
        {
            base.vmAsQueryable = ((OrderRepository)orderRepository)
                .GetByUserIdQuery(ApplicationUserId)
                .Select(x => (OrderViewModel)x);

            return await base.Index(pageNumber);
        }

        public override async Task<IActionResult> Upsert(int id)
        {
            OrderViewModel viewModel = new();

            if (id > 0)
            {
                var entity = await orderRepository.GetByIdAsync(id);
                viewModel = (OrderViewModel)entity;
            }

            // this user id assigment can be done on the explicit operator
            // this will make pointless injecting of UserManager
            base.vm = viewModel;
            return await base.Upsert(id);
        }

        [HttpPost]
        public override async Task<IActionResult> Upsert(OrderViewModel model)
        {
            base.entity = (Order)model;
            base.entity.ApplicationUserId = ApplicationUserId;
            return await base.Upsert(model);
        }
    }
}
