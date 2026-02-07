using System;
using System.Linq;
using System.Text;

class Sezar
{
    // Türkçe alfabenin hem küçük hem büyük halini tanımlıyoruz
    static readonly string alfabeKucuk = "abcçdefgğhıijklmnoöprsştuüvyz";
    static readonly string alfabeBuyuk = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== SEZAR ŞİFRELEME SİSTEMİ ===");
        Console.WriteLine("1 - Şifre Çöz");
        Console.WriteLine("2 - Şifrele");
        Console.Write("\nİşlem seçiniz(1-2): ");
        string secim = Console.ReadLine();

        Console.Write("Metni giriniz: ");
        string metin = Console.ReadLine();

        Console.Write("Anahtar sayı: ");
        if (!int.TryParse(Console.ReadLine(), out int anahtar)) anahtar = 0;

        // Kullanıcı 1'i seçerse anahtarı negatife çevirerek "çözme" işlemi yapıyoruz
        if (secim == "1")
        {
            string sonuc = IslemYap(metin, -anahtar);
            Console.WriteLine($"\nÇözülmüş Metin: {sonuc}");
        }
        else if (secim == "2")
        {
            string sonuc = IslemYap(metin, anahtar);
            Console.WriteLine($"\nŞifrelenmiş Metin: {sonuc}");
        }
        else
        {
            Console.WriteLine("Geçersiz seçim yaptınız.");
        }

        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    static string IslemYap(string input, int key)
    {
        char[] buffer = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            // Küçük harf kontrolü
            if (alfabeKucuk.Contains(c))
            {
                int index = alfabeKucuk.IndexOf(c);
                int yeniIndex = (index + key) % 29;
                if (yeniIndex < 0) yeniIndex += 29;
                buffer[i] = alfabeKucuk[yeniIndex];
            }
            // Büyük harf kontrolü
            else if (alfabeBuyuk.Contains(c))
            {
                int index = alfabeBuyuk.IndexOf(c);
                int yeniIndex = (index + key) % 29;
                if (yeniIndex < 0) yeniIndex += 29;
                buffer[i] = alfabeBuyuk[yeniIndex];
            }
            // Harf dışındaki karakterleri (boşluk, nokta vb.) aynen bırak
            else
            {
                buffer[i] = c;
            }
        }
        return new string(buffer);
    }

}
