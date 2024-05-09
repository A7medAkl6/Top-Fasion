using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Interfaces;

namespace Top_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;


        public BasketController(IUnitOfWork UOW, IMapper mapper)
        {
            _uOW = UOW;
            _mapper = mapper;

        }

        [HttpGet("get-basket-item/{Id}")]
        public async Task<IActionResult> GetBasketById(string Id)
        {
            var _basket = await _uOW.BasketRepository.GetBasketAsync(Id);
            return Ok(_basket ?? new CustomerBasket(Id));
        }

        [HttpPost("update-basket")]
        public async Task<IActionResult> UpdateBasket(CustomerBasketDto customerBasket)
        {
            var result = _mapper.Map<CustomerBasketDto, CustomerBasket>(customerBasket);
            var _basket = await _uOW.BasketRepository.UpdateBasketAsync(result);
            return Ok(_basket);
        }

        [HttpDelete("delete-basket-item/{Id}")]
        public async Task<IActionResult> DeleteBasket(string Id)
        {
            return Ok(await _uOW.BasketRepository.DeleteBasketAsync(Id));
        }

    }
}
