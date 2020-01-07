using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.Business.Abstract
{
    public interface IBranchService
    {
        List<Branch> GetAll();
        Branch GetById(int id);

        void Create(Branch entity);
        void Delete(Branch entity);
        void Update(Branch entity);
    }
}
