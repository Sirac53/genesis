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

            Console.WriteLine("Bir  metin GİRİN: ");
            string metin = Console.ReadLine();
            Console.WriteLine("Virgülle ayırarak Bir  Tarih GİRİN: ");
            string tarihBaslangic= Console.ReadLine();


            {
                var newsApiClient = new NewsApiClient("cc7539e648194a6d9029403c414713ab");
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
                    Console.WriteLine("Hata mesajı: " + articlesResponse.Error.Message);
                }

                Console.ReadLine();
            }


            }
        }
    }
