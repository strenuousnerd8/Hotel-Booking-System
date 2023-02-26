namespace Admin.Models
{
    public interface IAdminStoreDatabaseSettings
    {
        string AdminHotelsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
