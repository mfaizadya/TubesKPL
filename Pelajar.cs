using System;

public class Pelajar
{
    private string username;
    private StatusLogin status;

    public enum StatusLogin
    {
        LoggedOut,
        LoggedIn
    }

    public Pelajar(string username)
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
            Console.WriteLine($"{username} berhasil logout.");
        }
        else
        {
            Console.WriteLine($"{username} tidak dapat logout karena belum login.");
        }
    }
}
