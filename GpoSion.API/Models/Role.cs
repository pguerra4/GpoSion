using System.Collections.Generic;
using Korzh.EasyQuery;
using Microsoft.AspNetCore.Identity;

namespace GpoSion.API.Models
{
    [EqEntity(UseInResult = false, UseInConditions = false)]
    public class Role : IdentityRole
    {

    }
}