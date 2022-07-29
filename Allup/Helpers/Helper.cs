namespace Allup.Helpers
{
    
    public static class Helper
    {
        public static void DeleteImage(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
    public enum UserRoles
    {
        SuperAdmin,
        Admin,
        Member,

    }
    public enum OrderStatus
    {
        Pending,
        Shipped,
    }
}
