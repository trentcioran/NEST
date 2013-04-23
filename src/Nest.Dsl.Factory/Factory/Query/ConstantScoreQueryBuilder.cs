﻿using System;
using Newtonsoft.Json.Linq;

namespace Nest.Dsl.Factory
{
    /// <summary>
    /// A query that wraps a filter and simply returns a constant score equal to the
    /// query boost for every document in the filter.
    /// </summary>
    public class ConstantScoreQueryBuilder : IQueryBuilder
    {
        private const string NAME = NameRegistry.ConstantScoreQueryBuilder;
        private readonly IFilterBuilder _filterBuilder;
        private readonly IQueryBuilder _queryBuilder;
        private float? _boost;

        /// <summary>
        /// A query that wraps a filter and simply returns a constant score equal to the
        /// query boost for every document in the filter.
        /// </summary>
        /// <param name="filterBuilder">The filter to wrap in a constant score query</param>
        public ConstantScoreQueryBuilder(IFilterBuilder filterBuilder)
        {
            _filterBuilder = filterBuilder;
        }

        /// <summary>
        /// A query that wraps a query and simply returns a constant score equal to the
        /// query boost for every document in the query.
        /// </summary>
        /// <param name="filterBuilder">The filter to wrap in a constant score query</param>
        public ConstantScoreQueryBuilder(IQueryBuilder queryBuilder)
        {
          _queryBuilder = queryBuilder;
        }

        /// <summary>
        /// Sets the boost for this query.  Documents matching this query will (in addition to the normal
        /// weightings) have their score multiplied by the boost provided.
        /// </summary>
        /// <param name="boost"></param>
        /// <returns></returns>
        public ConstantScoreQueryBuilder Boost(float boost)
        {
            _boost = boost;
            return this;
        }

        #region IQueryBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty(NAME, new JObject()));

            if (_filterBuilder != null)
              content[NAME]["filter"] = _filterBuilder.ToJsonObject() as JObject;

            if (_queryBuilder != null)
              content[NAME]["query"] = _queryBuilder.ToJsonObject() as JObject;

            if(_boost != null)
            {
                content[NAME]["boost"] = _boost;
            }
            return content;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }

        #endregion
    }
}