using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class AddCustomerInputModel
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Documento
        /// </summary>
        public string Document { get; set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime BirthDate { get; set; }

    }
}
