using System.Threading.Tasks;
using SysManager.Application.Helpers;

namespace SysManager.Application.Services
{
    public class UserService
    {
        public UserService()
        {
            
        }

        public async Task<ResultData> PostAsync()
        {
            return new ResultData(true);
        }
    }
}