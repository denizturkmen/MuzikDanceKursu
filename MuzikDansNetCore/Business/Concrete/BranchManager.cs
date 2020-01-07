using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.DataAccessLayer.Abstract;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.Business.Concrete
{
    public class BranchManager:IBranchService
    {
        private IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal; 
        }

        public List<Branch> GetAll()
        {
            return _branchDal.GetAll();
        }

        public Branch GetById(int id)
        {
            return _branchDal.GetById(id);
        }

        public void Create(Branch entity)
        {
           _branchDal.Create(entity);
        }

        public void Delete(Branch entity)
        {
            _branchDal.Delete(entity);
        }

        public void Update(Branch entity)
        {
            _branchDal.Update(entity);
        }
    }
}
