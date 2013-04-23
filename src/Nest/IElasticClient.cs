﻿using System;
using System.Threading.Tasks;
using Nest.Domain;
using System.Collections.Generic;
namespace Nest
{
	public interface IElasticClient
	{
		bool IsValid { get; }
		IConnectionSettings Settings { get; }

		IIndicesOperationResponse Alias(AliasParams aliasParams);
		IIndicesOperationResponse Alias(IEnumerable<AliasParams> aliases);
		IIndicesOperationResponse Alias(IEnumerable<string> aliases);
		IIndicesOperationResponse Alias(IEnumerable<string> indices, string alias);
		IIndicesOperationResponse Alias(string alias);
		IIndicesOperationResponse Alias(string index, IEnumerable<string> aliases);
		IIndicesOperationResponse Alias(string index, string alias);

		IBulkResponse Bulk(Func<BulkDescriptor, BulkDescriptor> bulkSelector);
		IBulkResponse Bulk(BulkDescriptor bulkDescriptor);



		IAnalyzeResponse Analyze(AnalyzeParams analyzeParams, string text);
		IAnalyzeResponse Analyze(string text);
		IAnalyzeResponse Analyze<T>(System.Linq.Expressions.Expression<Func<T, object>> selector, string index, string text) where T : class;
		IAnalyzeResponse Analyze<T>(System.Linq.Expressions.Expression<Func<T, object>> selector, string text) where T : class;

		IIndicesResponse ClearCache();
		IIndicesResponse ClearCache(ClearCacheOptions options);
		IIndicesResponse ClearCache(IEnumerable<string> indices, ClearCacheOptions options);
		IIndicesResponse ClearCache<T>() where T : class;
		IIndicesResponse ClearCache<T>(ClearCacheOptions options) where T : class;

		IIndicesOperationResponse CloseIndex(string index);
		IIndicesOperationResponse CloseIndex<T>() where T : class;

		ICountResponse Count(Func<QueryDescriptor, BaseQuery> querySelector);
		ICountResponse Count(IEnumerable<string> indices, Func<QueryDescriptor, BaseQuery> querySelector);
		ICountResponse Count(IEnumerable<string> indices, IEnumerable<string> types, Func<QueryDescriptor, BaseQuery> querySelector);
		ICountResponse CountRaw(string query);

		ICountResponse Count<T>(Func<QueryDescriptor<T>, BaseQuery> querySelector) where T : class;
		ICountResponse Count<T>(IEnumerable<string> indices, Func<QueryDescriptor<T>, BaseQuery> querySelector) where T : class;
		ICountResponse Count<T>(IEnumerable<string> indices, IEnumerable<string> types, Func<QueryDescriptor<T>, BaseQuery> querySelector) where T : class;
		ICountResponse CountRaw<T>(string query) where T : class;

		ICountResponse CountAll(Func<QueryDescriptor, BaseQuery> querySelector);
		ICountResponse CountAllRaw(string query);

		ICountResponse CountAll<T>(Func<QueryDescriptor<T>, BaseQuery> querySelector) where T : class;

		IIndicesOperationResponse CreateIndex(string index, IndexSettings settings);
		IIndicesOperationResponse CreateIndex(string index, Func<CreateIndexDescriptor, CreateIndexDescriptor> createIndexSelector);
		IIndicesOperationResponse CreateIndexRaw(string index, string settings);

