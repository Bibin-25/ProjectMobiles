﻿using APILayer.Models;
using DomainLayer;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.Datas.Apiservices
{
    public class PoductApi
    {
        public static Response<IEnumerable<Product>> GetAll()
        {
            Response <IEnumerable < Product >> products = new Response<IEnumerable<Product>>();
            
            using(HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44364/api/productcatalog";
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result=httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult=result.Result.Content.ReadAsStringAsync();
                    products = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<IEnumerable<Product>>>(serilizedResult.Result);
                }
               
            }
            return products;

        }



        public static Product GetById(int id)
        {
            Product products = new Product();

            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44364/api/productcatalog" + id;
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    products = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(serilizedResult.Result);
                }

            }
            return products;

        }
        public static bool Edit(Product product )
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/productcatalog/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.PutAsync(uri, content);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public static bool Create(Product product)
        {

            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/productcatalog/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.PostAsync(uri, content);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public static bool Delete(int id)
        {


            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(id);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/productcatalog/" + id;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.DeleteAsync(uri);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
