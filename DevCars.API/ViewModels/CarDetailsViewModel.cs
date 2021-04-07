using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(int id, string brand, string model, string vinCode, int year, decimal price, string color, DateTime productionDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            Color = color;
            ProductionDate = productionDate;
        }

        /// <summary>
        /// Identificador do carro
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Marca do carro
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Modelo do carro
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Codigo único do carro
        /// </summary>
        public string VinCode { get; set; }
        /// <summary>
        /// Ano do Carro
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Preço do carro
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Cor do carro
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Data de Produção do carro
        /// </summary>
        public DateTime ProductionDate { get; set; }

    }
}
