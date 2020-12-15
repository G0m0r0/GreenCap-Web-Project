namespace GreenCap.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;

    public class JoinEventService : IJoinEventService
    {
        private readonly IRepository<UserEvent> userEventsDb;

        public JoinEventService(IRepository<UserEvent> userEventsDb)
        {
            this.userEventsDb = userEventsDb;
        }

        public double GetNeededPeople(int eventId)
        {
            throw new System.NotImplementedException();
        }

        public async Task JoinEventAsync(int eventId, string userId)
        {
            var model = this.userEventsDb.All().FirstOrDefault(x => x.UserId == userId);

            if (model == null)
            {
                var userEvents = new UserEvent
                {
                    UserId = userId,
                    EventId = eventId,
                };

                await this.userEventsDb.AddAsync(userEvents);
            }
        }
    }
}
