using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgvCmsApi.Models
{
    /// <summary>
    /// 디바이스 상태
    /// </summary>
    public class DeviceStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public string TER_CD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string THAT_CD { get; set; }
        /// <summary>
        /// DeviceID
        /// </summary>
        public string DeviceID { get; set; }
        /// <summary>
        /// CPU 사용량
        /// </summary>
        public string CPU { get; set; }
        /// <summary>
        /// MEMORY 사용량
        /// </summary>
        public string MEMORY { get; set; }
        /// <summary>
        /// 디스크 사용량
        /// </summary>
        public string DISK { get; set; }
        /// <summary>
        /// 실행 여부
        /// </summary>
        public string SALEYN { get; set; }
        /// <summary>
        /// 버전 정보
        /// </summary>
        public string VERSION { get; set; }

    }
}
