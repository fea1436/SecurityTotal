﻿using System.Collections.Generic;

namespace _01_Framework.Application
{
    public interface IAuthHelper
    {
        void SignIn(AuthViewModel account);
        void SignOut();
        bool IsAuthenticated();
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
        long CurrentAccountId();
        string CurrentAccountMobile();
    }
}
