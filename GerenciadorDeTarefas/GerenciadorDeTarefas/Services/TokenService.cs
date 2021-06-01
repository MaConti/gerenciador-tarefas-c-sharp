﻿using GerenciadorDeTarefas.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Services
{
    public class TokenService
    {
        public static string CriarToken(Usuario usuario)
        {
            var tokenHadler = new JwtSecurityTokenHandler()
            var chaveCriptografiaEmBytes = Encoding.ASCII.GetBytes(ChaveJWT.Chave)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome)

                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografiaEmBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHadler.CreateToken(tokenDescriptor);
            return tokenHadler.WriteToken(token);
        }
    }
}
