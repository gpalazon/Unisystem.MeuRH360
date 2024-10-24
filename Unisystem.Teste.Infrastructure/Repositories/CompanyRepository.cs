using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisystem.Teste.Domain;

namespace Unisystem.Teste.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;


        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var Company = await _context.Companies.FindAsync(id);

            // Verifica se a empresa foi encontrada
            if (Company == null)
            {
                throw new KeyNotFoundException($"Company com id {Company.Id} não encontrado.");
            }

            return Company;
        }

        public async Task<IEnumerable<Company>> GetAllCompanysAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task AddCompanyAsync(Company Company)
        {
            _context.Companies.Add(Company);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateCompanyAsync(Company Company)
        {
            // Verifica se o usuário existe
            var existingCompany = await _context.Companies.FindAsync(Company.Id);
            if (existingCompany == null)
            {
                throw new KeyNotFoundException($"Company com id {Company.Id} não encontrado.");
            }

            // Atualiza as propriedades da empresa
            existingCompany.Bairro = Company.Bairro;
            existingCompany.Celular = Company.Celular;
            existingCompany.CEP = Company.CEP;
            existingCompany.Cidade = Company.Cidade;
            existingCompany.CNPJ = Company.CNPJ;
            existingCompany.Complemento = Company.Complemento;
            existingCompany.CPFAdministrador = Company.CPFAdministrador;
            existingCompany.Email = Company.Email;
            existingCompany.Endereco = Company.Endereco;
            existingCompany.Estado = Company.Estado;
            existingCompany.Nome = Company.Nome;
            existingCompany.NomeAdministrador = Company.NomeAdministrador;
            existingCompany.Tipo = Company.Tipo;
            

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();
        }


        public async Task DeleteCompanyAsync(int id)
        {
            // Busca a empresa a ser excluído
            var Company = await _context.Companies.FindAsync(id);
            if (Company == null)
            {
                throw new KeyNotFoundException($"Company com id {Company.Id} não encontrado.");
            }

            // Remove
            _context.Companies.Remove(Company);
            await _context.SaveChangesAsync();
        }
    }
}
