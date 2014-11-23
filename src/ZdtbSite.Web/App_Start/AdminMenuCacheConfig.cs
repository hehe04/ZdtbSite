using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZdtbSite.Model;
using ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web
{
    public class AdminMenuCacheConfig
    {
        public AdminMenuCacheConfig()
        {

        }
        private readonly ZdtbSite.Core.Repository.AdminMenuRepository repository = null;
        public AdminMenuCacheConfig(ZdtbSite.Core.Repository.AdminMenuRepository repository)
        {
            this.repository = repository;
        }
        public void SetAdminMenuCache()
        {
            var list = this.repository.GetAll().ToList();
            var viewList = AutoMapper.Mapper.Map<List<AdminMenu>, List<AdminMenuViewModel>>(list);
            HttpContext.Current.Application.Add("MenuList", viewList);
        }
    }
}