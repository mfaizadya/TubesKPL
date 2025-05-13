using System;
using static Pelajar;

public class Admin
{
    private string username;
    private StatusLogin status;

    public Admin(string username)
    {
        this.username = username;
        this.status = StatusLogin.LoggedIn;
    }

    public StatusLogin Status
    {
        get { return status; }
        private set { status = value; }
    }

    public void Logout()
    {
        if (status == StatusLogin.LoggedIn)
        {
            status = StatusLogin.LoggedOut;
            Console.WriteLine($"Admin '{username}' berhasil logout.");
        }
        else
        {
            Console.WriteLine($"Admin '{username}' tidak dapat logout karena belum login.");
        }
    }
}

