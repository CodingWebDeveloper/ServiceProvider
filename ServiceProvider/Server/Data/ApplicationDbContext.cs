using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceProvider.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<File> Files { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<Occupation> Occupations { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Package> Packages { get; set; }

        public virtual DbSet<Requirement> Requirements { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<UserOccupation> UserOccupations { get; set; }

        public virtual DbSet<UserSkill> UserSkills { get; set; }
    }
}
