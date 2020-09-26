using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json.Linq;
using PizzaBox_Receipt_Management.Presentation;
using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            this.reportViewer.Hide();

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
