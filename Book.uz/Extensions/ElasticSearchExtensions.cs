using Book.uz.Entities;
using Book.uz.Models;
using Nest;

namespace Book.uz.Extensions;

public static class ElasticSearchExtensions
{
    public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
    {
        var url = configuration["ELKConfiguration:Url"];
        var defaultIndex = configuration["ELKConfiguration:index"];
        var settings = new ConnectionSettings(new Uri(url!))
            .PrettyJson().DefaultIndex(defaultIndex);
        AddDefaultMapping(settings: settings);
        
        var client = new ElasticClient(settings);
        services.AddSingleton<IElasticClient>(client);
        CreateIndex(client,defaultIndex!);
    }
    /// <summary>
    /// Below dagi code bizga map qilishda fieldlarini include qilish yoki
    /// qilmasilk uchun yordam beradi
    /// </summary>
    /// <param name="settings"></param>

    private static void AddDefaultMapping(ConnectionSettings settings)
    {
        /*settings.DefaultMappingFor<Product>(
            p => p
                .Ignore(p => p.Id));*/
    }

    private static void CreateIndex(IElasticClient client, string indexName)
    {
        client.Indices.Create(indexName.ToLower()
            , i => 
                i.Map<BookModel>(x => x.AutoMap()));
        client.Indices.Create(indexName.ToLower()
            , i => i.
                Map<AuthorModel>(x => x.AutoMap()));  
        client.Indices.Create(indexName.ToLower()
            , i => i.
                Map<ReviewModel>(x => x.AutoMap()));    
        client.Indices.Create(indexName.ToLower()
            , i => i.
                Map<CategoryModel>(x => x.AutoMap()));    
        client.Indices.Create(indexName.ToLower()
            , i => i.
                Map<OrderModel>(x => x.AutoMap()));    
    }
}   