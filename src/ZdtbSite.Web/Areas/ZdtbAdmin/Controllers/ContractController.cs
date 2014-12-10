using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class ContractController : BaseController
    {
        private readonly IRepository<Contract> ContractRepository;
        private IUnitOfWork unitOfWork;
        private string CurrentUrl { get { return Url.Action("Index", "Contract"); } }
        public ContractController(IRepository<Contract> ContractRepository, IUnitOfWork unitOfWork)
        {
            this.ContractRepository = ContractRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/Contract
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Contract> pageList = ContractRepository.GetPage(page, e => true, e => e.Id);
            return View(pageList);
        }

        public ActionResult SignContract(string ids)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                string[] idArr = ids.Split(',');
                for (int i = 0; i < idArr.Length; i++)
                {
                    var Contract = ContractRepository.GetById(idArr[i]);
                    Contract.Status = ContractStatus.Signed;
                    ContractRepository.Update(Contract);
                }
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "合同签约成功！";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "合同签约失败，请重试" + ex.Message;
            }
            return Json(model);
        }
    }
}