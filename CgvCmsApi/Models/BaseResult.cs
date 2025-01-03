using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgvCmsApi.Models
{
	public class BaseResult
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public BaseResult()
		{
			this.Success = true;
			this.Message = "";
		}


		public void CopyResult(BaseResult ret)
		{
			this.Success = ret.Success;
			this.Message = ret.Message;
		}
	}
}
