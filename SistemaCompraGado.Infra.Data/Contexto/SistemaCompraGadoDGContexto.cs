using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SistemaCompraGado.Domain.Interfaces.Repository;
using System;
using System.IO;

namespace SistemaCompraGado.Infra.Data.Contexto
{
    public class SistemaCompraGadoDGContexto : ISistemaCompraGadoDGContexto
    {

        private string connectionString;

        public SistemaCompraGadoDGContexto()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory + "/Config") 
                            .AddJsonFile("appsettings.json");

            var root = builder.Build();
            connectionString = root.GetSection("ConnectionStrings").Value;
        }

        public string getconnectionString()
        {
            return connectionString;
        }
    }
}
