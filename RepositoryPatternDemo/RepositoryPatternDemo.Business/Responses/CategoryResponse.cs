namespace RepositoryPatternDemo.Business.Responses;

public sealed record CategoryResponse(int Id, string Name, List<ProductResponse> Products);
