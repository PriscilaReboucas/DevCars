namespace DevCars.API.ViewModels
{
    public class CarItemViewModel
    {
        public CarItemViewModel(int id, string brand, string model, decimal price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
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
        /// Preço do carro
        /// </summary>
        public decimal Price { get; set; }
    }
}
