using System;

namespace DevCars.API.InputModels
{
    public class AddCarInputModel
    {
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

