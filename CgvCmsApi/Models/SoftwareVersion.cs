using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgvCmsApi.Models
{
    public class SoftWareVersion : ResponseBase
    {
        public VersionInfo Data { get; set; }

        public SoftWareVersion()
        {
            this.Data = new VersionInfo();
        }
    }
    public class VersionInfo
    {

        /// <summary>
        /// IDX
        /// </summary>
        public int IDX { get; set; }

        /// <summary>
        /// MTYPE
        /// </summary>
        public int MTYPE { get; set; }

        /// <summary>
        /// VERSION
        /// </summary>
        public string VERSION { get; set; }

        /// <summary>
        /// START_DATE
        /// </summary>
        public string START_DATE { get; set; }

        /// <summary>
        /// START_TIME
        /// </summary>
        public string START_TIME { get; set; }

        /// <summary>
        /// FILE_NAME
        /// </summary>
        public string FILE_NAME { get; set; }

        /// <summary>
        /// FILE_PATH
        /// </summary>
        public string FILE_PATH { get; set; }

        /// <summary>
        /// REFTIME
        /// </summary>
        public string REFTIME { get; set; }

        /// <summary>
        /// ROOT_PATH
        /// </summary>
        public string ROOT_PATH { get; set; }


    }
}
