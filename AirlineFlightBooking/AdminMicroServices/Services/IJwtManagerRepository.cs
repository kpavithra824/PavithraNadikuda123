using AdminMicroServices.Models;
using AdminMicroServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMicroServices.Services
{
    public interface IJwtManagerRepository
    {
        Tokens Anthenticate(AdminLoginViewModel admin, bool IsRegister);
        List<TblAdminLogin> FindAll();
    }
}
