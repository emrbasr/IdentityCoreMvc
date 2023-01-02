using Microsoft.AspNetCore.Identity;

namespace IdentityCoreMvc.Identites
{
    public class MyUser : IdentityUser<int>
    {

        public string? TcNo { get; set; }

        public ICollection<Category>? Kategoriler { get; set; }

    }
}
