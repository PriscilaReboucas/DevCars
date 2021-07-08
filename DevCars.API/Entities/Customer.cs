using System;
using System.Collections.Generic;

namespace DevCars.API.Entities
{
    public class Customer
    {
        protected Customer() { }

        public Customer(string fullName, string document, DateTime birthDate)
        {
            FullName = fullName;
            Document = document;
            BirthDate = birthDate;
            Orders = new List<Order>();
        }

        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome completo
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// Documento
        /// </summary>
        public string Document { get; private set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// Lista de pedidos do cliente.
        /// </summary>
        public List<Order> Orders { get; private set; }

        /// <summary>
        /// Compra
        /// </summary>
        /// <param name="order"></param>
        public void Purchase(Order order)
        {
            Orders.Add(order);
        }
    }
}
