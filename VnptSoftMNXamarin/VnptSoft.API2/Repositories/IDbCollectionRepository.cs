using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoft.API2.Repositories {
  public interface IDbCollectionRepository<TModel, in TPk> {
    Task<IEnumerable<TModel>> GetItemsFromCollectionAsync(string collectionId);
    Task<TModel> GetItemFromCollectionAsync(string collectionId, TPk id);
    Task<TModel> AddDocumentIntoCollectionAsync(string collectionId, TModel item);
    Task<TModel> UpdateDocumentFromCollection(string collectionId, TPk id, TModel item);
    Task DeleteDocumentFromCollectionAsync(string collectionId, TPk id);
  }
}

