namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Mapping;
    using GreenCap.Web.ViewModels.InputViewModels;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<Event> eventsDb;

        public EventService(IDeletableEntityRepository<Event> eventsDb)
        {
            this.eventsDb = eventsDb;
        }

        public async Task CreateAsync(EventInputViewModel model, string userId)
        {
            var eventModel = new Event
            {
                Description = model.Description,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                HostId = userId,
                ImagePath = model.ImagePath,
                Name = model.Name,
                TotalPeople = model.TotalPeople,
            };

            await this.eventsDb.AddAsync(eventModel);
            await this.eventsDb.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            return this.eventsDb
                .AllAsNoTracking()
                .OrderBy(x => x.StartDate)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
           return this.eventsDb.AllAsNoTracking().Count();
        }
    }
}
