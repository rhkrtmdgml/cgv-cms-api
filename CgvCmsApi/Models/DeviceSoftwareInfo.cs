using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgvCmsApi.Models
{

    /// <summary>
    /// 단말 설치 소프트 웨어 정보
    /// </summary>
    public class DeviceSoftwareInfo
    {
        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 버젼
        /// </summary>
        public int VERSION { get; set; }

        /// <summary>
        /// 설치경로
        /// </summary>
        public string INSTALL_PATH { get; set; }

        /// <summary>
        /// 실행파일명
        /// </summary>
        public string RUN_FILE_NAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DOWN_FILE_URL { get; set; }

        /// <summary>
        /// 극장코드
        /// </summary>
        public string THAT_CD { get; set; }

        /// <summary>
        /// 단말기코드
        /// </summary>
        public string TER_CD { get; set; }
    }
}
