using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tarea1.Models;
using Newtonsoft.Json;

namespace Tarea1.Controllers
{
    public class FrutaController : Controller
    {
        private readonly List<Fruta> lstFrutas;

        public FrutaController()
        {
            var myJsonString = System.IO.File.ReadAllText("Models/frutas.json");

            // Deserializar al contenedor
            FrutaContainer frutasData = JsonConvert.DeserializeObject<FrutaContainer>(myJsonString);

            // Obtener la lista de frutas
            lstFrutas = frutasData.Frutas;
        }

        public IActionResult Index()
        {
            return View(lstFrutas);
        }

        public IActionResult Find(string nombre)
        {
            List<Fruta> lstResultFrutas = new List<Fruta>();

            foreach (var item in lstFrutas)
            {
                if (item.Nombre != null && item.Nombre.ToLower().Contains(nombre.ToLower()))
                {
                    lstResultFrutas.Add(item);
                }
            }

            return View("Index", lstResultFrutas);
        }

        public IActionResult Details(int id)
        {
            var item = lstFrutas.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound(); // Si no encuentra la fruta
            }
            return View(item);
        }
    }
}
