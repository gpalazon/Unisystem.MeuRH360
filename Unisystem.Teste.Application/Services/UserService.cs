using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisystem.Teste.Application.DTO;
using Unisystem.Teste.Application.Interfaces;
using Unisystem.Teste.Domain;
using Unisystem.Teste.Infrastructure.Repositories;

namespace Unisystem.Teste.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                return users.Select(user => new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    //CPF = user.CPF
                }).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;

        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                //CPF = user.CPF
            };
        }

        public async Task AddUserAsync(UserDTO userDto)
        {
            try
            {

                var user = new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    //CPF = userDto.CPF
                    Password = userDto.Password
                };

                //await _userRepository.AddUserAsync(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userDto.Id);
            if (user == null)
            {
                // Lógica para lidar com usuário não encontrado, se necessário
                return;
            }

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            //user.CPF = userDto.CPF;

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
     
    }
}
