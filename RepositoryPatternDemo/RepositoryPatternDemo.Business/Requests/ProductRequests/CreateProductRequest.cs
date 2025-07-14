namespace RepositoryPatternDemo.Business.Requests.ProductRequests;

public sealed record CreateProductRequest(string Name, int Price, int CategoryId);
