using Pratik_IMDB_Listesi;

class Program
{
    static void Main(string[] args)
    {
        List<Film> filmListesi = new List<Film>();
        string devamEt;

        do
        {
            // Kullanıcıdan film adı alınır
            Console.Write("Film adı girin: ");
            string filmIsim = Console.ReadLine();

            double imdbPuani = -1; // Geçersiz bir başlangıç değeri
            bool gecerliPuan = false;

            // Kullanıcıdan geçerli bir IMDB puanı alınır
            while (!gecerliPuan)
            {
                Console.Write("IMDB puanı girin (0-10 arasında bir sayı): ");
                string puanGirdi = Console.ReadLine();

                // Kullanıcının girdiği değeri sayıya dönüştürme
                if (IsNumber(puanGirdi))
                {
                    imdbPuani = Convert.ToDouble(puanGirdi);

                    // IMDB puanının aralıkta olup olmadığını kontrol etme
                    if (imdbPuani >= 0 && imdbPuani <= 10)
                    {
                        gecerliPuan = true;
                    }
                    else
                    {
                        Console.WriteLine("IMDB puanı 0 ile 10 arasında olmalıdır.");
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir sayı girin.");
                }
            }

            // Film nesnesi oluşturulup listeye eklenir
            Film film = new Film(filmIsim, imdbPuani);
            filmListesi.Add(film);

            // Kullanıcıya yeni film eklemek isteyip istemediği sorulur
            Console.Write("\n***** Yeni bir film eklemek istiyorsanız konsola (Evet) yazınız. *****");
            devamEt = Console.ReadLine().Trim().ToLower();

        } while (devamEt == "evet");

        // Bütün filmleri listele
        Console.WriteLine("\nBütün Filmler:");
        foreach (var film in filmListesi)
        {
            Console.WriteLine(film);
        }

        // IMDB puanı 4 ile 9 arasında olan filmleri listele
        Console.WriteLine("\nIMDB puanı 4 ile 9 arasında olan Filmler:");
        foreach (var film in filmListesi)
        {
            if (film.ImdbPuani >= 4 && film.ImdbPuani <= 9)
            {
                Console.WriteLine(film);
            }
        }

        // İsmi 'A' ile başlayan filmleri listele
        Console.WriteLine("\nİsmi 'A' ile başlayan Filmler:");
        foreach (var film in filmListesi)
        {
            if (film.Isim.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(film);
            }
        }
    }

    // Kullanıcının girdiği değeri sayıya dönüştürüp dönüştüremediğini kontrol eden yardımcı metod
    static bool IsNumber(string input)
    {
        double number;
        return double.TryParse(input, out number);
    }
}