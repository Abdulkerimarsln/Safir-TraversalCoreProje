using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel account) 
        {
            var valueSender = _accountService.TGetByID(account.SenderID);
            var valueReceiver=_accountService.TGetByID(account.ReceiverID);

            valueSender.Balance-=account.Amount;
            valueReceiver.Balance+=account.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };
            _accountService.TMultiUpdate(modifiedAccounts);

            return View(); 
        }
    }
}
