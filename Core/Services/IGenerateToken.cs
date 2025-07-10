using System;
using Core.Entities;

namespace Core.Services;

public
 interface IGenerateToken
{
   Task<string> GetAndCreateToken(AppUser user);
}
