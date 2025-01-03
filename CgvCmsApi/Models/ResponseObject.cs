using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgvCmsApi.Models
{
    public class ResponseObject<T>
    {
        /// <summary>
        /// 실행된 API
        /// </summary>
        public string API { get; set; }

        /// <summary>
        /// ERRORCODE
        /// </summary>
        public string ERRORCODE { get; set; }

        /// <summary>
        /// ERRORMESSAGE
        /// </summary>
        public string ERRORMESSAGE { get; set; }

        /// <summary>
        /// MESSAGECODE
        /// </summary>
        public string MESSAGECODE { get; set; }

        /// <summary>
        /// MESSAGE
        /// </summary>
        public string MESSAGE { get; set; }

        /// <summary>
        /// DATA
        /// </summary>
        public T DATA { get; set; }
    }
  
}
