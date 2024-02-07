using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockExchange_EGID.Server.Common.Enums;
using StockExchange_EGID.Server.Domain.Contracts;
using StockExchange_EGID.Server.Domain.Entities;
using System.Security.Cryptography.Xml;

namespace StockExchange_EGID.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Order> _order;
        private readonly IGenericRepository<Stock> _stock;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _order = unitOfWork.Order;
            _stock = unitOfWork.Stock;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            if (_order == null)
            {
                return NotFound();
            }
            return Ok(_order.GetAll());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder([FromRoute] string id)
        {
            if (_order == null)
            {
                return NotFound();
            }
            Guid _id;
            bool x = Guid.TryParse(id, out _id);
            if (!x)
            {
                return BadRequest("Id is bad");
            }
            var order = _order.GetById(_id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Guid id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _order.Update(order);

            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool OrderExists(Guid id)
        {
            return _order.GetById(id) != null;
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (_order == null)
            {
                return Problem();
            }

            try
            {
                decimal currentPrice = _stock.GetAll().Where(x => x.Symbol == order.Symbol).Select(x => x.Price).First();
                Order newOrder = new Order
                {
                    Symbol = order.Symbol,
                    OrderType = order.OrderType,
                    Price = currentPrice * (order.Quntity),
                    Quntity = order.Quntity,
                };
                _unitOfWork.Order.Create(order);
                await _unitOfWork.Complete();


                return CreatedAtAction("GetOrder", new { id = order.Id }, order);

            }
            catch (Exception e)
            {

                return StatusCode(500, $"Error while creating an order with the following exception: {e.InnerException?.Message}");
            }
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (_order == null)
            {
                return BadRequest();
            }
            var orderToDelete = _order.GetById(id);
            if (orderToDelete == null)
            {
                return NotFound("Order you want to delete doesn't exist!");
            }



            _order.Delete(orderToDelete);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
