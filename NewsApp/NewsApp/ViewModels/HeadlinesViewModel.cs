using NewsApp.Models;
using NewsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class HeadlinesViewModel: ViewModel
    {
        private readonly NewsService Service;
        public ICommand ItemSelected =>
            new Command(async (selectedItem) =>
            {
                var selectedArticle = selectedItem as Article;
                var url = HttpUtility.UrlEncode(selectedArticle.Url);

            });
        public NewsResult CurrentNews { get; set; }
        public HeadlinesViewModel(NewsService service)
        {
            this.Service = service;
        }

        public async Task Initialize(NewsScope scope)
        {
            CurrentNews = await Service.GetNews(scope);
        }

        public async Task Initialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "local" => NewsScope.Local,
                "global" => NewsScope.Global,
                "headlines" => NewsScope.Headlines,
                _ => NewsScope.Headlines
            };
            await Initialize(resolvedScope);
        }

        
    }
}
