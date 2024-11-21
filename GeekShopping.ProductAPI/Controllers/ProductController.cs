﻿using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
    {
        var products = await _productRepository.FindAll();

        if(products == null) return NotFound();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductVO>> FindById(long id)
    {
        var product = await _productRepository.FindById(id);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductVO>> Create(ProductVO requestModel)
    {
        
        if(requestModel == null) return BadRequest();

        var product = await _productRepository.Create(requestModel);

        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<ProductVO>> Update(ProductVO requestModel)
    {

        if (requestModel == null) return BadRequest();

        var product = await _productRepository.Update(requestModel);

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductVO>> Delete(long id)
    {
        var status = await _productRepository.Delete(id);

        if (status) return BadRequest();

        return Ok(status);
    }
}