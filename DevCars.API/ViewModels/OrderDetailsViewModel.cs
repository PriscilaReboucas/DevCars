using System.Collections.Generic;

namespace DevCars.API.ViewModels
{
    public class OrderDetailsViewModel
    {
        public OrderDetailsViewModel(int idCar, int idCustomer, decimal totalCost, List<string> extraItems)
        {
            IdCar = idCar;
            IdCustomer = idCustomer;
            TotalCost = totalCost;
            ExtraItems = extraItems;
        }

        /// <summary>
        /// Identificador do carro.
        /// </summary>
        public int IdCar { get; set; }
        /// <summary>
        /// Identificador do cliente
        /// </summary>
        public int IdCustomer { get; set; }
        /// <summary>
        /// Totalizador
        /// </summary>
        public decimal TotalCost { get; set; }
        /// <summary>
        /// Lista de items
        /// </summary>
        public List<string> ExtraItems { get; set; }
    }
}
