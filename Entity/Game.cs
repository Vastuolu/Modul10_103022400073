namespace Modul10_103022400073.Entity
{
    public class Game
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Developer { get; set; }
        public int TahunRilis { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string[] Platform { get; set; }
        public string[] Mode { get; set; }
        public bool IsOnline { get; set; }
        public int Harga { get; set; }

        public Game()
        {
            Id = 0;
            Nama = string.Empty;
            Developer = string.Empty;
            TahunRilis = 0;
            Genre = string.Empty;
            Rating = 0;
            IsOnline = false;
            Harga = 0;
        }
    }
}
