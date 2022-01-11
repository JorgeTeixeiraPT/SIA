using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA.Data
{
    public class SeedFuncoes
    {
        public static void seed(RoleManager<IdentityRole> roleManger){
            roleManger.CreateAsync(new IdentityRole("SuperAdmin")).Wait();
            roleManger.CreateAsync(new IdentityRole("Client")).Wait();

        }

    }
}
