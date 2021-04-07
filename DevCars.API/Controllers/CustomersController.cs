using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DevCars.API.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;

        public CustomersController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerInputModel model)
        {
            var customer = new Customer(model.FullName, model.Document, model.BirthDate);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return NoContent();

        }

        //POST api/customers/2/orders
        /// <summary>
        /// Api cadastro de pedido para o cliente
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        [HttpPost("{id}/orders")]
        public IActionResult PostOrder(int id, [FromBody] AddOrderInputModel model)
        {
            // modela os itens para passar para o construtor de pedidos.
            var extraItems = model.ExtraItems
                .Select(i => new ExtraOrderItem(i.Description, i.Price))
                .ToList();

            // busca o carro para acessar o preco atual
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == model.IdCar); // obtem as informações do carro  

            var order = new Order( model.IdCar, model.IdCustomer, car.Price, extraItems);

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            // existe api para retornar dados do pedido.
            return CreatedAtAction(
                nameof(GetOrder),
                new {id = order.IdCustomer, orderid = order.Id},
                model
                );
        }

        //Get api/customers/1/orders/3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <param name="orderid">Identificador do pedido</param>
        /// <returns></returns>
        [HttpGet("{id}/orders/{orderid}")]
        public IActionResult GetOrder(int id, int orderid)
        {         
            //Busca o pedido do cliente.
            var order = _dbContext.Orders
                .Include(o=>o.ExtraItems) // retorna a lista de extra items da order.
                .SingleOrDefault(o => o.Id == orderid);

            if (order == null)
                return NotFound();

            var extraItems = order.ExtraItems
                .Select(e => e.Descricao)
                .ToList();
            var orderViewModel = new OrderDetailsViewModel(order.IdCar, order.IdCustomer, order.TotalCost, extraItems);

            return Ok(orderViewModel);
        }


    }
}
