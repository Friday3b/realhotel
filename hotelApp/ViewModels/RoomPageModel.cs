using hotelApp.Command;
using hotelData.Data;
using hotelData.Model;
using hotelApp.Services.Navigator;
using hotelApp.Views;

namespace hotelApp.ViewModels
{
    public class RoomPageModel : BaseViewModel
    {
        public UserDbContex _userDbContext;
        public RelayCommand AddRoomCommand { get; set; }
        private readonly INavigateService _navigationService;

        private int _roomNumber;
        public int RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged();
            }
        }

        private int _personCount;
        public int PersonCount
        {
            get => _personCount;
            set
            {
                _personCount = value;
                OnPropertyChanged();
            }
        }

        public RoomPageModel(INavigateService navigateService, UserDbContex dbContex)
        {
            _navigationService = navigateService;
            AddRoomCommand = new RelayCommand(AddRooms);
            _userDbContext = dbContex;
            //Console.WriteLine("heeeey");
        }

        private void AddRooms(object? obj)
        {
            try
            {
                var newRoom = new Room
                {
                    roomNum = RoomNumber,
                    roomCount = PersonCount
                };

                _userDbContext.Rooms.Add(newRoom);
                _userDbContext.SaveChanges(); // Veritabanına kaydet

                Console.WriteLine("Room added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding room: {ex.Message}");
            }
        }
    }
}
