using Microsoft.EntityFrameworkCore;
namespace WebApplication1.model
{
    public class ordercontext:DbContext
    {
        public ordercontext(DbContextOptions<ordercontext> options)
         : base(options)
        {
            this.Database.EnsureCreated(); //自动建库建表
        }
        public DbSet<order> order { get; set; }
    }
}
