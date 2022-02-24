using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice1.DatabaseContent
{
    public class ApplicationDbContext:IdentityDbContext<User>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<HospitalDepartment> HospitalDepartments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            base.OnModelCreating(modelbuilder);
            //modelbuilder.Entity<HospitalDepartment>().HasData(
            //    new HospitalDepartment
            //    {
            //        TicketId = 1,
            //        Home = "Florida",
            //        Destination = "Texas",
            //        Cost = 500
            //    },
            //     new HospitalDepartment
            //     {
            //         TicketId = 2,
            //         Home = "Florida",
            //         Destination = "Alabbama",
            //         Cost = 100
            //     },
            //    new HospitalDepartment
            //    {
            //        TicketId = 3,
            //        Home = "Florida",
            //        Destination = "Georgia",
            //        Cost = 300
            //    }
            //    ); ;


        }
    }
}
