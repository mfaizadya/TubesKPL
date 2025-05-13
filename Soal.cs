using System;
using System.Collections.Generic;

public enum JenisSoal { Esai, PilihanGanda }

public class Soal
{
    public int Id { get; set; }
    public JenisSoal Jenis { get; set; }
    public string Pertanyaan { get; set; }
    public string Jawaban { get; set; }
    public List<string>? Opsi { get; set; }
}


