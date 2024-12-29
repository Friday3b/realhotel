using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotelData.Model;
using Microsoft.EntityFrameworkCore;
namespace hotelData.Data;
using hotelData.Data;


public class UserDbContex :DbContext
{
    //ffhgfjgjgjh

// hello buddy
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-G936QCF;Initial Catalog=hotelGithub;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
}
