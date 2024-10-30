using EfCoreMistakes.Data;
using EfCoreMistakes.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace EfCoreMistakes.Endpoints;

public static class SubModelEndpoints
{
    public static void MapSubModelEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/SubModel").WithTags(nameof(SubModel));

        group.MapGet("/", async (EfCoreMistakesContext db) =>
        {
            return await db.SubModel.ToListAsync();
        })
        .WithName("GetAllSubModels")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SubModel>, NotFound>> (int id, EfCoreMistakesContext db) =>
        {
            return await db.SubModel.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is SubModel model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSubModelById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, SubModel subModel, EfCoreMistakesContext db) =>
        {
            var affected = await db.SubModel
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, subModel.Id)
                    .SetProperty(m => m.Information, subModel.Information)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSubModel")
        .WithOpenApi();

        group.MapPost("/", async (SubModel subModel, EfCoreMistakesContext db) =>
        {
            db.SubModel.Add(subModel);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/SubModel/{subModel.Id}", subModel);
        })
        .WithName("CreateSubModel")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EfCoreMistakesContext db) =>
        {
            var affected = await db.SubModel
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSubModel")
        .WithOpenApi();
    }
}
