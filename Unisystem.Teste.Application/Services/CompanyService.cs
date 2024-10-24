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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _CompanyRepository;

        public CompanyService(ICompanyRepository CompanyRepository)
        {
            _CompanyRepository = CompanyRepository;
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllCompanysAsync()
        {
            var Companys = await _CompanyRepository.GetAllCompanysAsync();
            return Companys.Select(Company => new CompanyDTO
            {
                Id = Company.Id,
                Bairro = Company.Bairro,
                Celular = Company.Celular,
                CEP = Company.CEP,
                Cidade = Company.Cidade,
                CNPJ = Company.CNPJ,
                Complemento = Company.Complemento,
                CPFAdministrador = Company.CPFAdministrador,
                Email = Company.Email,
                Endereco = Company.Endereco,
                Estado = Company.Estado,
                Nome = Company.Nome,
                NomeAdministrador = Company.NomeAdministrador,
                Tipo = Company.Tipo
            }).ToList();
        }

        public async Task<CompanyDTO> GetCompanyByIdAsync(int id)
        {
            var Company = await _CompanyRepository.GetCompanyByIdAsync(id);
            if (Company == null)
            {
                return null;
            }

            return new CompanyDTO
            {
                Id = Company.Id,
                Bairro = Company.Bairro,
                Celular = Company.Celular,
                CEP = Company.CEP,
                Cidade = Company.Cidade,
                CNPJ = Company.CNPJ,
                Complemento = Company.Complemento,
                CPFAdministrador = Company.CPFAdministrador,
                Email = Company.Email,
                Endereco = Company.Endereco,
                Estado = Company.Estado,
                Nome = Company.Nome,
                NomeAdministrador = Company.NomeAdministrador,
                Tipo = Company.Tipo
            };
        }

        public async Task AddCompanyAsync(CompanyDTO CompanyDto)
        {
            var Company = new Company
            {
                Id = CompanyDto.Id,
                Bairro = CompanyDto.Bairro,
                Celular = CompanyDto.Celular,
                CEP = CompanyDto.CEP,
                Cidade = CompanyDto.Cidade,
                CNPJ = CompanyDto.CNPJ,
                Complemento = CompanyDto.Complemento,
                CPFAdministrador = CompanyDto.CPFAdministrador,
                Email = CompanyDto.Email,
                Endereco = CompanyDto.Endereco,
                Estado = CompanyDto.Estado,
                Nome = CompanyDto.Nome,
                NomeAdministrador = CompanyDto.NomeAdministrador,
                Tipo = CompanyDto.Tipo
            };

            await _CompanyRepository.AddCompanyAsync(Company);
        }

        public async Task UpdateCompanyAsync(CompanyDTO CompanyDto)
        {
            var Company = await _CompanyRepository.GetCompanyByIdAsync(CompanyDto.Id);
            if (Company == null)
            {
               
                return;
            }

            //Company.Name = CompanyDto.Name;
            //Company.Email = CompanyDto.Email;
            //Company.CPF = CompanyDto.CPF;

            await _CompanyRepository.UpdateCompanyAsync(Company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _CompanyRepository.DeleteCompanyAsync(id);
        }
     
    }
}
