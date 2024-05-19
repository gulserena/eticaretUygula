﻿using eticaretUygulama.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace eticaretUygulama.Controllers
{
    public class ProductApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7161/api/Product");
        private readonly HttpClient _client;
       
        public ProductApiController()
        {
                _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        //index view gidecek kısım
        public IActionResult Index()
        {
            List<Products> products = new List<Products>();
            HttpResponseMessage response=_client.GetAsync(_client.BaseAddress+"/Product/Get").Result;
            if(response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                products=JsonConvert.DeserializeObject<List<Products>>(data); 
            }
            return View(products);
        }
        [HttpGet]
        //Yeni kayıt sayfası
        public IActionResult Create()
        {
            return View();
        }
        //create ile gönderilen kayıtları api üzerinden kayıt ekleme
        [HttpPost]
        public IActionResult Create(Products products)
        {
            try
            {
                string data=JsonConvert.SerializeObject(products);
                StringContent content=new StringContent(data,Encoding.UTF8,"Application/JSon");
                HttpResponseMessage response = _client.PostAsJsonAsync(_client.BaseAddress + "/Product/Post",content).Result;

            }catch(Exception ex)
            {
                TempData["errorMessage"] = ex;
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Products products = new Products();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Product/Get" + id).Result;
                if(response.IsSuccessStatusCode)
                {
                    string data= response.Content.ReadAsStringAsync().Result;
                    products=JsonConvert.DeserializeObject<Products>(data);
                    View(products);
                }
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex;
                return View();  
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Products products,int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Product/Delete" + id).Result;
                if( response.IsSuccessStatusCode) 
                {
                    TempData["successMessage"] = "İşlem Başarılı";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Products products = new Products();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Product/Get" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<Products>(data);
                    View(products);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex;
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Products products, int id)
        {
            
            try
            {
              
              string data=JsonConvert.SerializeObject(products);
                StringContent content=new StringContent(data,Encoding.UTF8,"Application/JSon");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Product/Put",content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "İşlem Başarılı";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex;
                return View();
            }
            return View();
        }
    }
}
