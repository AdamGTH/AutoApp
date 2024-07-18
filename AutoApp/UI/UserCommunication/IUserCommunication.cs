namespace AutoApp.UI.UserCommunication
{
    public interface IUserCommunication
    {
        void AddCar();
        void RemoveCar();
        void ReadAllCars();
        void UpdateCar();
        void ReadById();
        void ReadCarsFromFileAndAddToDB();


    }
}
