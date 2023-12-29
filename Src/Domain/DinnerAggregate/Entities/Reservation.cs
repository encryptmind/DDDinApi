// <copyright file="Reservation.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Bill.ValueObjects;
using Domain.Common.Models;
using Domain.Dinner.Enums;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;

namespace Domain.Dinner.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public List<GuestId> GuestIds { get; set; } = new ();
        public List<BillId> BillIds { get; set; } = new ();
        public DateTime ArrivalDateTime { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime UpdatedDatetime { get; set; }

        public Reservation(
            ReservationId reservationId,
            int guestCount,
            ReservationStatus reservationStatus,
            List<GuestId> guestIds,
            List<BillId> billIds,
            DateTime arrivalDateTime,
            DateTime createdDatetime,
            DateTime updatedDatetime)
            : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestIds = guestIds;
            BillIds = billIds;
            ArrivalDateTime = arrivalDateTime;
            CreatedDatetime = createdDatetime;
            UpdatedDatetime = updatedDatetime;
        }

        public static Reservation Create(
            int guestCount,
            ReservationStatus reservationStatus,
            List<GuestId> guestIds,
            List<BillId> billIds,
            DateTime arrivalDateTime,
            DateTime createdDatetime,
            DateTime updatedDatetime)
        {
            return new Reservation(
                ReservationId.CreateUnique(),
                guestCount,
                reservationStatus,
                guestIds,
                billIds,
                arrivalDateTime,
                createdDatetime,
                updatedDatetime);
        }
    }
}
