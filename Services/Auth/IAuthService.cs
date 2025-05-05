using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiaFutures.Services.Auth
{
    internal interface IAuthService
    {
        Task<bool> Auth(Model.Auth auth);
    }
}
