﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationclaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationclaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim {Id = operationclaim.Id, Name = operationclaim.Name};
                    return result.ToList();


            }
        }
    }
}
