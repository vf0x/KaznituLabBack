﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace KaznituLab.Configs
{
    public class AuthOptions
    {
        public const string ISSUER = "Kaznitu"; // издатель токена
        public const string AUDIENCE = "lab.satbayev.university"; // потребитель токена
        const string KEY = "kaznitusecury_key";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
