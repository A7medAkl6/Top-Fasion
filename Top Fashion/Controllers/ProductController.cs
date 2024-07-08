﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Top_Fashion.Shared;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Interfaces;
using Top_Fashion.TopFashion.Domain.Sharing;
using Top_Fashion.TopFashion.Main.Errors;
using Top_Fashion.TopFashion.Main.Helper;

namespace Top_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public ProductController(IUnitOfWork UOW, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _uOW = UOW;
            _mapper = mapper;
            _stringLocalizer= stringLocalizer;
        }


        [HttpGet("get-all-products")]
        public async Task<ActionResult> Get([FromQuery] ProductParams productParams)
        {
            //var src = await _uOW.ProductRepository.GetAllAsync(x=>x.Category);
            var src = await _uOW.ProductRepository.GetAllAsync(productParams);
            var result = _mapper.Map<IReadOnlyList<ProductDto>>(src.ProductDtos);

            return Ok(new Pagination<ProductDto>(productParams.PageNumber, productParams.PageSize, src.TotalItems, result));
        }

        [HttpGet("get-product-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseCommonResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var src = await _uOW.ProductRepository.GetByIdAsync(id, x => x.Category);
            if (src == null) return NotFound(new BaseCommonResponse(404));
            var result = _mapper.Map<ProductDto>(src);
            return Ok(result);
        }

        [HttpPost("add-new-product")]
        public async Task<ActionResult> Post([FromForm]CreateProductDto productDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _uOW.ProductRepository.AddAsync(productDto);
                    return res ? Ok(productDto) : BadRequest();
                }
                return BadRequest(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-existing-product/{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] UpdateProductDto productdto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _uOW.ProductRepository.UpdateAsync(id, productdto);
                    return res ? Ok(res) : BadRequest();
                }
                return BadRequest(productdto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("delete-existing-product/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _uOW.ProductRepository.DeleteAsyncWithPicture(id);
                    return res ? Ok(res) : BadRequest();
                }
                return NotFound($"This id : {id} Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
