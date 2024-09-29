using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Data.Configuration
{
    public class UsersEntityTypeConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
          
                builder.HasKey(u => u.Id);

                builder.Property(u => u.UserName)
                      .IsRequired()
                      .HasMaxLength(100);

                builder.Property(u => u.Email)
                      .IsRequired();

            builder.Property(u => u.Age)
                  .IsRequired();
                      

            builder.Property(u => u.Gender)
                .IsRequired()
                 .HasMaxLength(10);

            builder.Property(u => u.PhoneNumber)
               .IsRequired()
               .HasMaxLength(11);

            builder.Property(u => u.Adress)
              .IsRequired()
               .HasMaxLength(1000);

            builder.Property(u => u.ImgUrl)
                      .HasMaxLength(1000);

           
        }
    }
}

        











  


