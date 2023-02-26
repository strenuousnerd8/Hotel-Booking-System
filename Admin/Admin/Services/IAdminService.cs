using Admin.Models;

namespace Admin.Services
{
    public interface IAdminService
    {
        List<Hotel> Get();
        Hotel Get(string id);
        Hotel Create(Hotel hotel);
        void Update(string id, Hotel hotel);
        void Remove(string id);
    }
}
