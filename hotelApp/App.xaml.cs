using hotelApp.ViewModels;
using hotelApp.Views;
using SimpleInjector;
using System.Windows;
using hotelApp.Services.Navigator;
using hotelData.Data;

namespace hotelApp
{
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        public App()
        {
            AddOtherServices();
            AddDatabaseServices(); // UserDbContex'i ekledik
            AddViews();
            AddViewModels();
        }

        private static void AddOtherServices()
        {
            Container.RegisterSingleton<INavigateService, NavigatorService>();
        }

        private static void AddDatabaseServices()
        {
            // UserDbContex'i kayıt ediyoruz
            Container.Register(() => new UserDbContex(), Lifestyle.Singleton);
        }

        private static void AddViewModels()
        {
            Container.RegisterSingleton<SelectConditionModel>();
            Container.RegisterSingleton<RoomPageModel>();
            Container.RegisterSingleton<RegisterPageModel>();
            Container.RegisterSingleton<MainPageModel>();
            

        }

        private static void AddViews()
        {
            Container.RegisterSingleton<mainPage>();
            Container.RegisterSingleton<SelectCondition>();
            Container.RegisterSingleton<RoomPage>();
            Container.RegisterSingleton<RegisterPage>();
            

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainView = Container.GetInstance<mainPage>();
            mainView.DataContext = Container.GetInstance<MainPageModel>();
            mainView.Show();
            base.OnStartup(e);
        }
    }
}
