using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace VnptSoft.API2.Repositories {
  public class DbCollectionRepository<TModel>: IDbCollectionRepository<TModel, string> {
    private readonly ApplicationConfig _applicationConfig;
    private readonly DocumentClient _docClient;

    public DbCollectionRepository(IOptions<ApplicationConfig> appSetting) {
      _applicationConfig = appSetting.Value;
      _docClient = new DocumentClient(new Uri(_applicationConfig.CosmosDbConnectionString), _applicationConfig.AuthKey);
    }

    public async Task<IEnumerable<TModel>> GetItemsFromCollectionAsync(string collectionId) {
      var documents = _docClient.CreateDocumentQuery<TModel>(
                UriFactory.CreateDocumentCollectionUri(_applicationConfig.DatabaseId, collectionId),
                new FeedOptions { MaxItemCount = -1 })
                .AsDocumentQuery();
      var itemModels = new List<TModel>();
      while(documents.HasMoreResults) {
        itemModels.AddRange(await documents.ExecuteNextAsync<TModel>());
      }
      return itemModels;
    }

    public async Task<TModel> GetItemFromCollectionAsync(string collectionId, string id) {
      try {
        var doc = await _docClient.ReadDocumentAsync(UriFactory.CreateDocumentUri(_applicationConfig.DatabaseId, collectionId, id));
        return JsonConvert.DeserializeObject<TModel>(doc.ToString());
      } catch(DocumentClientException e) {
        if(e.StatusCode == System.Net.HttpStatusCode.NotFound) {
          return default(TModel);
        }
        throw;
      }
    }

    public async Task<TModel> AddDocumentIntoCollectionAsync(string collectionId, TModel item) {
      var document = await _docClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_applicationConfig.DatabaseId, collectionId), item);
      var res = document.Resource;
      var itemModel = JsonConvert.DeserializeObject<TModel>(res.ToString());
      return itemModel;

    }

    public async Task<TModel> UpdateDocumentFromCollection(string collectionId, string id, TModel item) {
      var document = await _docClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_applicationConfig.DatabaseId, collectionId, id), item);
      var data = document.Resource.ToString();
      var itemModel = JsonConvert.DeserializeObject<TModel>(data);
      return itemModel;
    }

    public async Task DeleteDocumentFromCollectionAsync(string collectionId, string id) {
      await _docClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_applicationConfig.DatabaseId, collectionId, id));
    }
  }
}
