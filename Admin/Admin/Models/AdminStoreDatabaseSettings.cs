namespace Admin.Models
{
    public class AdminStoreDatabaseSettings : IAdminStoreDatabaseSettings
    {
        public string AdminHotelsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
