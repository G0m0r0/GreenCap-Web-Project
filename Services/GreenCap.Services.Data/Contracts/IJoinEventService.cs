namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IJoinEventService
    {
        Task JoinEventAsync(int eventId, string userId);

        double GetNeededPeople(int eventId);
    }
}
