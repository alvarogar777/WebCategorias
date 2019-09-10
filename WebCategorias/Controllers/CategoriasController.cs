using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebCategorias.Models;

using WebCategorias.Service;



namespace WebCategorias.Controllers
{
    public class CategoriasController : Controller
    {
        private HttpClient http;

        public CategoriasController()
        {
            this.http = new ConexionApi().http;
        }
        // GET: Categorias
        [HttpGet]
        public async Task<ActionResult> Index()
        {            
            //var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzdWFyaW8xQGhvdG1haWwuY29tIiwiQ3VhbHFpZXJWYWxvciI6IlZhbG9yIGRlIGxhIGxsYXZlIiwianRpIjoiZGNjNmM5NjMtZGZkZi00ZWU3LWEzNTctOWM0ZTQ4NDg2ZjYyIiwiZXhwIjoxNTY3NjUxMzMyfQ.twHlG4mp2zMAL0DV4XPuLOMIAbgxPj1UOSQKLoobEks");
            //var json = await httpClient.GetStringAsync("https://localhost:44349/api/v1/Categorias");
                     
            var json = await this.http.GetStringAsync("Categorias");
            var listaCategoria = JsonConvert.DeserializeObject<List<Categoria>>(json);
            return View(listaCategoria);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public async Task<ActionResult>  Create(Categoria categoria)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44349/api/v1/");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzdWFyaW8xQGhvdG1haWwuY29tIiwiQ3VhbHFpZXJWYWxvciI6IlZhbG9yIGRlIGxhIGxsYXZlIiwianRpIjoiZGNjNmM5NjMtZGZkZi00ZWU3LWEzNTctOWM0ZTQ4NDg2ZjYyIiwiZXhwIjoxNTY3NjUxMzMyfQ.twHlG4mp2zMAL0DV4XPuLOMIAbgxPj1UOSQKLoobEks");
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Categoria>("categorias", categoria);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzdWFyaW8xQGhvdG1haWwuY29tIiwiQ3VhbHFpZXJWYWxvciI6IlZhbG9yIGRlIGxhIGxsYXZlIiwianRpIjoiZGNjNmM5NjMtZGZkZi00ZWU3LWEzNTctOWM0ZTQ4NDg2ZjYyIiwiZXhwIjoxNTY3NjUxMzMyfQ.twHlG4mp2zMAL0DV4XPuLOMIAbgxPj1UOSQKLoobEks");
            var json = await httpClient.GetStringAsync("https://localhost:44349/api/v1/Categorias/" + id);
            var listaCategoria = JsonConvert.DeserializeObject<Categoria>(json);
            return View(listaCategoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Categoria categoria, FormCollection collection)
        {
            try
            {
                var httpClient = new HttpClient();
                var put = new JavaScriptSerializer().Serialize(categoria);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzdWFyaW8xQGhvdG1haWwuY29tIiwiQ3VhbHFpZXJWYWxvciI6IlZhbG9yIGRlIGxhIGxsYXZlIiwianRpIjoiZGNjNmM5NjMtZGZkZi00ZWU3LWEzNTctOWM0ZTQ4NDg2ZjYyIiwiZXhwIjoxNTY3NjUxMzMyfQ.twHlG4mp2zMAL0DV4XPuLOMIAbgxPj1UOSQKLoobEks");
                var json = await httpClient.PutAsJsonAsync<Categoria>("https://localhost:44349/api/v1/Categorias/"+categoria.CodigoCategoria,categoria);    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
