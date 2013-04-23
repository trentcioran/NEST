﻿using NUnit.Framework;
using Nest.Tests.MockData.Domain;

namespace Nest.Tests.Unit.Search.SearchOptions
{
	[TestFixture]
	public class SearchOptionTests
	{
		[Test]
		public void TestFromSize()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10);
			var json = TestElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10 }";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestSkipTake()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.Skip(0)
				.Take(10);
			var json = TestElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10 }";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestBasics()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.Skip(0)
				.Take(10)
				.Explain()
				.Version()
				.MinScore(0.4);
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ 
				from: 0, size: 10,
				explain: true, 
				version: true,
				min_score: 0.4
			}";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestBasicsIndicesBoost()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.Skip(0)
				.Take(10)
				.Explain()
				.Version()
				.MinScore(0.4)
				.IndicesBoost(b => b.Add("index1", 1.4).Add("index2", 1.3));
			;
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ 
				from: 0, size: 10,
				explain: true, 
				version: true,
				min_score: 0.4,
				indices_boost : {
					index1 : 1.4,
					index2 : 1.3
				}

			}";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestPreference()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Preference("_primary");
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, preference: ""_primary"" }";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestExecuteOnPrimary()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.ExecuteOnPrimary();
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, preference: ""_primary"" }";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestExecuteOnLocalShard()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.ExecuteOnLocalShard();
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, preference: ""_local"" }";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestExecuteOnNode()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.ExecuteOnNode("somenode");
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				preference: ""_only_node:somenode"" }";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestFields()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Fields(e => e.Id, e => e.Name);
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				fields: [""id"", ""name""]
				}";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestFieldsByName()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Fields("id", "name");
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				fields: [""id"", ""name""]
				}";
			Assert.True(json.JsonEquals(expected));
		}

        [Test]
        public void TestPartialFields()
        {
            var s = new SearchDescriptor<ElasticSearchProject>()
                .PartialFields(x => x.PartialField("partial1").Include("id", "name").Exclude("number"));
            var json = TestElasticClient.Serialize(s);
            var expected = @"{
                partial_fields: { 
                    ""partial1"" : { 
                        ""include"" : [ ""id"", ""name"" ],
                        ""exclude"" : [ ""number"" ] 
                    } 
                } 
            }";
            Assert.True(json.JsonEquals(expected));
        }

        [Test]
        public void TestManyPartialFields()
        {
            var s = new SearchDescriptor<ElasticSearchProject>()
                .PartialFields(x => x.PartialField("partial1").Include("id"), x => x.PartialField("partial2").Exclude("id"));
            var json = TestElasticClient.Serialize(s);
            var expected = @"{
                partial_fields: { 
                    ""partial1"" : { 
                        ""include"" : [ ""id"" ]
                    },
                    ""partial2"" : {
                        ""exclude"" : [ ""id"" ] 
                    }
                } 
            }";
            Assert.True(json.JsonEquals(expected));
        }

		[Test]
		public void TestSort()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Fields(e => e.Id, e => e.Name)
				.SortAscending(e => e.LOC);
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
					sort: {
						""loc.sort"": ""asc""
					},
					fields: [""id"", ""name""]
				}";
			Assert.True(json.JsonEquals(expected), json);
		}
		[Test]
		public void TestSortDescending()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Fields(e => e.Id, e => e.Name)
				.SortAscending(e => e.LOC)
				.SortDescending(e => e.Name);
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
					sort: {
						""loc.sort"": ""asc"",
						""name.sort"": ""desc""
					},
					fields: [""id"", ""name""]
				}";
			Assert.True(json.JsonEquals(expected), json);
		}

		[Test]
		public void TestSuperSimpleQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q);
			var json = TestElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10, query : {}}";
			Assert.True(json.JsonEquals(expected));
		}
			
		
		
		[Test]
		public void TestRawQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.QueryRaw(@"{ raw : ""query""}");
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : { raw : ""query""}}";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestRawFilter()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.FilterRaw(@"{ raw : ""query""}");
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, filter : { raw : ""query""}}";
			Assert.True(json.JsonEquals(expected));
		}
		[Test]
		public void TestRawFilterAndQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.FilterRaw(@"{ raw : ""query""}")
				.QueryRaw(@"{ raw : ""query""}");
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : { raw : ""query""}, filter : { raw : ""query""}}";
			Assert.True(json.JsonEquals(expected));
		}
	}
}
