using BeamX_Task.Models;

namespace BeamX_Task.Services.UserServices
{
    public interface IUser
    {
        bool Login(User user);
        bool Registration(User user);
        User GetUserById(string id);
        User IsUserExit(User user);
    }
}
