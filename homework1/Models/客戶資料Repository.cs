using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
	
namespace homework1.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int id)
        {
            return this.All().Where(s => s.Id == id && !s.IsDelete.Value).FirstOrDefault();
        }
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(s => !s.IsDelete.Value);
        }

        public IQueryable<客戶資料> Search(string sortStr)
        {
            var result = All();

            if (!string.IsNullOrEmpty(sortStr))
            {
                switch (sortStr)
                {
                    case "客戶名稱_desc":
                        result = result.OrderByDescending(s => s.客戶名稱);
                        break;
                    case "客戶名稱":
                        result = result.OrderBy(s => s.客戶名稱);
                        break;
                    case "統一編號_desc":
                        result = result.OrderByDescending(s => s.統一編號);
                        break;
                    case "統一編號":
                        result = result.OrderBy(s => s.統一編號);
                        break;
                    case "電話_desc":
                        result = result.OrderByDescending(s => s.電話);
                        break;
                    case "電話":
                        result = result.OrderBy(s => s.電話);
                        break;
                    case "傳真_desc":
                        result = result.OrderByDescending(s => s.傳真);
                        break;
                    case "傳真":
                        result = result.OrderBy(s => s.傳真);
                        break;
                    case "地址_desc":
                        result = result.OrderByDescending(s => s.地址);
                        break;
                    case "地址":
                        result = result.OrderBy(s => s.地址);
                        break;
                    case "Email_desc":
                        result = result.OrderByDescending(s => s.Email);
                        break;
                    case "Email":
                        result = result.OrderBy(s => s.Email);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        public string Delete(int id)
        {
            var data = Find(id);
            if(data != null)
            {
                data.IsDelete = true;
                this.UnitOfWork.Context.Entry(data).State = EntityState.Modified;
                this.UnitOfWork.Commit();
            }
            return "success";
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}