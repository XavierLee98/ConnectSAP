using ConnectSAP1.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConnectSAP1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConnectSAP : ControllerBase
    {
        [HttpPost]
        public IActionResult Connecting(SAPCompany sap)
        {
            try
            {
                SAPbobsCOM.Company company = new SAPbobsCOM.Company();

                company.Server = sap.SAPSERVER;
                company.CompanyDB = sap.SAPDB;
                company.DbUserName = sap.SQLUSER;
                company.DbPassword = sap.SQLPASSWORD;
                if (!string.IsNullOrEmpty(sap.SAPUSER)) company.UserName = sap.SAPUSER; ;
                if (!string.IsNullOrEmpty(sap.SAPPASSWORD)) company.Password = sap.SAPPASSWORD;

                if (!string.IsNullOrEmpty(sap.SLDSERVER)) company.SLDServer = sap.SLDSERVER;
                if (!string.IsNullOrEmpty(sap.SAPLiSCENSE)) company.LicenseServer = sap.SAPLiSCENSE;

                company.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019;

                int connectionResult = company.Connect();

                if (connectionResult != 0)
                {
                    throw new Exception($"Error Code: {company.GetLastErrorCode()}, Description: {company.GetLastErrorDescription()}");
                }

                return Ok("Connected");
            }
            catch (Exception excep)
            {
                return BadRequest(excep.Message);
            }

        }
    }
}
