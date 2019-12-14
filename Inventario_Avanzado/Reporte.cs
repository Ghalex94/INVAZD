using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#region NewUsing
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
#endregion
namespace Inventario_Avanzado
{
    public partial class Reporte : Form
    {
        public Reporte(string detalles ,string cantidad)
        {
            InitializeComponent();
            Parametros(detalles, cantidad);
        }

        private void Parametros(string parametro1,string parametro2)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(@"B:\Desarrollo\C#\GIT\INVAZD\Inventario_Avanzado\CrystalReport1.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();


            // ----------Parametro Detalles----------
            crParameterDiscreteValue.Value = parametro1;
            crParameterFieldDefinitions = crystalrpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["detalles"];
            crParameterValues.Add(crParameterDiscreteValue);
            //crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            // ----------Parametro cantidad----------
            crParameterDiscreteValue.Value = parametro2;
            crParameterFieldDefinitions = crystalrpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["cantidad"];
            crParameterValues.Add(crParameterDiscreteValue);
            //crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues.Clear();

            crystalReportViewer1.ReportSource = crystalrpt;
            crystalReportViewer1.Refresh();
        }
    }
}
