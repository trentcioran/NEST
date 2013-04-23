﻿using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Nest
{
	public partial class ElasticClient
	{
		/// <summary>
		/// Create an index with the specified index settings
		/// </summary>
		public IIndicesOperationResponse CreateIndex(string index, IndexSettings settings)
		{
			string data = JsonConvert.SerializeObject(settings, Formatting.None, SerializationSettings);
			return CreateIndexRaw(index, data);
		}
		/// <summary>
		/// Create an index with the specified index settings
		/// </summary>
		public IIndicesOperationResponse CreateIndex(string index, Func<CreateIndexDescriptor, CreateIndexDescriptor> createIndexSelector)
		{
			index.ThrowIfEmpty("index");
			createIndexSelector.ThrowIfNull("createIndexSelector");
			var d = createIndexSelector(new CreateIndexDescriptor(SerializationSettings));
			var settings = d._IndexSettings;
			return this.CreateIndex(index, settings);

		}


		public IIndicesOperationResponse CreateIndexRaw(string index, string settings)
		{
			string path = this.PathResolver.CreateIndexPath(index);
			var status = this.Connection.PostSync(path, settings);
			return this.ToParsedResponse<IndicesOperationResponse>(status);
		}
	}
}