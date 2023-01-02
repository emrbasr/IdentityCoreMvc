using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityCoreMvc.Identites
{
    public class MyIdentityDbContext : IdentityDbContext<MyUser, IdentityRole<int>, int>
    {
        //InheritAlinan IdentityDbContext'in constructor ını tetiklemek i.in
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasOne(p => p.User).WithMany(p => p.Kategoriler).HasForeignKey(p => p.UserId);


            builder.Entity<MyUser>().ToTable("user");
            builder.Entity<IdentityRole<int>>().ToTable("role");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("roleclaim");
            builder.Entity<IdentityUserRole<int>>().ToTable("userrole");
            builder.Entity<IdentityUserClaim<int>>().ToTable("userclaim");
            builder.Entity<IdentityUserLogin<int>>().ToTable("userlogin");
            builder.Entity<IdentityUserToken<int>>().ToTable("usertoken");
        }
    }
}
