using System;

public class LogoutPelajar
{
    private string username;
    private StatusLogin status;

    public enum StatusLogin
    {
        LoggedOut,
        LoggedIn
    }

    public LogoutPelajar(string username)
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
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new InvalidOperationException("Username pelajar tidak valid.");
        }

        switch (Status)
        {
            case StatusLogin.LoggedIn:
                Status = StatusLogin.LoggedOut;
                Console.WriteLine($"{username} berhasil logout.");
                break;

            case StatusLogin.LoggedOut:
                Console.WriteLine("Pelajar sudah logout sebelumnya.");
                break;

            default:
                throw new InvalidOperationException("Status login pelajar tidak dikenali.");
        }
    }
}
