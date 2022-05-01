using APILayer.Models;
using BusinesLogic;
using BusinesLogic.Interface;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogController : ControllerBase
    {
        private readonly ILogger<ProductCatalogController> _logger; 
        ProductDbContext _Context;
        IProductCatalog _Catalog;
        
        public ProductCatalogController(ProductDbContext Context,ILogger<ProductCatalogController>logger)
        {
            _logger = logger;
            _Context = Context;
            _Catalog = new ProductCatalog(_Context);
        }
        [HttpGet]
        public Response<IEnumerable<Product>> GetAll()
        {
            Response<IEnumerable<Product>> response = new Response<IEnumerable<Product>>();
            try
            {
                var products = _Catalog.GetAll();
                response.AddResponse(true, 0, products, "GetAll");
                return response;
            }
            catch(Exception ex)
            {
                response.AddResponse(false, 0, null, "NotGet");
                _logger.LogError("Error message");
                return response;

                
            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Product product )
        {
            try
            {
                _Catalog.Add(product);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            }
            catch(Exception ex)
            {
                _logger.LogError("Error In Post", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            
        }
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Product product)
        {
            try
            {
                _Catalog.Update(product);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            }
            catch(Exception ex)
            {
                _logger.LogError("Error In Put", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            
        }
        [HttpDelete("{Id}")]
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                Product product = new Product();
                product = _Catalog.GetById(Id);

                _Catalog.Delete(product);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }catch(Exception ex)
            {
                _logger.LogError("Error In Delete", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            
        }
    }
}
