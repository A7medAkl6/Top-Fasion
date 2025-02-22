﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top_Fashion.TopFashion.Infrastructure.Data;
using Top_Fashion.TopFashion.Main.Errors;

namespace Top_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BugController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            var product = _context.Products.Find(50);
            if (product == null)
            {
                return NotFound(new BaseCommonResponse(404));
            }
            return Ok(product);
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var product = _context.Products.Find(50);
            product.Name = "";
            return Ok(product);
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new BaseCommonResponse(400));
        }

    }
}
