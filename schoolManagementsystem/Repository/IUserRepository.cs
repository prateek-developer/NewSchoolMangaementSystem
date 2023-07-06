using schoolManagementsystem.Models;
using schoolManagementsystem.ViewModel;
using System.Threading.Tasks;

namespace schoolManagementsystem.Repository
{
    public interface IUserRepository
    {

        Task<LoginDetail> Login(LoginDetailViewModel User);
        
    }
}
