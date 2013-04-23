using System.Collections.Generic;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;

namespace Nest
{
	public class GeoPointMapping : IElasticType
	{
		[JsonIgnore]
		public string Name { get; set; }

		[JsonProperty("type")]
		public virtual string Type { get { return "geo_point"; } }

    [JsonProperty("similarity")]
    public string Similarity { get; set; }

		[JsonProperty("lat_lon")]
		public bool? IndexLatLon { get; set; }

		[JsonProperty("geohash")]
		public bool? IndexGeoHash { get; set; }

		[JsonProperty("geohash_precision")]
		public int? GeoHashPrecision { get; set; }
	}
}