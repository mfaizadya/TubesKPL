using System;
using System.Collections.Generic;

public enum AksiSoal { Tambah, Ubah, Hapus }

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

    private void TambahSoalEsai(Soal soal) {  }
    private void TambahSoalPG(Soal soal) {  }
    private void UbahSoalEsai(Soal soal) {  }
    private void UbahSoalPG(Soal soal) {  }
    private void HapusSoalEsai(Soal soal) {  }
    private void HapusSoalPG(Soal soal) { }
}
