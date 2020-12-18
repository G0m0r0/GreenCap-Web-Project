namespace GreenCap.Services
{
    using System.Threading.Tasks;

    public interface IPhysNewsScarperService
    {
        Task ImportNewsAsync(int countPages);
    }
}
