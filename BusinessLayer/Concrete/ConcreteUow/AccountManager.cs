using BusinessLayer.Abstract.AbstractUow;
using DataAccesLayer.Abstract;
using DataAccesLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.ConcreteUow
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountdal;
        private readonly IUowDal _uowDal;
        public AccountManager(IAccountDal accountdal, IUowDal uowDal)
        {
            _accountdal = accountdal;
            _uowDal = uowDal;
        }

        public Account TGetByID(int id)
        {
            return _accountdal.GetByID(id);
        }

        public void TInsert(Account t)
        {
            _accountdal.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountdal.MultiUpdate(t);
            _uowDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountdal.Update(t);
            _uowDal.Save();
        }
    }
}
