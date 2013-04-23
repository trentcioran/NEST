using System;
using System.Collections.Generic;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{

	/// <summary>
	/// Sometimes you need a generic type mapping, i.e when using dynamic templates 
	/// in order to specify "{dynamic_template}" the type, or if you have some plugin that exposes a new type.
	/// </summary>
	public class GenericMapping : IElasticType, IElasticCoreType
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

    [JsonProperty("similarity")]
    public string Similarity { get; set; }

		/// <summary>
		/// The name of the field that will be stored in the index. Defaults to the property/field name.
		/// </summary>
		[JsonProperty("index_name")]
		public string IndexName { get; set; }

		[JsonProperty("store"), JsonConverter(typeof(YesNoBoolConverter))]
		public bool? Store { get; set; }

		[JsonProperty("index")]
		public string Index { get; set; }

		[JsonProperty("null_value")]
		public object NullValue { get; set; }

		[JsonProperty("boost")]
		public double? Boost { get; set; }

		[JsonProperty("include_in_all")]
		public bool? IncludeInAll { get; set; }

		[JsonProperty("term_vector")]
		public string TermVector { get; set; }

		[JsonProperty("omit_norms")]
		public bool? OmitNorms { get; set; }

		[JsonProperty("omit_term_freq_and_positions")]
		public bool? OmitTermFrequencyAndPositions { get; set; }

		[JsonProperty("index_analyzer")]
		public string IndexAnalyzer { get; set; }

		[JsonProperty("search_analyzer")]
		public string SearchAnalyzer { get; set; }

	}

	[Obsolete("Please switch to GenericMapping or a strict *Mapping class such as StringMapping/NumberMapping/MultiFieldMapping, will be removed in the 1.0 release")]
	public class TypeMappingProperty : GenericMapping
    {
       
    }
}