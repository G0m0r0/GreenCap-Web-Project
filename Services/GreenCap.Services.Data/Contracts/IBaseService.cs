namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseService
    {
        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllPersonal<T>(int page, int itemsPerPage, string id);

        Task<T> GetByIdAsync<T>(int id);
    }
}
