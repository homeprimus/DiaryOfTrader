using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Core.Api
{
  public class Api<TEntity, TRepository> : IApi 
    where TEntity : Entity
    where TRepository : IRepository<TEntity>
  {
    #region
    private readonly string _endPoint;
    private readonly string _swagger;
    private ILogger<Api<TEntity, TRepository>> _logger;
    #endregion
    public Api(IOptions<EndPointConfiguration> config, ILogger<Api<TEntity, TRepository>> logger)
    {
      var s = typeof(TEntity).Name.ToLowerInvariant();
      _endPoint = config.Value.Version(s) + $"/{s}s";
      _swagger = s.Substring(0,1).ToUpperInvariant() + s.Substring(1).ToLowerInvariant();
      _logger = logger;
    }
    public virtual void Register(WebApplication application)
    {
      application.MapGet($"{_endPoint}", GetAll)
        .Produces<List<TEntity>>(StatusCodes.Status200OK)
        .WithName($"Get{_swagger}s")
        .WithTags("Getters");

      application.MapGet($"{_endPoint}" + "/search/{pattern}", Search)
        .Produces<List<TEntity>>(StatusCodes.Status200OK)
        .WithName($"Searsh{_swagger}")
        .WithTags("Getters")
        //.ExcludeFromDescription()
        ;

      application.MapGet($"{_endPoint}" + "/{id}", GetById)
        .Produces<TEntity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName($"Get{_swagger}")
        .WithTags("Getters");

      application.MapPost($"{_endPoint}", Post)
        .Accepts<TEntity>("application/json")
        .Produces(StatusCodes.Status201Created)
        .WithName($"Create{_swagger}")
        .WithTags("Creators");

      application.MapPut($"{_endPoint}", Put)
        .Accepts<TEntity>("application/json")
        .Produces(StatusCodes.Status204NoContent)
        .WithName($"Update{_swagger}")
        .WithTags("Updaters");

      application.MapDelete($"{_endPoint}", Delete)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent)
        .WithName($"Delete{_swagger}")
        .WithTags("Deleters");

    }

    //[Authorize]
    private async Task<IResult> GetAll(TRepository repository)
    {
      _logger.LogRequest(nameof(Api<TEntity, TRepository>), nameof(GetAll));
      return Results.Ok(await repository.GetAllAsync());
    }

    //[Authorize]
    private async Task<IResult> Search(string pattern, [FromServices] TRepository repository)
    {
      _logger.LogRequest(nameof(Api<TEntity, TRepository>), nameof(Search));
      return await repository.GetAllAsync(new object[] { pattern }) is IEnumerable<TEntity> entities
        ? Results.Ok(entities)
        : Results.NotFound(Array.Empty<TEntity>());
    }

    //[Authorize]
    private async Task<IResult> GetById(int id, [FromServices] TRepository repository)
    {
      _logger.LogRequest(nameof(Api<TEntity, TRepository>), nameof(GetById));
      return await repository.GetByIdAsync(id) is TEntity entity
        ? Results.Ok(entity)
        : Results.NotFound(Array.Empty<TEntity>());
    }

    //[Authorize]
    private async Task<IResult> Post([FromBody] List<TEntity> entities, TRepository repository)
    {
      _logger.LogRequest(nameof(Api<TEntity, TRepository>), nameof(Post));
      await repository.InsertAsync(entities);
      return Results.NoContent();
      //return Results.Created($"/{entity.ID}", entity);
    }


    //[Authorize]
    private async Task<IResult> Put([FromBody] List<TEntity> entities, TRepository repository)
    {
      _logger.LogRequest(nameof(Api<TEntity, TRepository>), nameof(Put));
      await repository.UpdateAsync(entities);
      return Results.NoContent();
    }

    //[Authorize]
    private async Task<IResult> Delete([FromBody] List<long> ids, TRepository repository)
    {
      _logger.LogRequest(nameof(Api<TEntity, TRepository>), nameof(Delete));
      await repository.DeleteAsync(ids);
      return Results.NoContent();
    }
  }
}

