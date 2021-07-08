using System.Collections.Generic;

namespace DevCars.API.InputModels
{
    public class AddOrderInputModel
    {
        /// <summary>
        /// Identificador do carro
        /// </summary>
        public int IdCar { get; set; }
        /// <summary>
        /// Identificador do cliente
        /// </summary>
        public int IdCustomer { get; set; }
        /// <summary>
        /// Itens do pedido
        /// </summary>
        public List<ExtraItemInputModel> ExtraItems { get; set; }
    }

    public class ExtraItemInputModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
