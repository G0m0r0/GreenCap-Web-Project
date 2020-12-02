namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<Event> eventsDb;

        public EventService(IDeletableEntityRepository<Event> eventsDb)
        {
            this.eventsDb = eventsDb;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
