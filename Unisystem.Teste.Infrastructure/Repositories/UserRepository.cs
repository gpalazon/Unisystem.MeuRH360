using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisystem.Teste.Domain;

namespace Unisystem.Teste.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            // Verifica se o usuário foi encontrado
            if (user == null)
            {                
                throw new KeyNotFoundException($"Usuário com id {user.Id} não encontrado.");
            }

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateUserAsync(User user)
        {
            // Verifica se o usuário existe
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"Usuário com id {user.Id} não encontrado.");
            }

            // Atualiza as propriedades do usuário
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password; 

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();
        }


        public async Task DeleteUserAsync(int id)
        {
            // Busca o usuário a ser excluído
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"Usuário com id {user.Id} não encontrado.");
            }

            // Remove o usuário
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

      
    }
}
