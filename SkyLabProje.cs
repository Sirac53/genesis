using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
namespace Skylab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           while(true){

             var newsApiClient = new NewsApiClient("cc7539e648194a6d9029403c414713ab");
               
             Console.WriteLine("Bir metin GİRİN (Çıkmak için 'exit' yazabilirsiniz): ");
             string metin = Console.ReadLine();

              if (metin.ToLower() == "exit")
                     break;

               Console.WriteLine("Virgülle ayırarak Bir Tarih GİRİN (yyyy-MM-dd): ");
               string tarihBaslangic = Console.ReadLine();

               if (!DateTime.TryParse(tarihBaslangic, out DateTime tarih))
                {
                  Console.WriteLine("Geçersiz tarih dizimi. Lütfen yyyy-MM-dd formatında girin.");
                  continue; 
                 }


            
               
                var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
                {
                    Q = metin,
                    SortBy = SortBys.Popularity,
                    Language = Languages.EN,
                    From = DateTime.Parse(tarihBaslangic),
                    To= DateTime.Parse(tarihBaslangic)     
                }); 

                if (articlesResponse.Status == Statuses.Ok)
                {
                    
                    Console.WriteLine("Bulunan toplam makale: " + articlesResponse.TotalResults);
                    
                    foreach (var article in articlesResponse.Articles)
                    {
                        
                        Console.WriteLine("Article: " + article.Title);
                        
                        Console.WriteLine("Yazarı: " + article.Author);
                       
                        Console.WriteLine("Acıklaması " + article.Description);
                      
                        Console.WriteLine("Urlsi: " + article.Url);
                       
                        Console.WriteLine("Yayınlanma zamanı: " + article.PublishedAt);

                        Console.WriteLine("\n");

                    }
                }
                else
                {
                    Console.WriteLine("22,09,2023 ten 1 ay öncesine kadar ki articllara bakabilirsin sadece");
                }

                Console.ReadLine();
            }


            }
        }
    }
