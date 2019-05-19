using System;
using System.Linq;
using System.Collections.Generic;
	
namespace homework1.Models
{   
	public  class 客戶三聯資料ViewRepository : EFRepository<客戶三聯資料View>, I客戶三聯資料ViewRepository
	{

	}

	public  interface I客戶三聯資料ViewRepository : IRepository<客戶三聯資料View>
	{

	}
}