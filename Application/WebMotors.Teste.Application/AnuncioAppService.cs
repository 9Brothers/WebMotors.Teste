using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Teste.Application.Interfaces;
using WebMotors.Teste.Domain.Entities;
using WebMotors.Teste.Domain.Interfaces.Services;

namespace WebMotors.Teste.Application
{
    public class AnuncioAppService : IAnuncioAppService
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioAppService(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        public async Task<Anuncio> Add(Anuncio entity)
        {
            if (string.IsNullOrEmpty(entity.Marca?.Trim())) throw new Exception("Informe a marca.");
            else if (entity.Marca.Length > 45) throw new Exception("Informe uma marca com menos de 45 caracteres.");
            else if (string.IsNullOrEmpty(entity.Modelo?.Trim())) throw new Exception("Informe o modelo.");
            else if (entity.Modelo.Length > 45) throw new Exception("Informe um modelo com menos de 45 caracteres.");
            else if (string.IsNullOrEmpty(entity.Versao?.Trim())) throw new Exception("Informe a versão.");
            else if (entity.Versao.Length > 45) throw new Exception("Informe uma versão com menos de 45 caracteres.");
            else if (entity.Ano < 1885) throw new Exception("Informe um ano acima de 1884.");
            else if (entity.Ano > DateTime.Now.Year + 1) throw new Exception($"Informe um ano abaixo de {DateTime.Now.Year + 1}.");
            else if (entity.Quilometragem < 0) throw new Exception("Informe uma quilometragem acima de 0");
            
            return await _anuncioService.Add(entity);
        }

        public async Task Delete(Anuncio entity)
        {
            if (entity.Id == 0) throw new Exception("Informe o id");

            await _anuncioService.Delete(entity);
        }

        public async Task<IEnumerable<Anuncio>> Get(Anuncio entity)
        {
            if (string.IsNullOrEmpty(entity.Marca?.Trim()) && string.IsNullOrEmpty(entity.Modelo?.Trim()) && string.IsNullOrEmpty(entity.Versao?.Trim()))
                throw new Exception("Informe uma marca, modelo ou versão.");

            return await _anuncioService.Get(entity);
        }

        public async Task<Anuncio> Update(Anuncio entity)
        {
            if (entity.Id == 0) throw new Exception("Informe o id");
            else if (string.IsNullOrEmpty(entity.Marca?.Trim())) throw new Exception("Informe a marca.");
            else if (entity.Marca.Length > 45) throw new Exception("Informe uma marca com menos de 45 caracteres.");
            else if (string.IsNullOrEmpty(entity.Modelo?.Trim())) throw new Exception("Informe o modelo.");
            else if (entity.Modelo.Length > 45) throw new Exception("Informe um modelo com menos de 45 caracteres.");
            else if (string.IsNullOrEmpty(entity.Versao?.Trim())) throw new Exception("Informe a versão.");
            else if (entity.Versao.Length > 45) throw new Exception("Informe uma versão com menos de 45 caracteres.");
            else if (entity.Ano < 1885) throw new Exception("Informe um ano acima de 1884.");
            else if (entity.Ano > DateTime.Now.Year + 1) throw new Exception($"Informe um ano abaixo de {DateTime.Now.Year + 1}.");
            else if (entity.Quilometragem < 0) throw new Exception("Informe uma quilometragem acima de 0");
            
            return await _anuncioService.Update(entity);
        }
    }
}