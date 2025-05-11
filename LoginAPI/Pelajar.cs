namespace LoginAPI
{
    public class Pelajar
    {
        private string nama { get; set; }
        private string username { get; set; }
        private string password { get; set; }

        public Pelajar() { }

        public Pelajar(string nama, string username, string password)
        {
            this.nama = nama;
            this.username = username;
            this.password = password;
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
