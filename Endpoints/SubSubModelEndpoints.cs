using EfCoreMistakes.Data;
using EfCoreMistakes.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace EfCoreMistakes.Endpoints;

public static class SubSubModelEndpoints
{
    public static void MapSubSubModelEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/SubSubModel").WithTags(nameof(SubSubModel));

        group.MapGet("/", async (EfCoreMistakesContext db) =>
        {
            return await db.SubSubModel.ToListAsync();
        })
        .WithName("GetAllSubSubModels")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SubSubModel>, NotFound>> (int id, EfCoreMistakesContext db) =>
        {
            return await db.SubSubModel.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is SubSubModel model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSubSubModelById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, SubSubModel subSubModel, EfCoreMistakesContext db) =>
        {
            var affected = await db.SubSubModel
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, subSubModel.Id)
                    .SetProperty(m => m.SubSubInformation, subSubModel.SubSubInformation)
                    .SetProperty(m => m.SubModelId, subSubModel.SubModelId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSubSubModel")
        .WithOpenApi();

        group.MapPost("/", async (SubSubModel subSubModel, EfCoreMistakesContext db) =>
        {
            db.SubSubModel.Add(subSubModel);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/SubSubModel/{subSubModel.Id}", subSubModel);
        })
        .WithName("CreateSubSubModel")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EfCoreMistakesContext db) =>
        {
            var affected = await db.SubSubModel
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSubSubModel")
        .WithOpenApi();
    }
}