		IBulkResponse DeleteMany<T>(IEnumerable<BulkParameters<T>> objects) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<BulkParameters<T>> objects, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<BulkParameters<T>> objects, string index) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<BulkParameters<T>> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<BulkParameters<T>> objects, string index, string type) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<BulkParameters<T>> objects, string index, string type, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<T> objects) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<T> objects, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<T> objects, string index) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<T> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<T> objects, string index, string type) where T : class;
		IBulkResponse DeleteMany<T>(IEnumerable<T> objects, string index, string type, SimpleBulkParameters bulkParameters) where T : class;

		IDeleteResponse Delete<T>(T @object) where T : class;
		IDeleteResponse Delete<T>(T @object, DeleteParameters deleteParameters) where T : class;
		IDeleteResponse Delete<T>(T @object, string index) where T : class;
		IDeleteResponse Delete<T>(T @object, string index, DeleteParameters deleteParameters) where T : class;
		IDeleteResponse Delete<T>(T @object, string index, string type) where T : class;
		IDeleteResponse Delete<T>(T @object, string index, string type, DeleteParameters deleteParameters) where T : class;

		Task<IDeleteResponse> DeleteAsync<T>(T @object) where T : class;
		Task<IDeleteResponse> DeleteAsync<T>(T @object, DeleteParameters deleteParameters) where T : class;
		Task<IDeleteResponse> DeleteAsync<T>(T @object, string index) where T : class;
		Task<IDeleteResponse> DeleteAsync<T>(T @object, string index, DeleteParameters deleteParameters) where T : class;
		Task<IDeleteResponse> DeleteAsync<T>(T @object, string index, string type) where T : class;
		Task<IDeleteResponse> DeleteAsync<T>(T @object, string index, string type, DeleteParameters deleteParameters) where T : class;

		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<BulkParameters<T>> objects) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<BulkParameters<T>> objects, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index, SimpleBulkParameters bulkParameters, string type) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index, string type) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<T> objects) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<T> objects, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<T> objects, string index) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<T> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<T> objects, string index, SimpleBulkParameters bulkParameters, string type) where T : class;
		Task<IBulkResponse> DeleteManyAsync<T>(IEnumerable<T> objects, string index, string type) where T : class;


		IDeleteResponse DeleteById(string index, string type, int id);
		IDeleteResponse DeleteById(string index, string type, int id, DeleteParameters deleteParameters);
		IDeleteResponse DeleteById(string index, string type, string id);
		IDeleteResponse DeleteById(string index, string type, string id, DeleteParameters deleteParameters);
		IDeleteResponse DeleteById<T>(int id) where T : class;
		IDeleteResponse DeleteById<T>(int id, DeleteParameters deleteParameters) where T : class;
		IDeleteResponse DeleteById<T>(string id) where T : class;
		IDeleteResponse DeleteById<T>(string id, DeleteParameters deleteParameters) where T : class;
		Task<IDeleteResponse> DeleteByIdAsync(string index, string type, int id);
		Task<IDeleteResponse> DeleteByIdAsync(string index, string type, int id, DeleteParameters deleteParameters);
		Task<IDeleteResponse> DeleteByIdAsync(string index, string type, string id);
		Task<IDeleteResponse> DeleteByIdAsync(string index, string type, string id, DeleteParameters deleteParameters);
		Task<IDeleteResponse> DeleteByIdAsync<T>(int id) where T : class;
		Task<IDeleteResponse> DeleteByIdAsync<T>(int id, DeleteParameters deleteParameters) where T : class;
		Task<IDeleteResponse> DeleteByIdAsync<T>(string id) where T : class;
		Task<IDeleteResponse> DeleteByIdAsync<T>(string id, DeleteParameters deleteParameters) where T : class;

		IDeleteResponse DeleteByQuery(Action<RoutingQueryPathDescriptor> query, DeleteByQueryParameters parameters = null);
		IDeleteResponse DeleteByQueryRaw(string query, DeleteByQueryParameters parameters = null);
		IDeleteResponse DeleteByQuery<T>(Action<RoutingQueryPathDescriptor<T>> query, DeleteByQueryParameters parameters = null) where T : class;

		Task<IDeleteResponse> DeleteByQueryAsync(Action<RoutingQueryPathDescriptor> query, DeleteByQueryParameters parameters = null);
		Task<IDeleteResponse> DeleteByQueryRawAsync(string query, DeleteByQueryParameters parameters = null);
		Task<IDeleteResponse> DeleteByQueryAsync<T>(Action<RoutingQueryPathDescriptor<T>> query, DeleteByQueryParameters parameters = null) where T : class;

		IIndicesResponse DeleteIndex(string index);
		IIndicesResponse DeleteIndex<T>() where T : class;

		IIndicesResponse DeleteMapping<T>() where T : class;
		IIndicesResponse DeleteMapping<T>(string index) where T : class;
		IIndicesResponse DeleteMapping<T>(string index, string type) where T : class;

		IIndicesResponse DeleteMapping(Type t);
		IIndicesResponse DeleteMapping(Type t, string index);
		IIndicesResponse DeleteMapping(Type t, string index, string type);

		IIndicesOperationResponse Flush(bool refresh = false);
		IIndicesOperationResponse Flush(IEnumerable<string> indices, bool refresh = false);
		IIndicesOperationResponse Flush(string index, bool refresh = false);
		IIndicesOperationResponse Flush<T>(bool refresh = false) where T : class;

		T Get<T>(int id) where T : class;
		T Get<T>(string id) where T : class;
		T Get<T>(string index, string type, int id) where T : class;
		T Get<T>(string index, string type, string id) where T : class;
		T Get<T>(Action<GetDescriptor<T>> getSelector) where T : class;

		FieldSelection<T> GetFieldSelection<T>(Action<GetDescriptor<T>> getSelector) where T : class;

		IGetResponse<T> GetFull<T>(int id) where T : class;
		IGetResponse<T> GetFull<T>(string id) where T : class;
		IGetResponse<T> GetFull<T>(string index, string type, int id) where T : class;
		IGetResponse<T> GetFull<T>(string index, string type, string id) where T : class;
		IGetResponse<T> GetFull<T>(Action<GetDescriptor<T>> getSelector) where T : class;

		IEnumerable<T> MultiGet<T>(IEnumerable<int> ids) where T : class;
		IEnumerable<T> MultiGet<T>(IEnumerable<string> ids) where T : class;
		IEnumerable<T> MultiGet<T>(string index, string type, IEnumerable<int> ids) where T : class;
		IEnumerable<T> MultiGet<T>(string index, string type, IEnumerable<string> ids) where T : class;

		MultiGetResponse MultiGetFull(Action<MultiGetDescriptor> multiGetSelector);

		IQueryResponse<T> MoreLikeThis<T>(Func<MoreLikeThisDescriptor<T>, MoreLikeThisDescriptor<T>> mltSelector)
			where T : class;

		MultiSearchResponse MultiSearch(Func<MultiSearchDescriptor, MultiSearchDescriptor> multiSearchSelector);
		MultiSearchResponse MultiSearch(MultiSearchDescriptor multiSearchSelector);

		IIndexSettingsResponse GetIndexSettings();
		IIndexSettingsResponse GetIndexSettings(string index);

		IEnumerable<string> GetIndicesPointingToAlias(string alias);

		RootObjectMapping GetMapping(string index, string type);
		RootObjectMapping GetMapping<T>() where T : class;
		RootObjectMapping GetMapping<T>(string index) where T : class;
		RootObjectMapping GetMapping(Type t);
		RootObjectMapping GetMapping(Type t, string index);

		IHealthResponse Health(HealthLevel level);
		IHealthResponse Health(IEnumerable<string> indices, HealthLevel level);
		IHealthResponse Health(HealthParams healthParams);
		IHealthResponse Health(IEnumerable<string> indices, HealthParams healthParams);

		IBulkResponse IndexMany<T>(IEnumerable<BulkParameters<T>> objects) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<BulkParameters<T>> objects, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<BulkParameters<T>> objects, string index) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<BulkParameters<T>> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<BulkParameters<T>> objects, string index, string type) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<BulkParameters<T>> objects, string index, string type, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<T> objects) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<T> objects, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<T> objects, string index) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<T> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<T> objects, string index, string type) where T : class;
		IBulkResponse IndexMany<T>(IEnumerable<T> objects, string index, string type, SimpleBulkParameters bulkParameters) where T : class;

		IIndexResponse Index<T>(T @object) where T : class;
		IIndexResponse Index<T>(T @object, IndexParameters indexParameters) where T : class;
		IIndexResponse Index<T>(T @object, string index) where T : class;
		IIndexResponse Index<T>(T @object, string index, IndexParameters indexParameters) where T : class;
		IIndexResponse Index<T>(T @object, string index, string type) where T : class;
		IIndexResponse Index<T>(T @object, string index = null, string type = null, IndexParameters indexParameters = null) where T : class;
		IIndexResponse Index<T>(T @object, string index, string type, int id) where T : class;
		IIndexResponse Index<T>(T @object, string index, string type, int id, IndexParameters indexParameters) where T : class;
		IIndexResponse Index<T>(T @object, string index, string type, string id) where T : class;
		IIndexResponse Index<T>(T @object, string index, string type, string id, IndexParameters indexParameters) where T : class;

		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<BulkParameters<T>> objects) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<BulkParameters<T>> objects, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index, string type) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<BulkParameters<T>> objects, string index, string type, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<T> objects) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<T> objects, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<T> objects, string index) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<T> objects, string index, SimpleBulkParameters bulkParameters) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<T> objects, string index, string type) where T : class;
		Task<IBulkResponse> IndexManyAsync<T>(IEnumerable<T> objects, string index, string type, SimpleBulkParameters bulkParameters) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, IndexParameters indexParameters) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index, IndexParameters indexParameters) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index, string type) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index, string type, IndexParameters indexParameters) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index, string type, int id) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index, string type, int id, IndexParameters indexParameters) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index, string type, string id) where T : class;
		Task<IIndexResponse> IndexAsync<T>(T @object, string index, string type, string id, IndexParameters indexParameters) where T : class;
		IIndexExistsResponse IndexExists(string index);

		IIndicesResponse Map(RootObjectMapping typeMapping);
		IIndicesResponse Map(RootObjectMapping typeMapping, string index, string typeName, bool ignoreConflicts);
		IIndicesResponse MapRaw(string typeName, string map, string index, bool ignoreConflicts = false);
		IIndicesResponse MapFromAttributes<T>(int maxRecursion = 0) where T : class;
		IIndicesResponse MapFromAttributes<T>(string index, int maxRecursion = 0) where T : class;
		IIndicesResponse MapFromAttributes<T>(string index, string type, int maxRecursion = 0) where T : class;
		IIndicesResponse MapFromAttributes(Type t, int maxRecursion = 0);
		IIndicesResponse MapFromAttributes(Type t, string index, int maxRecursion = 0);
		IIndicesResponse MapFromAttributes(Type t, string index, string type, int maxRecursion = 0);

		IIndicesResponse MapFluent(Func<RootObjectMappingDescriptor<dynamic>, RootObjectMappingDescriptor<dynamic>> typeMappingDescriptor);
		IIndicesResponse MapFluent<T>(Func<RootObjectMappingDescriptor<T>, RootObjectMappingDescriptor<T>> typeMappingDescriptor)
			where T : class;

		IIndicesOperationResponse DeleteTemplate(string templateName);
		IIndicesOperationResponse PutTemplate(Func<TemplateMappingDescriptor, TemplateMappingDescriptor> templateMappingSelector);
		IIndicesOperationResponse PutTemplateRaw(string templateName, string template);
		ITemplateResponse GetTemplate(string templateName);

		IIndicesOperationResponse PutWarmer<T>(string warmerName, Func<SearchDescriptor<T>, SearchDescriptor<T>> selector)
			where T : class;
		IIndicesOperationResponse PutWarmer(string warmerName, Func<SearchDescriptor<dynamic>, SearchDescriptor<dynamic>> selector);

		INodeInfoResponse NodeInfo(NodesInfo nodesInfo);
		INodeInfoResponse NodeInfo(IEnumerable<string> nodes, NodesInfo nodesInfo);

		INodeStatsResponse NodeStats(NodeInfoStats nodeInfoStats);
		INodeStatsResponse NodeStats(IEnumerable<string> nodes, NodeInfoStats nodeInfoStats);

		IIndicesOperationResponse OpenIndex(string index);
		IIndicesOperationResponse OpenIndex<T>() where T : class;
		IIndicesOperationResponse Optimize();
		IIndicesOperationResponse Optimize(OptimizeParams optimizeParameters);
		IIndicesOperationResponse Optimize(IEnumerable<string> indices);
		IIndicesOperationResponse Optimize(IEnumerable<string> indices, OptimizeParams optimizeParameters);
		IIndicesOperationResponse Optimize(string index);
		IIndicesOperationResponse Optimize(string index, OptimizeParams optimizeParameters);
		IIndicesOperationResponse Optimize<T>() where T : class;
		IIndicesOperationResponse Optimize<T>(OptimizeParams optimizeParameters) where T : class;
		IPercolateResponse Percolate<T>(string index, string type, T @object) where T : class;
		IPercolateResponse Percolate<T>(string index, T @object) where T : class;
		IPercolateResponse Percolate<T>(T @object) where T : class;
		IIndicesShardResponse Refresh();
		IIndicesShardResponse Refresh(IEnumerable<string> indices);
		IIndicesShardResponse Refresh(string index);
		IIndicesShardResponse Refresh<T>() where T : class;
		IRegisterPercolateResponse RegisterPercolatorRaw(string index, string name, string query);
		IRegisterPercolateResponse RegisterPercolator(string name, Action<QueryPathDescriptor<dynamic>> querySelector);
		IRegisterPercolateResponse RegisterPercolator<T>(string name, Action<QueryPathDescriptor<T>> querySelector) where T : class;
		IIndicesOperationResponse RemoveAlias(AliasParams aliasParams);
		IIndicesOperationResponse RemoveAlias(IEnumerable<string> aliases);
		IIndicesOperationResponse RemoveAlias(string alias);
		IIndicesOperationResponse RemoveAlias(string index, IEnumerable<string> aliases);
		IIndicesOperationResponse RemoveAlias(string index, string alias);
		IIndicesOperationResponse RemoveAliases(IEnumerable<AliasParams> aliases);
		IIndicesOperationResponse Rename(string index, string oldAlias, string newAlias);

		IQueryResponse<dynamic> Search(Func<SearchDescriptor<dynamic>, SearchDescriptor<dynamic>> searcher);
		IQueryResponse<T> Search<T>(SearchDescriptor<T> descriptor) where T : class;
		IQueryResponse<T> Search<T>(Func<SearchDescriptor<T>, SearchDescriptor<T>> searcher) where T : class;
		IQueryResponse<T> SearchRaw<T>(string query, string path = null) where T : class;

		Task<IQueryResponse<dynamic>> SearchAsync(Func<SearchDescriptor<dynamic>, SearchDescriptor<dynamic>> searcher);
		Task<IQueryResponse<T>> SearchAsync<T>(SearchDescriptor<T> descriptor) where T : class;
		Task<IQueryResponse<T>> SearchAsync<T>(Func<SearchDescriptor<T>, SearchDescriptor<T>> searcher) where T : class;
		Task<IQueryResponse<T>> SearchRawAsync<T>(string query, string path = null) where T : class;

		ISegmentsResponse Segments();
		ISegmentsResponse Segments(IEnumerable<string> indices);
		ISegmentsResponse Segments(string index);

		/// <summary>
		/// serialize an object using the internal registered converters without camelcasing properties as is done 
		/// while indexing objects
		/// </summary>
		string Serialize(object @object);

		/// <summary>
		/// Serialize an object using the default camelCasing used while indexing objects
		/// </summary>
		string SerializeCamelCase(object @object);
		IIndicesShardResponse Snapshot();
		IIndicesShardResponse Snapshot(IEnumerable<string> indices);
		IIndicesShardResponse Snapshot(string index);
		IIndicesShardResponse Snapshot<T>() where T : class;
		IGlobalStatsResponse Stats();
		IGlobalStatsResponse Stats(StatsParams parameters);
		IStatsResponse Stats(IEnumerable<string> indices);
		IStatsResponse Stats(IEnumerable<string> indices, StatsParams parameters);
		IStatsResponse Stats(string index);
		IIndicesOperationResponse Swap(string alias, IEnumerable<string> oldIndices, IEnumerable<string> newIndices);
		bool TryConnect(out ConnectionStatus status);
		IUnregisterPercolateResponse UnregisterPercolator(string index, string name);
		IUnregisterPercolateResponse UnregisterPercolator<T>(string name) where T : class;
		IUpdateResponse Update(Action<UpdateDescriptor<dynamic>> updateSelector);
		IUpdateResponse Update<T>(Action<UpdateDescriptor<T>> updateSelector) where T : class;
		ISettingsOperationResponse UpdateSettings(IndexSettings settings);
		ISettingsOperationResponse UpdateSettings(string index, IndexSettings settings);
		IElasticSearchVersionInfo VersionInfo { get; }

		IValidateResponse ValidateRaw(string query);

		IValidateResponse Validate(Action<ValidateQueryPathDescriptor> querySelector);

		IValidateResponse Validate<T>(Action<ValidateQueryPathDescriptor<T>> querySelector) where T : class;

	}
}
