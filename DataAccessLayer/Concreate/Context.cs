using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class Context : IdentityDbContext<WriterUser,WriterRole,int>
    {
        //veri tabanı iletişim katmanı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-U7QTN9J;database=CoreProjeDB;integrated security=true;");
        }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<ToDoList> ToDoLists { get; set; }

        public DbSet<Test1> Test1s { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<WriterMessage> writerMessages  { get; set; }
    }
}
