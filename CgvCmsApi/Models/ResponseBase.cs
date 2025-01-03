using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgvCmsApi.Models
{
	public class ResponseBase
	{
		public string StatusCode { get; set; }
		public string StatusName { get; set; }
		public string StatusMessage { get; set; }

		public ResponseBase()
		{
			this.StatusCode = "200";
			this.StatusMessage = "Success";
			this.StatusName = "Success";
		}
	}
}
