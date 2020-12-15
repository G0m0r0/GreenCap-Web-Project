namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Common;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Mapping;
    using GreenCap.Web.ViewModels.InputViewModels;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<Event> eventsDb;
        private readonly IDeletableEntityRepository<ApplicationUser> userDb;
        private readonly IDeletableEntityRepository<UserEventHosts> userHosts;

        public EventService(IDeletableEntityRepository<Event> eventsDb, IDeletableEntityRepository<ApplicationUser> userDb,IDeletableEntityRepository<UserEventHosts> userHosts)
        {
            this.eventsDb = eventsDb;
            this.userDb = userDb;
            this.userHosts = userHosts;
        }

        public async Task CreateAsync(EventInputViewModel model, string userId)
        {
            var listOfInputHosts = model.CreatorsNames.Split(new char[] { ',', ' ', '/', '\\', '-' }, StringSplitOptions.RemoveEmptyEntries);

            var creator = this.userDb.All().FirstOrDefault(x => x.Id == userId);

            if (creator == null)
            {
                throw new NullReferenceException(ExceptionMessages.UserDoesNotExist);
            }

            var eventModel = new Event
            {
                Description = model.Description,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                ImagePath = model.ImagePath,
                Name = model.Name,
                TotalPeople = model.TotalPeople,
            };
            await this.eventsDb.AddAsync(eventModel);
            await this.eventsDb.SaveChangesAsync();

            var userCreator = new UserEventHosts
            {
                UserId = creator.Id,
                EventId = eventModel.Id,
            };
            await this.userHosts.AddAsync(userCreator);
            await this.userHosts.SaveChangesAsync();

            foreach (var userName in listOfInputHosts)
            {
                var user = this.userDb
                    .All()
                    .FirstOrDefault(x => x.UserName == userName);

                if (user != null)
                {
                    var userHost = new UserEventHosts
                    {
                        EventId = eventModel.Id,
                        UserId = user.Id,
                    };

                    await this.userHosts.AddAsync(userHost);
                    await this.userHosts.SaveChangesAsync();
                }
            }
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
