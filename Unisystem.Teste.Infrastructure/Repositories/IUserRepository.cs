using System.Collections.Generic;
using System.Threading.Tasks;
using Unisystem.Teste.Domain;

namespace Unisystem.Teste.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        // Método para listar todos os usuários
        Task<IEnumerable<User>> GetAllUsersAsync();

        // Método para buscar um usuário pelo seu ID
        Task<User> GetUserByIdAsync(int id);

        // Método para adicionar um novo usuário
        Task AddUserAsync(User user);

        // Método para atualizar um usuário existente
        Task UpdateUserAsync(User user);

        // Método para remover um usuário pelo seu ID
        Task DeleteUserAsync(int id);
    }
}