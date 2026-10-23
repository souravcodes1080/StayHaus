using System.ComponentModel.DataAnnotations;

namespace Backend.Enums
{
    public enum BookingStatus
    {
        [Display(Name = "Pending Approval")]
        PendingApproval = 1,
        // The guest has submitted a booking request and money may be authorized, 
        // but the homestay host has not yet accepted or rejected the stay.

        [Display(Name = "Confirmed")]
        Confirmed = 2,
        // The host accepted the request (or it was an instant-book listing), 
        // payment is securely processed, and the dates are blocked off.

        [Display(Name = "Active / Checked In")]
        Active = 3,
        // The guest has arrived at the homestay, verified their check-in with the host, 
        // and is currently staying on the property.

        [Display(Name = "Completed")]
        Completed = 4,
        // The stay has ended successfully, the guest has checked out, and the transaction 
        // payouts can be safely released to the host's banking layer.

        [Display(Name = "Cancelled by Guest")]
        CancelledByGuest = 5,
        // The guest opted out of the reservation before check-in. The system will 
        // execute refund calculations based on the property's cancellation policy.

        [Display(Name = "Cancelled by Host")]
        CancelledByHost = 6,
        // The host had an emergency and rejected the booking. System should automatically trigger 
        // a 100% immediate refund to the guest and flag the host profile for metrics auditing.

        [Display(Name = "Declined / Expired")]
        Declined = 7
        // The host explicitly refused the initial request, or the 24-hour response window 
        // closed automatically before action was taken. Money is safely released back to the client.
    }
}