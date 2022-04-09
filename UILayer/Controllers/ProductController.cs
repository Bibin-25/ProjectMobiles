﻿using APILayer.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UILayer.Datas.Apiservices;

namespace UILayer.Controllers
{
    public class ProductController : Controller
    {
        Product Data=null;
        public ProductController()
        {
            Data = new Product();
        }
        public IActionResult Index()
        {
            Response<IEnumerable<Product>> products = PoductApi.GetAll();
            return View(products.Data);
        }
        public IActionResult Details(int id)
        {
            Product products = PoductApi.GetById(id);
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
           Data.id = product.id;
            Data.name = product.name;   
            Data.price = product.price;
            Data.description = product.description; 
            bool result=PoductApi.Create(product);
            if (result) 
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = PoductApi.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            bool result = PoductApi.Edit(product);
            if (result)
            {
                return RedirectToAction("");
            }
            return RedirectToAction("");
        }
        public ActionResult Delete(int id)
        {
            bool result = PoductApi.Delete(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
