using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace storeFinder
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<NearbySearchResponse> SearchNearbyStoresAsync(double latitude, double longitude, double radius);
    }

    // Data contracts are defined here for simplicity, but they can be in separate files
    [DataContract]
    public class NearbySearchResponse
    {
        [DataMember(Name = "places")]
        public List<Place> Places { get; set; }
    }

    [DataContract]
    public class Place
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "formattedAddress", IsRequired = false)] // Optional based on your FieldMask
        public string FormattedAddress { get; set; }

        [DataMember(Name = "types", IsRequired = false)] // Optional based on your FieldMask
        public List<string> Types { get; set; }
    }
}
