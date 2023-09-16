using Microsoft.AspNetCore.Mvc;

namespace DiaryOfTrader.WebApi.Core.Api
{
  public class Api<TEntity, TRepository> : IApi 
    where TEntity : Entity
    where TRepository : IRepository<TEntity>
  {
    #region

    private readonly string _endPoint;
    private readonly string _swagger;
    #endregion
    public Api()
    {
      var s = typeof(TEntity).Name.ToLowerInvariant();
      _endPoint = $"/{s}s";
      _swagger = s.Substring(0,1).ToUpperInvariant() + s.Substring(1);
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

      //application.MapPost($"{_endPoint}/range", PostRange)
      //  .Accepts<TEntity>("application/json")
      //  .Produces(StatusCodes.Status201Created)
      //  .WithName($"Create{_swagger}")
      //  .WithTags("Creators");

      application.MapPut($"{_endPoint}", Put)
        .Accepts<TEntity>("application/json")
        .Produces(StatusCodes.Status204NoContent)
        .WithName($"Update{_swagger}")
        .WithTags("Updaters");

      //application.MapPut($"{_endPoint}/range", PutRange)
      //  .Accepts<TEntity>("application/json")
      //  .Produces(StatusCodes.Status204NoContent)
      //  .WithName($"Update{_swagger}")
      //  .WithTags("Updaters");

      application.MapDelete($"{_endPoint}" + "/{id}", Delete)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent)
        .WithName($"Delete{_swagger}")
        .WithTags("Deleters");

      //application.MapDelete($"{_endPoint}_range", DeleteRange)
      //  .Produces(StatusCodes.Status404NotFound)
      //  .Produces(StatusCodes.Status204NoContent)
      //  .WithName($"Delete{_swagger}")
      //  .WithTags("Deleters");
    }

    //[Authorize]
    private async Task<IResult> GetAll(TRepository repository) =>
      Results.Ok(await repository.GetAllAsync());

    //[Authorize]
    private async Task<IResult> Search(string pattern, [FromServices] TRepository repository) =>
      await repository.GetAllAsync(new object[] { pattern }) is IEnumerable<TEntity> entities
        ? Results.Ok(entities)
        : Results.NotFound(Array.Empty<TEntity>());

    //[Authorize]
    private async Task<IResult> GetById(int id, [FromServices] TRepository repository) =>
      await repository.GetByIdAsync(id) is TEntity entity
        ? Results.Ok(entity)
        : Results.NotFound(Array.Empty<TEntity>());

    //[Authorize]
    private async Task<IResult> Post([FromBody] TEntity entity, TRepository repository)
    {
      await repository.InsertAsync(entity);
      return Results.Created($"/{entity.ID}", entity);
    }

    //[Authorize]
    private async Task<IResult> PostRange([FromBody] TEntity[] entities, TRepository repository)
    {
      await repository.InsertRangeAsync(entities);
      return Results.Created($"/{entities.Select(e=>e.ID)}", entities);
    }

    //[Authorize]
    private async Task<IResult> Put([FromBody] TEntity entity, TRepository repository)
    {
      await repository.UpdateAsync(entity);
      return Results.NoContent();
    }
    //[Authorize]
    private async Task<IResult> PutRange([FromBody] TEntity[] entities, TRepository repository)
    {
      await repository.UpdateRangeAsync(entities);
      return Results.NoContent();
    }

    //[Authorize]
    private async Task<IResult> Delete(int id, TRepository repository)
    {
      await repository.DeleteAsync(id);
      return Results.NoContent();
    }
    //[Authorize]
    private async Task<IResult> DeleteRange(long[] ids, TRepository repository)
    {
      await repository.DeleteRangeAsync(ids);
      return Results.NoContent();
    }
  }
}

