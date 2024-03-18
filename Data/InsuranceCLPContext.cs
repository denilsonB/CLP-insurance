using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InsuranceCLP.Models;

namespace InsuranceCLP.Data
{
    public class InsuranceCLPContext : DbContext
    {
        public InsuranceCLPContext (DbContextOptions<InsuranceCLPContext> options)
            : base(options)
        {
        }

        public DbSet<InsuranceCLP.Models.UserModel> UserModel { get; set; } = default!;
        public DbSet<InsuranceCLP.Models.InsuranceModel> InsuranceModel { get; set; } = default!;
    }
}
