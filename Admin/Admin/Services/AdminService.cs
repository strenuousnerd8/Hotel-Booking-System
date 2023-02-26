using Admin.Models;
using MongoDB.Driver;

namespace Admin.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMongoCollection<Hotel> _listings;

        public AdminService(IAdminStoreDatabaseSettings settings, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _listings = database.GetCollection<Hotel>(settings.AdminHotelsCollectionName);
        }

        public Hotel Create(Hotel hotel)
        {
            _listings.InsertOne(hotel);
            return hotel;
        }

        public List<Hotel> Get()
        {
            return _listings.Find(hotel => true).ToList();
        }

        public Hotel Get(string id)
        {
            return _listings.Find(hotel => hotel.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _listings.DeleteOne(hotel => hotel.Id == id);
        }

        public void Update(string id, Hotel hotel)
        {
            _listings.ReplaceOne(hotel => hotel.Id == id, hotel);
        }
    }
}
