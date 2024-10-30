using Microsoft.EntityFrameworkCore;
using EfCoreMistakes.Data;
using EfCoreMistakes.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EfCoreMistakes.Endpoints;

public static class SubSubSubModelEndpoints
{
    public static void MapSubSubSubModelEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/SubSubSubModel").WithTags(nameof(SubSubSubModel));

        group.MapGet("/", async (EfCoreMistakesContext db) =>
        {
            return await db.SubSubSubModel.ToListAsync();
        })
        .WithName("GetAllSubSubSubModels")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SubSubSubModel>, NotFound>> (int id, EfCoreMistakesContext db) =>
        {
            return await db.SubSubSubModel.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is SubSubSubModel model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSubSubSubModelById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, SubSubSubModel subSubSubModel, EfCoreMistakesContext db) =>
        {
            var affected = await db.SubSubSubModel
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, subSubSubModel.Id)
                    .SetProperty(m => m.SubSubSubInformation, subSubSubModel.SubSubSubInformation)
                    .SetProperty(m => m.SubSubModelId, subSubSubModel.SubSubModelId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSubSubSubModel")
        .WithOpenApi();

        group.MapPost("/", async (SubSubSubModel subSubSubModel, EfCoreMistakesContext db) =>
        {
            db.SubSubSubModel.Add(subSubSubModel);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/SubSubSubModel/{subSubSubModel.Id}", subSubSubModel);
        })
        .WithName("CreateSubSubSubModel")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EfCoreMistakesContext db) =>
        {
            var affected = await db.SubSubSubModel
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSubSubSubModel")
        .WithOpenApi();
    }
}
