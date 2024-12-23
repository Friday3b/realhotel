using hotelApp.Command;
using hotelApp.Services.Navigator;
using hotelApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace hotelApp.ViewModels
{
    public class SelectConditionModel :BaseViewModel
    {
        public RelayCommand GetRoomCommand { get; set; }
        public RelayCommand GetRegisterCommand { get; set; }
        public RelayCommand BackToMainCommand { get; set; }
        private readonly INavigateService _navigationServices;



        public SelectConditionModel(INavigateService navigationServices)
        {
            _navigationServices = navigationServices;
            GetRoomCommand = new RelayCommand(GetRoom);
            GetRegisterCommand = new RelayCommand(GetRegister);
            BackToMainCommand = new RelayCommand(GetMain);
        }

        private void GetMain(object? obj)
        {
            _navigationServices.Navigate<SelectCondition, SelectConditionModel>();
        }

        private void GetRegister(object? obj)
        {
            _navigationServices.Navigate<RegisterPage, RegisterPageModel>();
        }

        private void GetRoom(object? obj)
        {
            _navigationServices.Navigate<RoomPage, RoomPageModel>(); 


        }
    }
}
