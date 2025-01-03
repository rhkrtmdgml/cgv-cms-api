using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using CgvCmsApi.Models;
using log4net;
using System.Data.SqlClient;
using System.Configuration;

namespace CgvCmsApi.Controllers
{

    public class SoftwareInfoController : BaseController
    {

        protected readonly ILog log = LogManager.GetLogger(typeof(SoftwareInfoController));

        /// <summary>
        /// 플레이어 정보 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseObject<SoftwareInfo> GetSoftInfo(string id) {

            log.InfoFormat("id : {0} ", id);

            List<SqlParameter> para = new List<SqlParameter>();
            para.Add(new SqlParameter("@JobName", "GetVersion"));
            para.Add(new SqlParameter("@PlayerID", id));
            var model = this.db.ExecuteList<VersionInfo>("usp_SmartAgentApiManager", para)[0];

            try
            {
                if (id == "P02")
                {
                    return new ResponseObject<SoftwareInfo>
                    {
                        API = "Ge1t",
                        ERRORCODE = "0",
                        MESSAGE = "SUCCESS",
                        MESSAGECODE = "OK",
                        DATA = new SoftwareInfo
                        {

                            TER_CD = "TER_02",
                            THAT_CD = "THAT_02",
                            DOWN_FILE_URL = @"http://cj.smartagent.com/storage/Release1.zip",
                            ROOT_PATH = @"C:\Release1\Run\",
                            RUN_FILE_NAME = "CGVRunPlayer1.exe",
                            VERSION = 2,
                            DisplayName = "픽업02"
                        },
                    };
                }
                if (id == "P03")
                {
                    return new ResponseObject<SoftwareInfo>
                    {
                        API = "Get",
                        ERRORCODE = "0",
                        MESSAGE = "SUCCESS",
                        MESSAGECODE = "OK",
                        DATA = new SoftwareInfo
                        {
                            TER_CD = "TER_03",
                            THAT_CD = "THAT_03",
                            DOWN_FILE_URL = @"http://cj.smartagent.com/storage/Release2.zip",
                            ROOT_PATH = @"C:\Release2\Run\",
                            RUN_FILE_NAME = "CGVRunPlayer1.exe",
                            VERSION = 2,
                            DisplayName = "픽업03"
                        },
                    };
                }
                else
                {
                    return new ResponseObject<SoftwareInfo>
                    {
                        API = "Get",
                        ERRORCODE = "0",
                        MESSAGE = "SUCCESS",
                        MESSAGECODE = "OK",
                        DATA = new SoftwareInfo
                        {
                            TER_CD = "TER_01",
                            THAT_CD = "THAT_01",
                            DOWN_FILE_URL = @"http://cj.smartagent.com/storage/CGVRunPlayer.zip",
                            ROOT_PATH = @"C:\CGV_Agent_Test\Run\",
                            RUN_FILE_NAME = "CGVRunPlayer.exe",
                            VERSION = 2,
                            DisplayName = "픽업01"
                        },
                    };
                }

            }
            catch (Exception ex)
            {

                return new ResponseObject<SoftwareInfo>
                {
                    API = "Get",
                    ERRORCODE = "100",
                    MESSAGE = ex.Message,
                    MESSAGECODE = "Error",
                    DATA = null
                };
            }

        }


