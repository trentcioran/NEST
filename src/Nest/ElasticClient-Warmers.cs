﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Nest.Resolvers.Writers;

namespace Nest
{
	public partial class ElasticClient
	{


		public IIndicesOperationResponse PutWarmer(Func<PutWarmerDescriptor, PutWarmerDescriptor> selector)
		{
			selector.ThrowIfNull("selector");
			var descriptor = selector(new PutWarmerDescriptor(Settings));
			descriptor.ThrowIfNull("descriptor");

			var query = this.Serialize(descriptor._SearchDescriptor);

			var path = this.PathResolver.GetWarmerPath(descriptor);
			ConnectionStatus status = this.Connection.PutSync(path, query);
			var r = this.ToParsedResponse<IndicesOperationResponse>(status);

			return r;
		}

		/// <summary>
		/// Gets warmers, query will be returned as json string
		/// </summary>
		public IWarmerResponse GetWarmer(Func<GetWarmerDescriptor, GetWarmerDescriptor> selector)
		{
			selector.ThrowIfNull("selector");
			var descriptor = selector(new GetWarmerDescriptor(Settings));
			descriptor.ThrowIfNull("descriptor");
			var path = this.PathResolver.GetWarmerPath(descriptor);

			ConnectionStatus status = this.Connection.GetSync(path);
			var r = this.ToParsedResponse<WarmerResponse>(status);
			return r;
		}

		/// <summary>
		/// Delete warmers
		/// </summary>
		public IIndicesOperationResponse DeleteWarmer(Func<GetWarmerDescriptor, GetWarmerDescriptor> selector)
		{
			selector.ThrowIfNull("selector");
			var descriptor = selector(new GetWarmerDescriptor(Settings));
			descriptor.ThrowIfNull("descriptor");
			var path = this.PathResolver.GetWarmerPath(descriptor);

			ConnectionStatus status = this.Connection.DeleteSync(path);
			var r = this.ToParsedResponse<IndicesOperationResponse>(status);
			return r;
		}

	}
}