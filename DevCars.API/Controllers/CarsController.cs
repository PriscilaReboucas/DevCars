using Dapper;
using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace DevCars.API.Controllers
{

    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        private readonly string _connetionString;

        public CarsController(DevCarsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            //_connetionString = _dbContext.Database.GetDbConnection().ConnectionString; Erro quando mudar para inmemmory.
            _connetionString = configuration.GetConnectionString("DevCarsCs");
        }


        //GET api/cars
        [HttpGet]
        public IActionResult Get()
        {
            // usando entityframework core
            // retorna a lista de CarIteViewModel
            //var cars = _dbContext.Cars;
            //var carViewModel = cars
            //    .Where(c => c.Status == CarStatusEnum.Available)
            //    .Select(c => new CarItemViewModel(c.Id, c.Brand, c.Model,c.Price))                
            //    .ToList();

            // usando o dapper 
            using (var sqlConnection = new SqlConnection(_connetionString))
            {
                var query = "SELECT Id, Brand, Model, Price from Car Where status = 0";
                var carViewModel = sqlConnection.Query<CarItemViewModel>(query);
                return Ok(carViewModel);
            }

            //return Ok(carViewModel);
        }

        //Get api/cars/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var car = _dbContext.Cars.SingleOrDefault(car => car.Id == id);
            //se o carro de identificador id não existir retorna notfound, senão retorna ok.
            if (car == null)
                return NotFound();

            var carDetailsViewModel = new CarDetailsViewModel(car.Id, car.Brand, car.Model, car.VinCode, car.Year, car.Price, car.Color, car.ProductionDate);

            return Ok(carDetailsViewModel);
        }


        //POST api/cars 
        /// <summary>
        /// Realizar cadastro veiculo e vou refecer via corpo de requisição
        /// </summary>  
        /// <remarks>
        /// Requisição de exemplo: 
        /// {
        ///  "brand" :"Chevrolet",
        ///  "model" : "Onix",
        ///  "vinCode" : "abc123",
        ///  "year" : "2021",
        ///  "color": "cinza",
        ///  "price": "30000",
        ///  "productionDate:"2021-04-05"
        /// }
        /// </remarks>
        /// <param name="model">Dados de um novo carro</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code ="201">Objeto criado com sucesso</response>
        /// <response code ="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] AddCarInputModel model)
        {
            //se o cadastro funcionar retorna created (201) 
            //se os dados de entrada estiverem incorretos retorna bad request (400)
            //se o cadastro funcionar, mas nao tiver api de consulta pode retornar (204) nocontent

            var car = new Car(model.Brand, model.Model, model.VinCode, model.Year, model.Price, model.Color, model.ProductionDate);

            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges(); // funciona como se fosse transação, pegando alterações do contexto de dados e persistindo.

            return CreatedAtAction(
                nameof(GetById),
                new { id = car.Id },
                model);

        }

        //PUT api/cars/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCarInputModel model)
        {
            //se a atualização funcionar retorna 204 no content
            //se os dados entrada estiverem incorretos retorna (400) bad request
            //se não existir retorna not found 404.

            var car = _dbContext.Cars.SingleOrDefault(car => car.Id == id);
            if (car == null)
                return NotFound();

            car.Update(model.Color, model.Price);
            //_dbContext.SaveChanges();

            using (var sqlConnection = new SqlConnection(_connetionString))
            {
                var query = "UPDATE Cars SET Color = @color, Price = @price WHERE Id = @id";
                sqlConnection.Execute(query, new { color = model.Color, price = model.Price, car.Id });
            }
            return NoContent();
        }

        //DELETE api/cars/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //se não existir retorna notfound 404
            //se for com sucesso retorna no content 204
            var car = _dbContext.Cars.SingleOrDefault(car => car.Id == id);
            if (car == null)
                return NotFound();

            car.SetAsSuspended();
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
