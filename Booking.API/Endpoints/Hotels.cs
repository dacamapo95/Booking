using Booking.API.Infrastructure;
using Booking.Application.Features.Hotels.Create;
using Booking.Application.Features.Hotels.CreateRoom;
using Booking.Application.Features.Hotels.GetById;
using Booking.Application.Features.Hotels.GetHotelRooms;
using Booking.Application.Features.Hotels.Update;
using Booking.Application.Features.Hotels.UpdateRoom;
using Booking.Domain.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Endpoints;

public class Hotels : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/hotels")
            .WithTags(nameof(Hotels))
            .WithOpenApi();
        
        group.MapPost("/", CreateHotel)
            .Produces<CreatedAtRoute>(StatusCodes.Status201Created)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest); ;

        group.MapGet("/{id:guid}", GetHotelById)
            .Produces<HotelResponse>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .WithName(nameof(GetHotelById));

        group.MapPost("/{id:guid}/rooms", AddRoom)
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest);
        
        group.MapPatch("/{id:guid}", UpdateHotel)
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest);
        
        group.MapPatch("/{id:guid}/rooms/{roomId:guid}", UpdateRoom)
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest);

        group.MapGet("/{id:guid}/rooms", GetRooms)
            .Produces<RoomResponse[]>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
    }

    private async Task<IResult> CreateHotel(ISender sender, [FromBody] CreateHotelRequest request)
    {
        var result = await sender.Send(new CreateHotelCommand(request));
        return result.Match(
            id => Results.CreatedAtRoute(nameof(GetHotelById), new { id = id }),
            ResultExtensions.ResultToResponse);
    }

    private async Task<IResult> GetHotelById(ISender sender, [FromRoute] Guid id)
    {
        var result = await sender.Send(new GetHotelByIdQuery(id));
        return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
    }

    private async Task<IResult> AddRoom(ISender sender, [FromRoute] Guid id, [FromBody] RoomRequest request)
    {
        var result = await sender.Send(new CreateRoomCommand(id, request));
        return result.Match(Results.NoContent, ResultExtensions.ResultToResponse);
    }

    private async Task<IResult> UpdateHotel(ISender sender, HttpContext context, [FromRoute] Guid id)
    {
        var patchDocument = await JsonPatch.GetJsonPatchDocumentAsync<UpdateHotelRequest>(context);
        var result = await sender.Send(new UpdateHotelCommand(id, patchDocument));
        return result.Match(Results.NoContent, ResultExtensions.ResultToResponse);
    }
    
    private async Task<IResult> UpdateRoom(ISender sender, HttpContext context, [FromRoute] Guid id, [FromRoute] Guid roomId)
    {
        var patchDocument = await JsonPatch.GetJsonPatchDocumentAsync<RoomRequest>(context);
        var result = await sender.Send(new UpdateRoomCommand(id, roomId, patchDocument));
        return result.Match(Results.NoContent, ResultExtensions.ResultToResponse);
    }

    public async Task<IResult> GetRooms(ISender sender, [FromRoute] Guid id)
    {
        var result = await sender.Send(new GetHotelRoomsQuery(id));
        return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
    }
}