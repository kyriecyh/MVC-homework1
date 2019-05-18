using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
	
namespace homework1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
    {
        public 客戶聯絡人 Find(int id)
        {
            return this.All().Where(s => s.Id == id && !s.IsDelete.Value).FirstOrDefault();
        }
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(s => !s.IsDelete.Value);
        }

        public IQueryable<客戶聯絡人> Search(string keyword, string position, string sortStr)
        {
            var result = All();

            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(s => s.姓名.Contains(keyword)
                                       || s.Email.Contains(keyword)
                                       || s.手機.Contains(keyword)
                                       || s.電話.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(position))
            {
                result = result.Where(s => s.職稱.Contains(position));
            }

            if (!string.IsNullOrEmpty(sortStr))
            {
                switch (sortStr)
                {
                    case "職稱_desc":
                        result = result.OrderByDescending(s => s.職稱);
                        break;
                    case "職稱":
                        result = result.OrderBy(s => s.職稱);
                        break;
                    case "姓名_desc":
                        result = result.OrderByDescending(s => s.姓名);
                        break;
                    case "姓名":
                        result = result.OrderBy(s => s.姓名);
                        break;
                    case "Email_desc":
                        result = result.OrderByDescending(s => s.Email);
                        break;
                    case "Email":
                        result = result.OrderBy(s => s.Email);
                        break;
                    case "手機_desc":
                        result = result.OrderByDescending(s => s.手機);
                        break;
                    case "手機":
                        result = result.OrderBy(s => s.手機);
                        break;
                    case "電話_desc":
                        result = result.OrderByDescending(s => s.電話);
                        break;
                    case "電話":
                        result = result.OrderBy(s => s.電話);
                        break;
                    case "客戶名稱_desc":
                        result = result.OrderByDescending(s => s.客戶資料.客戶名稱);
                        break;
                    case "客戶名稱":
                        result = result.OrderBy(s => s.客戶資料.客戶名稱);
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
            if (data != null)
            {
                data.IsDelete = true;
                this.UnitOfWork.Context.Entry(data).State = EntityState.Modified;
                this.UnitOfWork.Commit();
            }
            return "success";
        }

    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}