        /// <summary>
        /// 플레이어 정보 
        /// </summary>
        /// <param name="deviceid"></param>
        /// <returns></returns>
        public SoftWareVersion GetSoftWareVersion(string deviceid)
        {

            //DownloadServerUrl + @"storage/CGVRunPlayer.zip
            log.InfoFormat("[GetSoftWareVersion] deviceid : {0} ", deviceid);
            var funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                List<SqlParameter> para = new List<SqlParameter>();
                para.Add(new SqlParameter("@JobName", "GetVersion"));
                para.Add(new SqlParameter("@PlayerID", deviceid));
                var model = this.db.ExecuteList<VersionInfo>("usp_SmartAgentApiManager", para)[0];
                                

                if (model != null)
                {
                    log.InfoFormat("[GetSoftWareVersion] MTYPE : {0} / VERSION : {1} / FILE_PATH : {2} / REFTIME : {3} ", model.MTYPE, model.VERSION, model.FILE_PATH, model.REFTIME);

                    model.FILE_NAME = GetExeFileName(model.MTYPE);

                    return new SoftWareVersion
                    {
                        StatusMessage = "조회 되었습니다.",
                        Data = model
                    };
                }  
                else
                {
                    log.InfoFormat("[GetSoftWareVersion] model is null");

                    return new SoftWareVersion
                    {
                        StatusMessage = "조회된 데이터가 없습니다.",
                        Data = null
                    };
                }

            }
            catch (Exception ex)
            {
                log.InfoFormat("[GetSoftWareVersion] Exception : {0}", ex.Message);

                return new SoftWareVersion
                {
                    StatusCode = "500",
                    StatusMessage = ex.Message,
                    StatusName = "ERROR",
                    Data = null
                };
            }

        }

        /// <summary>
        /// 플레이어 상태값 업데이트
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public ResponseObject<string> Update([FromBody] DeviceStatus model)
        {

            var device = JsonConvert.DeserializeObject<DeviceStatus>(JsonConvert.SerializeObject( model));
            log.InfoFormat("{0}", JsonConvert.SerializeObject(model));

            var funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            log.InfoFormat("----------------------------------{0}----------------------------------", funcName);
            log.InfoFormat("{0}", device);
            log.InfoFormat("----------------------------------{0}----------------------------------", funcName);

            try
            {
                return new ResponseObject<string>
                {
                    API = funcName,
                    ERRORCODE = "0",
                    MESSAGE = "SUCCESS",
                    MESSAGECODE = "OK",
                    DATA = null
                };
            }
            catch (Exception ex)
            {

                return new ResponseObject<string>
                {
                    API = funcName,
                    ERRORCODE = "100",
                    MESSAGE = ex.Message,
                    MESSAGECODE = "Error",
                    DATA = null
                };
            }


        }

        /// <summary>
        /// 플레이어 상태값 업데이트
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public ResponseBase UpdateState(DeviceStatus model)
        {

            var device = JsonConvert.DeserializeObject<DeviceStatus>(JsonConvert.SerializeObject(model));
            log.InfoFormat("{0}", JsonConvert.SerializeObject(model));

            var funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            log.InfoFormat("----------------------------------{0}----------------------------------", funcName);
            log.InfoFormat("{0}", device);
            log.InfoFormat("----------------------------------{0}----------------------------------", funcName);

            try
            {

                //List<SqlParameter> para = new List<SqlParameter>();
                //para.Add(new SqlParameter("@JobName", "SaveControlLog"));
                //para.Add(new SqlParameter("@BKT_SALE_NO", device.TER_CD));
                //para.Add(new SqlParameter("@TAG_PL_INDEX", device.THAT_CD));
                //para.Add(new SqlParameter("@TAG_THAT_CODE", device.MEMORY));
                //para.Add(new SqlParameter("@TAG_SCN_CODE", device.CPU));
                //para.Add(new SqlParameter("@TAG_DATE", device.DISK));
                //para.Add(new SqlParameter("@CODE", device.SALEYN));
                //para.Add(new SqlParameter("@MESSAGE", device.VERSION));
                //this.db.ExecuteNonQuery("usp_TEST", para);

                return new ResponseBase();
            }
            catch (Exception ex)
            {

                return new ResponseBase
                {
                    StatusCode = "500",
                    StatusMessage = ex.Message,
                    StatusName = "Error"
                };
            }


        }


        private string GetExeFileName(int type)
        {
            string str_return = "";

            switch(type)
            {
                case 78: //스마트체크인
                    str_return = "SmartCheckinPlayer.exe";
                    break;

                case 79: //스마트체크인미니
                    str_return = "SmartCheckinMiniPlayer.exe";
                    break;

                case 80: //픽업호출모니터
                    str_return = "PickupLauncher.exe";
                    break;

                case 81: //픽업트레이
                    str_return = "CgvPickup.PickupPlace.exe";
                    break;

                case 82: //픽업트레이센서
                    str_return = "PickupTraySensorAgent.exe";
                    break;

                case 83: //픽업박스
                    str_return = "CJPos.NConnectivity.DogHouse.exe";
                    break;

                case 68: //디지털메뉴보드
                    str_return = "Cgv.MenuBoard.Agent.exe";

                    break;
                default:
                    break;
            }

            return str_return;


        }



    }

}
