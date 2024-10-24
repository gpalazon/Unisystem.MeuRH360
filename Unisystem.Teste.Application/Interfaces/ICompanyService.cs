using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisystem.Teste.Application.DTO;

namespace Unisystem.Teste.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAllCompanysAsync();
        Task<CompanyDTO> GetCompanyByIdAsync(int id);
        Task AddCompanyAsync(CompanyDTO CompanyDto);
        Task UpdateCompanyAsync(CompanyDTO CompanyDto);
        Task DeleteCompanyAsync(int id);
    }
}
