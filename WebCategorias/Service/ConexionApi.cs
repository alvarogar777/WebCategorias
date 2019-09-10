using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebCategorias.Service
{
    public class ConexionApi 
    {
        public HttpClient http { get; set; }

        public ConexionApi(){
            this.http = new HttpClient();
            this.http.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzdWFyaW8xQGhvdG1haWwuY29tIiwiQ3VhbHFpZXJWYWxvciI6IlZhbG9yIGRlIGxhIGxsYXZlIiwianRpIjoiZGNjNmM5NjMtZGZkZi00ZWU3LWEzNTctOWM0ZTQ4NDg2ZjYyIiwiZXhwIjoxNTY3NjUxMzMyfQ.twHlG4mp2zMAL0DV4XPuLOMIAbgxPj1UOSQKLoobEks");
            this.http.BaseAddress = new Uri("https://localhost:44349/api/v1/");
        }



}
}