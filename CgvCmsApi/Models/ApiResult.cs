using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgvCmsApi.Models
{
    public class ApiResult<T> : BaseResult
	{
		public T Data { get; set; }
		public ApiResult()
		{
			this.Success = true;
			this.Message = "";
		}
	}
}
