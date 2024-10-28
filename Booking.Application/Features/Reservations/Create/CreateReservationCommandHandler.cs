using Booking.Application.Core.Abstractions;
using Booking.Domain.Entities;
using Booking.Domain.Enums;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;

namespace Booking.Application.Features.Reservations.Create;

public class CreateReservationCommandHandler(
    IReservationRepository reservationRepository,
    IHotelRepository hotelRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateReservationCommand, Guid>
{
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly IHotelRepository _hotelRepository = hotelRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.FindByIdAsync(request.HotelId);

        if (hotel is null)
        {
            return HotelErrors.HotelNotFound(request.HotelId);
        }

        if (!hotel.IsEnabled)
        {
            return HotelErrors.HotelIsDisabled(request.HotelId);
        }

        var room = await _hotelRepository.GetRoomByIdAsync(request.HotelId, request.RoomId, cancellationToken);

        if (room == null)
        {
            return HotelErrors.RoomNotFound(request.HotelId, request.RoomId);
        }

        if (!room.IsEnabled)
        {
            return RoomErrors.RoomIsDisabled(request.RoomId);
        }

        if (await _reservationRepository.IsAnyReservationInRoomInProgress(
            request.RoomId,
            request.ReservationRequest.CheckInDate!.Value,
            request.ReservationRequest.CheckOutDate!.Value,
            cancellationToken))
        {
            return HotelErrors.ReservationInRoomInProgress(request.RoomId);
        }

        var totalCost = room.BaseCost + room.Taxes + (room.PricePerNight * request.ReservationRequest.NumberOfNights);

        Reservation reservation = Reservation.Create(
            request.ReservationRequest.ReservationDate,
            request.ReservationRequest.CheckInDate,
            request.ReservationRequest.CheckOutDate,
            totalCost,
            request.ReservationRequest.NumberOfGuests,
            request.ReservationRequest.SpecialRequests,
            (int)ReservationStatusEnum.Confirmed,
            EmergencyContact.Create(
                request.ReservationRequest.EmergencyContact.FullName,
                request.ReservationRequest.EmergencyContact.PhoneNumber));

        foreach (var guest in request.ReservationRequest.Guests)
        {
            var guestEntity = Guest.Create(
                guest.FirstName,
                guest.LastName,
                guest.Email,
                guest.PhoneNumber);

            reservation.Guests.Add(guestEntity);
        }

        reservation.RoomReservations.Add(
            new RoomReservation
            {
                Reservation = reservation,
                Room = room
            });

        _reservationRepository.Add(reservation);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return reservation.Id;
    }
}
