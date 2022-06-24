namespace EAuction.Order.Infrastructure.Settings
{
    public interface IBidDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}