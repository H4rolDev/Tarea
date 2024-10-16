using Main.Errors;
using Main.models;
using DataBase.models;
using Main.repositories;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("/api/person")]
    public class PersonController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IPersonRepository _prodRepo;
        public PersonController(
            IPersonRepository prodRepo,
            ILogger<PersonController> logger
        ){
            _prodRepo = prodRepo;
            _logger = logger;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<List<Person>> Listar()
        {
            try
            {
                List<Person> persons = _prodRepo.person().GetAll();
                return Ok(persons);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[PersonController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[PersonController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Person> Obtener([FromRoute]int Id)
        {
            try
            {
                Person? person = _prodRepo.person().GetById(Id); 
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[PersonController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[PersonController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Person> Crear([FromBody] PersonBody body)
        {
            try
            {
                Person person = _prodRepo.person().Create( (Person)body );
               
                return Ok(person);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[PersonController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PersonController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{person_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int Id, 
                                     [FromBody] PersonBody body)
        {
            try
            {
                _prodRepo.person().Update(Id, (Person)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[PersonController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PersonController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{person_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int person_id)
        {
            try
            {
                _prodRepo.person().Delete(person_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[PersonController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PersonController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}