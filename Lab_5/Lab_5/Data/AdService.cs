using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5.Data
{
    public class AdService
    {
        private static readonly string[] Summaries = new[]
        {
            "Фен Kenwood", "Магнитофон AKG", "Ноутбук ACER", "Монитор BENQ", "Видеокарта NVidia", "Наушники Beats", "Телевизор Samsung", "Микроволновка Electrolux"
        };

        public Task<Ad[]> GetAdsAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Ad
            {
                PublishDate = DateTime.Today.AddDays(index * (-10)),
                Price = rng.Next(15, 1555),
                Name = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
