namespace RepositoryPatternDemo.Business.Requests.ProductRequests;

public sealed record UpdateProductRequest(int Id, string Name, int Price);
