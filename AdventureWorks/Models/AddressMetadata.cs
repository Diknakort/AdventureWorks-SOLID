using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Models
{
    [MetadataType(typeof(AddressMetadata))]
    public partial class Address { }
    
    
    public class AddressMetadata
    {

        /// <summary>
        /// Primary key for Address records.
        /// </summary>
        [Required]
        public int AddressId { get; set; }

        /// <summary>
        /// First street address line.
        /// </summary>
        public string AddressLine1 { get; set; } = null!;

        /// <summary>
        /// Second street address line.
        /// </summary>
        public string? AddressLine2 { get; set; }

        /// <summary>
        /// Name of the city.
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Unique identification number for the state or province. Foreign key to StateProvince table.
        /// </summary>
        public int StateProvinceId { get; set; }

        /// <summary>
        /// Postal code for the street address.
        /// </summary>
        /// 
        [Required]
        public string PostalCode { get; set; } = null!;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
