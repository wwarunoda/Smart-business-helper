using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json.Linq;
using PizzaBox_Receipt_Management.Presentation;
using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace PizzaBox_Receipt_Management.BLL
{
    public class ReportHandler : IDisposable
    {
        ReportDocument reportDocument;
        JEnumerable<JObject> reportParamList;
        ReportViewer reportViewer;
        string projectPath;
        public ReportHandler() 
        {
            projectPath = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            this.reportViewer = new ReportViewer();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void ViewReport(string reportName, string parameterListJson, DataTable dt)
        {
            System.Drawing.Printing.PrintDocument localPrinter = new PrintDocument();
            ParameterFields paramFields = new ParameterFields();
            reportDocument = new ReportDocument();
            string reportPath = Path.Combine(projectPath, "Reports", reportName + ".rpt");
            reportDocument.Load(reportPath);
            
            reportParamList = this.ReadParameters(parameterListJson);
            foreach (JObject result in reportParamList)
            {
                ReportParameterVM parameter = result.ToObject<ReportParameterVM>();
                ParameterField item = new ParameterField();
                ParameterDiscreteValue itemValue = new ParameterDiscreteValue();
                item.ParameterFieldName = parameter.Name;
                itemValue.Value = parameter.Value;
                item.CurrentValues.Add(itemValue);
                paramFields.Add(item);
            }
            this.reportViewer.crystalReportViewer.ParameterFieldInfo = paramFields;
            reportDocument.SetDataSource(dt);
            this.reportViewer.crystalReportViewer.ReportSource = reportDocument;
            this.reportViewer.Show();
   
            reportDocument.PrintOptions.PrinterName = localPrinter.PrinterSettings.PrinterName.ToString();
            reportDocument.PrintToPrinter(1, false, 1, 1);
            System.Threading.Thread.Sleep(15000);
            reportDocument.PrintToPrinter(1, false, 1, 1);

            this.reportViewer.Hide();

            string pdfFilePath = ConfigurationManager.ConnectionStrings["pfdFilePath"].ConnectionString;
            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = pdfFilePath;
            CrExportOptions = reportDocument.ExportOptions;
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
            reportDocument.Export();
            this.sendmail(pdfFilePath);
        }
        private void sendmail(string pdfFile)
        {
            try
            {
                string myEmail = ConfigurationManager.ConnectionStrings["sendEmailAddress"].ConnectionString;
                string receivedEmail = ConfigurationManager.ConnectionStrings["receivedEmailAddress"].ConnectionString;
                string myEmailPassword = ConfigurationManager.ConnectionStrings["emailPassword"].ConnectionString;
                MailAddress mailfrom = new MailAddress(myEmail);
                MailAddress mailto = new MailAddress(receivedEmail);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                newmsg.Subject = "PizzaBox Receipt";
                newmsg.Body = "Pizza Box Receipt Detail";

                //For File Attachment, more file can also be attached
                Attachment att = new Attachment(@pdfFile);
                newmsg.Attachments.Add(att);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(myEmail, myEmailPassword);
                smtp.EnableSsl = true;
                smtp.Send(newmsg);
            }
            catch (Exception ex)
            {
            }
        }

        public void ViewFullReport(string reportName, DataTable dt)
        {
            System.Drawing.Printing.PrintDocument localPrinter = new PrintDocument();
            ParameterFields paramFields = new ParameterFields();
            reportDocument = new ReportDocument();
            string reportPath = Path.Combine(projectPath, "Reports", reportName + ".rpt");
            reportDocument.Load(reportPath);

            this.reportViewer.crystalReportViewer.ParameterFieldInfo = paramFields;
            reportDocument.SetDataSource(dt);
            this.reportViewer.crystalReportViewer.ReportSource = reportDocument;
            this.reportViewer.Show();

        }

        // recursively yield all children of json
        private IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }

        private JEnumerable<JObject> ReadParameters(string parameterJson)
        {
            var resultObjects = AllChildren(JObject.Parse(parameterJson))
                .First(c => c.Type == JTokenType.Array && c.Path.Contains("parameters"))
                .Children<JObject>();
            return resultObjects;
            
        }
    }
}
