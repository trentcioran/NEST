﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nest;

namespace Nest.Tests.Integration
{
	[TestFixture]
	public class ConnectionTests : IntegrationTests
	{
		[Test]
		public void TestSettings()
		{
			Assert.AreEqual(this._settings.Host, ElasticsearchConfiguration.Settings().Host);
			Assert.AreEqual(this._settings.Port, Test.Default.Port);
            Assert.AreEqual(new Uri(string.Format("http://{0}:{1}", ElasticsearchConfiguration.Settings().Host, Test.Default.Port)), this._settings.Uri);
			Assert.AreEqual(ElasticsearchConfiguration.DefaultIndex, ElasticsearchConfiguration.DefaultIndex);
			Assert.AreEqual(this._settings.MaximumAsyncConnections, Test.Default.MaximumAsyncConnections);
		}
        [Test]
        public void TestSettingsWithUri()
        {
            var uri = new Uri(string.Format("http://{0}:{1}", ElasticsearchConfiguration.Settings().Host, ElasticsearchConfiguration.Settings().Port));
            var settings = new ConnectionSettings(uri);
            Assert.AreEqual(settings.Host, ElasticsearchConfiguration.Settings().Host);
            Assert.AreEqual(settings.Port, Test.Default.Port);
            Assert.AreEqual(uri, this._settings.Uri);
        }
        [Test]
		public void TestConnectSuccess()
		{
			ConnectionStatus status;
			_client.TryConnect(out status);
			Assert.True(_client.IsValid);
			Assert.True(status.Success);
			Assert.Null(status.Error);
		}
		[Test]
		public void construct_client_with_null()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				var client = new ElasticClient(null);
			});
		}
		[Test]
		public void construct_client_with_null_or_empy_settings()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				string host = null;
				var settings = new ConnectionSettings(host, 80);
			});
			Assert.Throws<UriFormatException>(() =>
			{
				var settings = new ConnectionSettings(":asda:asdasd", 80);
			});
		}
		[Test]
		public void construct_client_with_invalid_hostname()
		{
			Assert.Throws<UriFormatException>(() =>
			{
				var settings = new ConnectionSettings("some mangled hostname", 80);
			});
			
		}
		[Test]
		public void connect_to_unknown_hostname()
		{
			Assert.DoesNotThrow(() =>
			{
				var settings = new ConnectionSettings("youdontownthis.domain.do.you", 80);
				var client = new ElasticClient(settings);
				ConnectionStatus connectionStatus;
				client.TryConnect(out connectionStatus);

				Assert.False(client.IsValid);
				Assert.True(connectionStatus != null);
				Assert.True(connectionStatus.Error.HttpStatusCode == System.Net.HttpStatusCode.BadGateway
					|| connectionStatus.Error.ExceptionMessage.StartsWith("The remote name could not be resolved"));
			});
		}
		[Test]
		public void TestConnectSuccessWithUri()
		{
			var settings = new ConnectionSettings(Test.Default.Uri);
			var client = new ElasticClient(settings);
			ConnectionStatus status;
			client.TryConnect(out status);
			Assert.True(client.IsValid);
			Assert.True(status.Success);
			Assert.Null(status.Error);
		}
		[Test]
		public void construct_client_with_null_uri()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				Uri uri = null;
				var settings = new ConnectionSettings(uri);
			});
		}
	}
}
