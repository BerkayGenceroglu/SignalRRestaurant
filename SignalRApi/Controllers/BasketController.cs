using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Viewmodel;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SignalRContext _context;

        public BasketController(IBasketService basketService, SignalRContext context)
        {
            _basketService = basketService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBasket(int id)
        {
            var values = _basketService.TGetBasketByTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTablewithProductName")]
        public IActionResult BasketListByMenuTablewithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(y =>y.Product).Where(x => x.MenuTableId == id).Select(b =>new ResultBasketListWithProductName
            {
                BasketId = b.BasketId,
                ProductName = b.Product.ProductName,
                MenuTableId = b.MenuTableId,
                TotalPrice = b.TotalPrice,
                Price = b.Price,
                Count = b.Count,
                ProductId = b.ProductId,
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            _basketService.TAdd(new Basket
            {
                ProductId = createBasketDto.ProductId,
                MenuTableId = createBasketDto.MenuTableId,
                Count = 1,
                Price = _context.Products.Where(x => x.ProductID == createBasketDto.ProductId).Select(x => x.Price).FirstOrDefault(),
                TotalPrice = createBasketDto.TotalPrice,
            });
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteProductbyBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Ürün Başarılı Bir Şekilde Silindi");
        }
    }
}
