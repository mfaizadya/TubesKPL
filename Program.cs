class Program
{
    static void Main(string[] args)
    {
        Pelajar pelajar = new Pelajar("faiz123");
        Admin admin = new Admin("admin001");

        pelajar.Logout();
        admin.Logout();
    }
}
