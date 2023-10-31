// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        int bakiye = 1000;
        int denemeSayısı = 0;
        bool acilDurum = true;

        string logFilePath = @"C:\Users\ibrah\source\repos\ATMapp\uygulama.log"; // Logları bu dosyaya kaydet

        if (!File.Exists(logFilePath))
        {
            using (File.Create(logFilePath)) { }
        }


        List<Tuple<string>> customers = new List<Tuple<string>>()
        {

            new Tuple<string>("patika")
        };

        while (acilDurum)
        {


            Console.WriteLine("Lütfen giriş yapınız..");

            string input = Console.ReadLine().ToLower();

            using (StreamWriter logFile = File.AppendText(logFilePath))
            {

                if (customers.Exists(c => c.Item1.ToLower() == input))
                {


                    Console.WriteLine("Yapmak istediğiniz işlemi seçin");
                    Console.WriteLine("1 - Bakiye sorgula\n2 - Para çek\n3 - Para yatır\nQ - Çıkış yap");

                    string choice = Console.ReadLine().ToLower();

                    // Loglama için bir metin dosyası oluştur

                    logFile.WriteLine($"{DateTime.Now} - Kullanıcı işlemi: {choice}");

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Mevcut bakiyeniz : {bakiye}TL");
                            logFile.WriteLine("Bakiye sorgulama işlemi gerçekleştirildi.");

                            break;
                        case "2":
                            Console.WriteLine("Çekmek istediğiniz tutarı giriniz.");
                            int CekilecekTutar = int.Parse(Console.ReadLine());

                            if (CekilecekTutar < bakiye)
                            {
                                Console.WriteLine($"Hesabınızdan {CekilecekTutar}TL değerinde para çıkışı yapılıyor.");
                                Console.WriteLine($"Hesabınızın mevcut bakiyesi {bakiye - CekilecekTutar}TL değerindedir.");
                                logFile.WriteLine($"Para çekme işlemi gerçekleştirildi. Çekilen tutar: {CekilecekTutar}");

                            }
                            else
                            {
                                Console.WriteLine("Bakiyenizden daha büyük bir tutar çekemezsiniz!!!");
                                logFile.WriteLine("Para çekme işlemi başarısız oldu. Çekilen tutar: " + CekilecekTutar);
                            }
                            break;
                        case "3":
                            Console.WriteLine("Yatırmak istediğiniz tutarı giriniz.");
                            int yatirilanTutar = int.Parse(Console.ReadLine());

                            Console.WriteLine($"Paranız hesaba yatırıldı. Mevcut bakiyeniz {bakiye + yatirilanTutar}TL'dir.");
                            logFile.WriteLine($"Para yatırma işlemi gerçekleştirildi. Yatırılan tutar: {yatirilanTutar}");

                            break;
                        case "q":
                            Console.WriteLine("Çıkış yapılıyor..");
                            logFile.WriteLine("Uygulama çıkış yaptı.");

                            break;
                        default:
                            break;
                    }
                }



                else
                {
                    Console.WriteLine("yanlış girdi!!");

                    denemeSayısı += 1;
                    logFile.WriteLine("Başarısız giriş denemesi " + denemeSayısı);

                    if (denemeSayısı > 2) //3 yanlış denemede hesap bloke edilir.
                    {
                        Console.WriteLine("Hesabınız bloke edildi.");
                        acilDurum = false;
                    }
                }

            }
        }


    }
}

