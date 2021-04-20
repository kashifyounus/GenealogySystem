using FamilyTreeSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeSystem
{
    public class FTSContext : DbContext
    {
        public FTSContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<FamilyTree> FamilyTrees { get; set; }
        public DbSet<SiblingRelation> SiblingRelations { get; set; }
        public DbSet<Children> Childrens { get; set; }
        public DbSet<MartialRelation> MartialRelations { get; set; }
        public DbSet<Parent> Parents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<FamilyTree>()
                .HasOne<Parent>()
                .WithMany()
                .HasForeignKey(x=>x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MartialRelation>()
                .HasOne(x=>x.Husband)
                .WithMany()
                .HasForeignKey(x => x.HusbandId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MartialRelation>()
                .HasOne(x => x.Wife)
                .WithMany()
                .HasForeignKey(x => x.WifeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Parent>()
                .HasOne(x => x.Father)
                .WithMany()
                .HasForeignKey(x => x.FatherId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Parent>()
                .HasOne(x => x.Mother)
                .WithMany()
                .HasForeignKey(x => x.MotherId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Parent>()
                .HasOne(x => x.Mother)
                .WithMany()
                .HasForeignKey(x => x.MotherId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
