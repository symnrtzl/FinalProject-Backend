﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely Coupled
        //IoC Container -- Inversion of Control
        IProductService _productService;
        

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result=_productService.GetAll();
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult Get(int id) 
        {
            var result=_productService.GetById(id);
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add, HttpPost")]
        public IActionResult Post(Product product) 
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        

    }
}