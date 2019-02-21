using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using SAPWebService.Models;
namespace SEFApplicationDashboard.app
{
    public class SOAP
    {
        StringBuilder sbuilder = new StringBuilder();

      

        //Using SOAP 1.1
        public string GetClientRequest(WIP wip)
        {

            var sr = "<?xml version='1.0' encoding='utf-8'?>" +
            "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:glob='http://sap.com/xi/SAPGlobal20/Global'>" +
            "<soapenv:Header/>" +
            "<soapenv:Body>" +
            "<glob:WIPCreateRequest>" +
            "<WIPRun>" +
            "<RunDescription>" + wip.RunDescription + "</RunDescription>" +
            "<AccountingPeriodID>" + wip.AccountingPeriodID + "</AccountingPeriodID>" +
            "<FiscalYearID>" + wip.FiscalYearID + "</FiscalYearID>" +
            "<AccountingClosingStepCode>" + wip.AccountingClosingStepCode + "</AccountingClosingStepCode>" +
            "<CompanyID>" + wip.CompanyID + "</CompanyID>" +
            "<TestRunIndicator>" + wip.TestRunIndicator + "</TestRunIndicator>" +
            "</WIPRun>" +
            "</glob:WIPCreateRequest>" +
            "</soapenv:Body>" +
            "</soapenv:Envelope>";

            return sr;
        }

    }
}