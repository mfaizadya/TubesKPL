using System;
using System.Collections.Generic;


public class KelolSoalAdmin
{
    private readonly Dictionary<(AksiSoal, JenisSoal), Action<Soal>> aksiTable;

    public KelolSoalAdmin()
    {
        aksiTable = new Dictionary<(AksiSoal, JenisSoal), Action<Soal>>
        {
            { (AksiSoal.Tambah, JenisSoal.Esai), TambahSoalEsai },
            { (AksiSoal.Tambah, JenisSoal.PilihanGanda), TambahSoalPG },
            { (AksiSoal.Ubah, JenisSoal.Esai), UbahSoalEsai },
            { (AksiSoal.Ubah, JenisSoal.PilihanGanda), UbahSoalPG },
            { (AksiSoal.Hapus, JenisSoal.Esai), HapusSoalEsai },
            { (AksiSoal.Hapus, JenisSoal.PilihanGanda), HapusSoalPG }
        };
    }

    public void KelolaSoal(AksiSoal aksi, JenisSoal jenis, Soal data)
    {
        if (aksiTable.TryGetValue((aksi, jenis), out var aksiFunc))
        {
            aksiFunc(data);
        }
        else
        {
            Console.WriteLine("Aksi tidak dikenali.");
        }
    }

    private void TambahSoalEsai(Soal soal) 
    {
        Console.WriteLine($"[Tambah Esai] {soal.Pertanyaan} -> {soal.Jawaban}");
            
    }
    private void TambahSoalPG(Soal soal) 
    {
        Console.WriteLine($"[Tambah PG] {soal.Pertanyaan} | Opsi: {string.Join(", ", soal.Opsi)}");
    }
    private void UbahSoalEsai(Soal soal) 
    {
        Console.WriteLine($"[Ubah Esai] ID: {soal.Id}, Pertanyaan Baru: {soal.Pertanyaan}");
    }
    private void UbahSoalPG(Soal soal) 
    {
        Console.WriteLine($"[Ubah PG] ID: {soal.Id}, Opsi Baru: {string.Join(", ", soal.Opsi)}");
    }
    private void HapusSoalEsai(Soal soal) 
    {
        Console.WriteLine($"[Hapus Esai] ID: {soal.Id}");
    }
    private void HapusSoalPG(Soal soal) 
    {
        Console.WriteLine($"[Hapus PG] ID: {soal.Id}");
    }
}
