// <copyright file="Bill.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Bill.ValueObjects;
using Domain.Common.Models;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;

namespace Domain.Bill
{
    public class Bill : AggregateRoot<BillId, Guid>
    {
        public DinnerId DinnerId { get; set; }
        public GuestId GuestId { get; set; }
        public HostId HostId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public Bill(
            BillId billId,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(billId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(
            BillId billId,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new (
                billId,
                dinnerId,
                guestId,
                hostId,
                createdDateTime,
                updatedDateTime);
        }
    }
}
