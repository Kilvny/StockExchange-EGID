using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockExchange_EGID.Server.Domain.Contracts;
using StockExchange_EGID.Server.Domain.Entities;

namespace StockExchange_EGID.Server.Controllers
{
    [AllowAnonymous]
    public class StocksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Stock> _stock;
        private readonly IGenericRepository<StockHistory> _stockhistory;

        public StocksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _stock = _unitOfWork.Stock;
            _stockhistory = _unitOfWork.StockHistory;
        }


        // GET: api/Stocks
        [HttpHead]
        [HttpGet]
        [Route("api/stocks")]

        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            if (_stock == null)
            {
                return NotFound();
            }

            var allStocks = _stock.GetAll();
            return Ok(allStocks);
        }


        // GET: api/Stocks/5
        [HttpGet("{id}")]
        [ActionName("GetStock")]
        public async Task<ActionResult<Stock>> GetStock(Guid id)
        {
            if (_stock == null)
            {
                return NotFound();
            }
            var stock = _stock.GetById(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
        [HttpGet]
        [Route("api/stocks/{symbol}/history")]
        public async Task<ActionResult<List<StockHistory>>> GetStockHistory(string symbol)
        {
            if (string.IsNullOrEmpty(symbol)) return BadRequest("symbol should be provided!");
            if (_stockhistory == null)
            {
                return NotFound();
            }
            List<StockHistory> stockhistory = _stockhistory
                .GetAll()
                .Where(x => x.Symbol == symbol)
                .OrderByDescending(x => x.Timestamp) // order (newest to oldest)
                .Take(100)
                .ToList();

            if (stockhistory.Count < 1)
            {
                return NotFound("There's no records for the provided stock");
            }
            return Ok(stockhistory);
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutStock(Guid id, Stock stock)
        {
            if (id != stock.Id)
            {
                return BadRequest();
            }

            _stock.Update(stock);

            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }


        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            if (_stock == null)
            {
                return NotFound();
            }
            var stock = _stock.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }

            _stock.Delete(stock);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
