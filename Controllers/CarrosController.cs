using System.Diagnostics;
using System.Linq;
using CarWebMVC.Data;
using CarWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarWebMVC.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly ILogger<CarrosController> _logger;

        public CarrosController(ILogger<CarrosController> logger, ApplicationDbContext database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Index()
        {
            var carros = _database.Carros.ToList();
            return View(carros);
        }

        public IActionResult ListaCarro()
        {
            var carros = _database.Carros.ToList();
            return View(carros);
        }

        public IActionResult CadastrarCarro()
        {
            return View();
        }

        public IActionResult EditarCarro(int id)
        {
            Carro carros = _database.Carros.First(options => options.Id == id);
            return View("EditarCarro", carros);
        }

        public IActionResult DeletarCarro(int id)
        {
            Carro carros = _database.Carros.First(options => options.Id == id);
            _database.Carros.Remove(carros);
            _database.SaveChanges();
            return RedirectToAction("ListaCarro");
        }
        public IActionResult DeletarCarroIndex(int id)
        {
            Carro carros = _database.Carros.First(options => options.Id == id);
            _database.Carros.Remove(carros);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SalvarCarro(Carro carro)
        {
            if (carro.Id == 0)
                _database.Carros.Add(carro);
            else
            {
                Carro carroBanco = _database.Carros.First(registro => registro.Id == carro.Id);
                carroBanco.Marca = carro.Marca;
                carroBanco.Modelo = carro.Modelo;
                carroBanco.Placa = carro.Placa;
                carroBanco.Preco = carro.Preco;
            }

            _database.SaveChanges();
            return RedirectToAction("ListaCarro");
        }

        public IActionResult PopularCarro()
        {
            foreach (var carro in _database.Carros)
            {
                if (carro.Marca == "Mercedes-Benz")
                    return RedirectToAction("PopularExist");
            }

            Carro carro1 = new Carro {Marca = "Mercedes-Benz", Modelo = "C63s AMG", Cor = "Preto", Placa = "MERC1", Preco = 150000 };
            Carro carro2 = new Carro {Marca = "Ferrari", Modelo = "488 GTB", Cor = "Vermelho", Placa = "FERR4", Preco = 10000000 };
            Carro carro3 = new Carro {Marca = "Lamborghini", Modelo = "Gallardo", Cor = "Verde", Placa = "LAMB7", Preco = 1800000 };
            Carro carro4 = new Carro {Marca = "BMW", Modelo = "320i", Cor = "Branco", Placa = "BMWI3", Preco = 120000 };
            Carro carro5 = new Carro {Marca = "Porsche", Modelo = "Cayman", Cor = "Azul", Placa = "PORS3", Preco = 140000 };
            Carro carro6 = new Carro {Marca = "Land Rover", Modelo = "Evoque", Cor = "Bordô", Placa = "LAND5", Preco = 200000 };
            Carro carro7 = new Carro {Marca = "Golf", Modelo = "GFT", Cor = "Azul-marinho", Placa = "GOLF4", Preco = 50000 };
            Carro carro8 = new Carro {Marca = "Chevrolet", Modelo = "Opala", Cor = "Preto", Placa = "OPAL4", Preco = 1500000 };
            Carro carro9 = new Carro {Marca = "Mercedes-Benz", Modelo = "S63", Cor = "Preto", Placa = "MERC2", Preco = 4000000 };
            Carro carro10 = new Carro {Marca = "Mercedes-Benz", Modelo = "A45", Cor = "Branco", Placa = "MERC3", Preco = 12000000 };

            _database.Add(carro1);
            _database.Add(carro2);
            _database.Add(carro3);
            _database.Add(carro4);
            _database.Add(carro5);
            _database.Add(carro6);
            _database.Add(carro7);
            _database.Add(carro8);
            _database.Add(carro9);
            _database.Add(carro10);

            _database.SaveChanges();
            return View();
        }

        public IActionResult PopularExist()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
