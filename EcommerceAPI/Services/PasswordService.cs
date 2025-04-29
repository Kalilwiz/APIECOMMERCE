using EcommerceAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EcommerceAPI.Services
{
    public class PasswordService
    {
        // PassowordHasher - PBKDF2 ( tipo do algoritmo matematico usado para criar os hash)

        // criando um objeto usando a clash hasher para receber os metodos
        private readonly PasswordHasher<Cliente> _hasher = new();

        // criando um metodo que vai receber o cliente e a senha e gerar uma hash
        public string PassowordRasher(Cliente cliente)
        {
            // metodo para gerar uma hash

            return _hasher.HashPassword(cliente, cliente.Senha);
        }

        // criando um metodod que vai verificar se a senha informada pelo cliente é verdadeira
        public bool VerificarSenha(Cliente cliente, string SenhaInformada)
        {
            // metodo que verifica se a senha do cliente é verdadeira
            // obs - precisa do cliente, aonde a senha esta armazenada, e a senha informada pelo cliente para funcionar
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, SenhaInformada);

            // metodo do hasher que verifica se a senha e verdadeira e te tras um retorno pronto se for ou nao e tambem em bool
            return resultado == PasswordVerificationResult.Success;
        }


        // Serve para:

        //  - gerar um Hash
        //  - verificar o hash
    }
}
