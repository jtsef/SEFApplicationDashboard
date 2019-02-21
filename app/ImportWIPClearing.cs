using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPWebService;
using SAPWebService.Models;
using System.ServiceModel;
using SEFApplicationDashboard.app;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Net;
using System.Web.Mvc;


namespace SEFApplicationDashboard.app
{
    public class ImportWIPClearing
    {
        private static string ClosingStepCode = "010";     
        private static string[] pCompanies = { "AM", "OSO", "DW" };
        private static DateTime lastWIPDate = DateTime.Now;
       
        
        public static async Task<string>  RunWIPClearing(int useDuration, bool runAsTest)
        {
            int x = 0;
            bool success = false;

            try
            {
                do {
                    success = false;
                    foreach(string company in pCompanies)
                    {
                        if (IsSAPClearingDue(useDuration))
                        {
                            WIP wip = SetupHeader(company, false);

                           
                            SAPWebService.WIPService.AccountingWIPClearingRunClient client = SAPWebService.WebService.SetUpClient(ConnectionInfo.user, ConnectionInfo.password);
                            var response = await SAPWebService.WebService.CreateWIP(client, wip);
                            var result = response.WIPRunResponse.ToString();
                            return result;

                        }
                    }

                }
                while (x == 0);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return null;
        }

        /// <summary>
        /// IsSapClearingDue
        /// if the duration is greater then the time then true
        /// </summary>
        /// <returns>boolean</returns>
        private static Boolean IsSAPClearingDue(int UseDuration)
        {
            DateTime currentDate = DateTime.Now;
            int duration = currentDate.Subtract(lastWIPDate).Minutes;

            if (duration >= UseDuration)
            {
                return true;
            }
            else
                return false;
            
        }

        /// <summary>
        /// SetupHeader
        /// </summary>
        /// <param name="company"></param>
        /// <param name="runAsTest"></param>
        /// <returns>WIP object</returns>
        private static WIP SetupHeader(string company, bool runAsTest)
        {
            WIP wip = new WIP();

            wip.RunDescription = "WIPClearing " + company + "On: " + DateTime.Now.ToShortDateString();
            wip.AccountingPeriodID = PadNumber((DateTime.Now.AddMonths(1).Month), 3);
            wip.FiscalYearID = DateTime.Now.Year.ToString();
            wip.AccountingClosingStepCode = ClosingStepCode;
            wip.TestRunIndicator = runAsTest;
            wip.CompanyID = company;

            return wip;

        }

      

        /// <summary>
        /// PadNumber 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="size"></param>
        /// <returns>pads the number so in format 002, 011 etc</returns>
        private static string PadNumber(int month, int size)
        {
            var pMonth = month + "";
            while (pMonth.Length < size)
                pMonth = "0" + pMonth;

            return pMonth;

        }


        //private static async Task CreateWIP(WebService client, WIP wip)
        //{
        //    try
        //    {
                
        //        WIPCreateRequesr wipRequest = new WIPCreateRequesr();
        //        WIPRunDataType wipRun = new WIPRunDataType();

        //        wipRun.AccountingClosingStepCode = wip.AccountingClosingStepCode;
        //        wipRun.AccountingPeriodID = wip.AccountingPeriodID;
        //        wipRun.CompanyID = wip.CompanyID;
        //        wipRun.FiscalYearID = wip.FiscalYearID;
        //        wipRun.RunDescription = wip.RunDescription;
        //        wipRun.TestRunIndicator = wip.TestRunIndicator;

        //        // var response2 = client.CreateWip()
        //        var response = await client.CreateWipAsync(wipRequest);
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        int i = 0;
        //    }
        //}



        //private static async Task CreateWIP(AccountingWIPClearingRunClient client, WIP wip)
        //{
        //    try
        //    {
        //        WIPCreateRequesr wipRequest = new WIPCreateRequesr();
        //        WIPRunDataType wipRun = new WIPRunDataType();

        //        wipRun.AccountingClosingStepCode = wip.AccountingClosingStepCode;
        //        wipRun.AccountingPeriodID = wip.AccountingPeriodID;
        //        wipRun.CompanyID = wip.CompanyID;
        //        wipRun.FiscalYearID = wip.FiscalYearID;
        //        wipRun.RunDescription = wip.RunDescription;
        //        wipRun.TestRunIndicator = wip.TestRunIndicator;

        //        // var response2 = client.CreateWip()
        //        var response = await client.CreateWipAsync(wipRequest);
        //        return;
        //    }
        //    catch(Exception ex)
        //    {
        //        int i = 0;
        //    }
        //}

    }
}