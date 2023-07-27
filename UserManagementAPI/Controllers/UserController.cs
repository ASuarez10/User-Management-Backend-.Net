using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Dtos;
using UserManagementAPI.Entities;
using UserManagementAPI.Repositories;
using UserManagementAPI.UseCases;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserManagementContext _userManagementContext;

        private readonly IUpdateUserUseCase _updateUserUseCase;

        public UserController(UserManagementContext userManagementContext, IUpdateUserUseCase updateUserUseCase) 
        {
            _userManagementContext = userManagementContext;
            _updateUserUseCase = updateUserUseCase;
        }

        //Metodo para obtener un User mediante un id.
        //api/customer/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(long id)
        {

            UserEntity result = await _userManagementContext.GetUser(id);
            return new OkObjectResult(result.toDto());
        }

        //Metodo para obtener todos los Users.
        //api/customer
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDto>))]
        public async Task<IActionResult> GetUsers()
        {
            var result = _userManagementContext.gestion_usuarios
                .Select(user=>user.toDto()).ToList();

            return new OkObjectResult(result);
        }

        //Metodo para borrar un User de la bd mediante un id.
        //api/customer/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await _userManagementContext.DeleteUser(id);
            return new OkObjectResult(result);
        }


        //Metodo para crear un User en la bd mediante los datos pasados en el body.
        //api/customer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            //throw new NotImplementedException();
            UserEntity result = await _userManagementContext.AddUser(user);

            return new CreatedResult($"https://localhost:7216/api/user/{result.id}", null);
        }

        //Metodo para modificar un User en la bd mediante los datos pasados en el body.
        //api/customer
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            
            UserDto? result = await _updateUserUseCase.Execute(user);

            if (result == null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

    }
}