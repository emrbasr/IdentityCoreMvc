namespace IdentityCoreMvc.Identites
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoriName { get; set; }
        public int? UserId { get; set; }
        public MyUser? User { get; set; }
    }
}
