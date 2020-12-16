namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Common;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Mapping;
    using GreenCap.Web.ViewModels.InputViewModels;
    using Microsoft.EntityFrameworkCore;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<Event> eventsDb;
        private readonly IDeletableEntityRepository<ApplicationUser> userDb;
        private readonly IDeletableEntityRepository<UserEventHosts> userHostsDb;
        private readonly IDeletableEntityRepository<UserEventSignedIn> userJoinDb;

        public EventService(
            IDeletableEntityRepository<Event> eventsDb,
            IDeletableEntityRepository<ApplicationUser> userDb,
            IDeletableEntityRepository<UserEventHosts> userHostsDb,
            IDeletableEntityRepository<UserEventSignedIn> userJoinDb)
        {
            this.eventsDb = eventsDb;
            this.userDb = userDb;
            this.userHostsDb = userHostsDb;
            this.userJoinDb = userJoinDb;
        }

        public async Task CreateAsync(EventInputViewModel model, string userId)
        {
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
            await this.userHostsDb.AddAsync(userCreator);
            await this.userHostsDb.SaveChangesAsync();

            if (model.CreatorsNames != null)
            {
                var listOfInputHosts = model.CreatorsNames.Split(new char[] { ',', ' ', '/', '\\', '-' }, StringSplitOptions.RemoveEmptyEntries);

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

                        await this.userHostsDb.AddAsync(userHost);
                        await this.userHostsDb.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task JoinEventAsync(int eventId, string userId)
        {
            var eventModel = this.eventsDb.All().FirstOrDefault(x => x.Id == eventId);
            var userModel = this.userDb.All().FirstOrDefault(x => x.Id == userId);

            if (eventModel == null)
            {
                throw new NullReferenceException(ExceptionMessages.EventNotFound);
            }

            if (userModel == null)
            {
                throw new NullReferenceException(ExceptionMessages.UserDoesNotExist);
            }

            var userEvent = await this.userJoinDb
                .AllWithDeleted()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.EventId == eventId);

            if (userEvent != null)
            {
                userEvent.IsDeleted = false;
                await this.userJoinDb.SaveChangesAsync();

                return;
            }

            var userEventJoin = new UserEventSignedIn
            {
                UserId = userModel.Id,
                EventId = eventModel.Id,
            };

            await this.userJoinDb.AddAsync(userEventJoin);
            await this.userJoinDb.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id, string userId)
        {
            var modelToDelete = await this.eventsDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete == null)
            {
                throw new NullReferenceException(ExceptionMessages.EventNotFound);
            }

            if (modelToDelete.UserEventsHosts.Any(x => x.UserId == userId))
            {
                throw new NullReferenceException(ExceptionMessages.YouHaveToBeCreatorException);
            }

            this.eventsDb.Delete(modelToDelete);
            await this.eventsDb.SaveChangesAsync();
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

        public async Task CancelEventAsync(int eventId, string userId)
        {
            var eventModel = this.eventsDb.All().FirstOrDefault(x => x.Id == eventId);
            var userModel = this.userDb.All().FirstOrDefault(x => x.Id == userId);

            if (eventModel == null)
            {
                throw new NullReferenceException(ExceptionMessages.EventNotFound);
            }

            if (userModel == null)
            {
                throw new NullReferenceException(ExceptionMessages.UserDoesNotExist);
            }

            var userEvent = await this.userJoinDb
                .AllWithDeleted()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.EventId == eventId);

            if (userEvent == null)
            {
                return;
            }

            if (userEvent.IsDeleted == false)
            {
                this.userJoinDb.Delete(userEvent);
                await this.userJoinDb.SaveChangesAsync();
            }
        }
    }
}
