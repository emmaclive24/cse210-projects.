public class ReceptionEvent : Event
{
    private string _RSVP;
    
    public ReceptionEvent(string title, string description, string date, string time, Address address, string RSVP) : base(title, description, date, time, address, "Reception")
    {
        _RSVP = RSVP;
    }
    public override string FullDetails()
    {
        return StandardDetails() + $"\nRSVP Email: {_RSVP}\n";
    }
}