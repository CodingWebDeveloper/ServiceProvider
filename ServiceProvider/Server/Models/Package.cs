namespace ServiceProvider.Server.Models
{
    using ServiceProvider.Server.Models.Enums;
    using System.Collections.Generic;

    public class Package
    {
        public Package()
        {
            this.Materials = new HashSet<PackageMaterial>();
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public int DeliveryDays { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public double Price { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public TypeOfPackage PackageType { get; set; }

        public virtual ICollection<PackageMaterial> Materials { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
