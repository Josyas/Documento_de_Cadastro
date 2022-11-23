using ArquivoDoc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArquivoDoc.Infraestrutura
{
    public class ArquivoContext : DbContext
    {
        public ArquivoContext(DbContextOptions<ArquivoContext> options) : base(options)
        {
            //
        }

        public DbSet<Arquivos> Arquivos { get; set; }
    }
}
