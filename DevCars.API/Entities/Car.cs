using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Car
    {

        protected Car() { }

        public Car(string brand, string model, string vinCode, int year, decimal price, string color, DateTime productionDate)
        {
            Brand = brand;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            Color = color;
            ProductionDate = productionDate;
            Status = CarStatusEnum.Available;
            RegisteredAt = DateTime.Now;
        }

        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Marca do carro
        /// </summary>
        public string Brand { get; private set; }
        /// <summary>
        /// Modelo do carro
        /// </summary>
        public string Model { get; private set; }
        /// <summary>
        /// Codigo único do carro
        /// </summary>
        public string VinCode { get; private set; }
        /// <summary>
        /// Ano do Carro
        /// </summary>
        public int Year { get; private set; }
        /// <summary>
        /// Preço do carro
        /// </summary>
        public decimal Price { get; private set; }
        /// <summary>
        /// Cor do carro
        /// </summary>
        public string Color { get; private set; }
        /// <summary>
        /// Data de Produção do carro
        /// </summary>
        public DateTime ProductionDate { get; private set; }

        public CarStatusEnum Status { get; private set; }

        public DateTime RegisteredAt { get; private set; }        

        public void Update(string color, decimal price)
        {
            Color = color;
            Price = price;
        }

        public void SetAsSuspended()
        {
            Status = CarStatusEnum.Suspend;
        }
    }
}
