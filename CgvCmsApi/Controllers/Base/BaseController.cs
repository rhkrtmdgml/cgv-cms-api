using log4net;
using CgvCmsApi.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CgvCmsApi.Controllers
{
    public class BaseController : ApiController
    {
		#region member ---------------------------------------------------------------------------------------------------------------------------------------------


		#endregion

		#region property -------------------------------------------------------------------------------------------------------------------------------------------
		protected SqlHelper db { get; set; }
		protected string deviceID { get; set; }

		public string DownloadServerUrl
		{
			get
			{
				return ConfigurationManager.AppSettings["DownloadServerUrl"];
			}
		}
		public string CommonRoot
		{
			get
			{
				return ConfigurationManager.AppSettings["CommonRoot"];
			}
		}
		#endregion

		#region creator -------------------------------------------------------------------------------------------------------------------------------------------
		public BaseController()
		{
			this.InitControls();
		}
		#endregion

		#region public method -------------------------------------------------------------------------------------------------------------------------------------
		protected string CombineUriToString(string baseUri, params string[] para)
		{
			Uri uri = new Uri(baseUri);
			int cnt = 0;
			foreach (string s in para)
			{
				if (!s.EndsWith("/") && cnt < para.Count() - 1)
					uri = new Uri(uri, s + "/");
				else
					uri = new Uri(uri, s);
				cnt++;
			}
			return uri.ToString();
		}

		protected string GetDeviceID(HttpRequestMessage req)
		{
			string ret = string.Empty;
			IEnumerable<string> id = req.Headers.GetValues("X-DEVICE-ID");
			if (id != null)
				ret = id.ToList()[0];
			return ret;
		}
		#endregion

		#region override method -----------------------------------------------------------------------------------------------------------------------------------
		#endregion

		#region event handler -------------------------------------------------------------------------------------------------------------------------------------

		#endregion

		#region private method ------------------------------------------------------------------------------------------------------------------------------------
		private void InitControls()
		{
			this.db = SqlHelper.Instance;
		}


		#endregion
	}
}