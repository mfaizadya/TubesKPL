using System;

public class Admin
{
    private string username;
    private StatusLogin status;

    public enum StatusLogin
    {
        LoggedOut,
        LoggedIn
    }

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

    public void Logout(string command)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new InvalidOperationException("Username admin tidak valid.");
        }

        switch (Status)
        {
            case StatusLogin.LoggedIn:
                Status = StatusLogin.LoggedOut;
                Console.WriteLine($"{username} berhasil logout.");
                break;

            case StatusLogin.LoggedOut:
                Console.WriteLine("Admin sudah logout sebelumnya.");
                break;

            default:
                throw new InvalidOperationException("Status login admin tidak dikenali.");
        }
    }
}

