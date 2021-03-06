using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<Tecnica> Tecnica { get; set; }
        public DbSet<Quadrante> Quadrante { get; set; }
    }
}
