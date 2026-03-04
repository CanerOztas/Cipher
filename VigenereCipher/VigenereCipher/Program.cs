// Anahtardaki her bir harfin alfabedeki sırası alınarak(a=0'dan başlanır) şifrelenmiş koddaki o harfe denk gelen harf,
// alfabedeki sayı kadar ilerletilerek şifrelenir.
using System;
using System.Linq;
using System.Text;

namespace VigenereApp
{
    class Program
    {
        // Türkçe alfabe
        static readonly string alfabeKucuk = "abcçdefgğhıijklmnoöprsştuüvyz";
        static readonly string alfabeBuyuk = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== VIGENERE ŞİFRELEME SİSTEMİ ===");
            Console.WriteLine("1 - Şifre Çöz");
            Console.WriteLine("2 - Şifrele");
            Console.Write("\nİşlem seçiniz(1-2): ");

            // Null dönme ihtimaline karşı varsayılan olarak boş string ("") atıyoruz
            string secim = Console.ReadLine() ?? "";

            Console.Write("Metni giriniz: ");
            string metin = Console.ReadLine() ?? "";

            Console.Write("Anahtar kelime: ");
            string anahtar = Console.ReadLine() ?? "a";
            if (string.IsNullOrEmpty(anahtar)) anahtar = "a";

            if (secim == "1")
            {
                string sonuc = IslemYap(metin, anahtar, -1);
                Console.WriteLine($"\nÇözülmüş Metin: {sonuc}");
            }
            else if (secim == "2")
            {
                string sonuc = IslemYap(metin, anahtar, 1);
                Console.WriteLine($"\nŞifrelenmiş Metin: {sonuc}");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim yaptınız.");
            }

            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        static string IslemYap(string input, string key, int islemYonu)
        {
            // Eğer boş bir metin gönderildiyse doğrudan geri döndür
            if (string.IsNullOrEmpty(input)) return "";

            char[] buffer = new char[input.Length];
            int anahtarIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (alfabeKucuk.Contains(c))
                {
                    int index = alfabeKucuk.IndexOf(c);
                    char anahtarHarfi = char.ToLower(key[anahtarIndex % key.Length]);
                    int kaydirma = alfabeKucuk.IndexOf(anahtarHarfi);
                    if (kaydirma == -1) kaydirma = 0;

                    int yeniIndex = (index + (kaydirma * islemYonu)) % 29;
                    if (yeniIndex < 0) yeniIndex += 29;

                    buffer[i] = alfabeKucuk[yeniIndex];
                    anahtarIndex++;
                }
                else if (alfabeBuyuk.Contains(c))
                {
                    int index = alfabeBuyuk.IndexOf(c);
                    char anahtarHarfi = char.ToLower(key[anahtarIndex % key.Length]);
                    int kaydirma = alfabeKucuk.IndexOf(anahtarHarfi);
                    if (kaydirma == -1) kaydirma = 0;

                    int yeniIndex = (index + (kaydirma * islemYonu)) % 29;
                    if (yeniIndex < 0) yeniIndex += 29;

                    buffer[i] = alfabeBuyuk[yeniIndex];
                    anahtarIndex++;
                }
                else
                {
                    buffer[i] = c;
                }
            }
            return new string(buffer);
        }
    }
}