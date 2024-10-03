using OnlineQuiz.BLL.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.Accounts
{
    public interface IAccountManager
    {
        Task<GeneralRespnose> Login(LoginDto loginDto);
        Task<GeneralRespnose> Register(RegisterDto registerDto);
    }
}
