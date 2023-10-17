using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sınav_2_soru1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal fiyat = 0, indirim = 0;
            string odeme, profil, indirimKodu;
            bool hata = false;

            Console.Write("Ürün fiyatını giriniz: ");
            if (!decimal.TryParse(Console.ReadLine(), out fiyat)) hata = true;

            Console.Write("Ödeme şeklini giriniz (N/K/T): ");
            odeme = Console.ReadLine().ToUpper();
            if (odeme != "N" && odeme != "K" && odeme != "T") hata = true;

            Console.Write("Müşteri profilini giriniz Gold(G)/Üye(U)/Standart(S) (boş bırakabilirsiniz): ");
            profil = Console.ReadLine().ToUpper();
            if (profil != "G" && profil != "U" && profil != "S" && profil != "") hata = true;

            Console.Write("Satış temsilcisi indirimini giriniz (1-3, boş bırakabilirsiniz): ");
            indirimKodu = Console.ReadLine();
            if (indirimKodu != "" && (!decimal.TryParse(indirimKodu, out indirim) || indirim < 1 || indirim > 3)) hata = true;

            if (hata)
            {
                Console.WriteLine("Hatalı veri girişi!!!");
                return;
            }

            decimal sonFiyat = fiyatBul(fiyat, odeme, profil, indirim);
            Console.WriteLine("Satış fiyatı: " + sonFiyat);
        }

        static decimal fiyatBul(decimal fiyat, string odeme, string profil = "", decimal indirim = 0)
        {
            decimal indirimOrani = 0;
            switch (odeme)
            {
                case "N":
                    indirimOrani += 5;
                    break;
                case "K":
                    indirimOrani += 3;
                    break;
                default:
                    break;
            }

            switch (profil)
            {
                case "G":
                    indirimOrani += 5;
                    break;
                case "U":
                    indirimOrani += 3;
                    break;
                case "S":
                    indirimOrani += 1;
                    break;
                default:
                    break;
            }

            indirimOrani += indirim;

            decimal indirimMiktari = fiyat * indirimOrani / 100;
            decimal sonFiyat = fiyat - indirimMiktari;

            return sonFiyat;
        }
    }
}