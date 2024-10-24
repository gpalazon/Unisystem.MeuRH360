using System.Collections.Generic;
using System.Threading.Tasks;
using Unisystem.Teste.Domain;

namespace Unisystem.Teste.Infrastructure.Repositories
{
    public interface ICompanyRepository
    {
        // Método para listar todos os Company
        Task<IEnumerable<Company>> GetAllCompanysAsync();

        // Método para buscar um Company pelo seu ID
        Task<Company> GetCompanyByIdAsync(int id);

        // Método para adicionar um novo Company
        Task AddCompanyAsync(Company Company);

        // Método para atualizar um Company existente
        Task UpdateCompanyAsync(Company Company);

        // Método para remover uma Company pelo seu ID
        Task DeleteCompanyAsync(int id);
    }
}