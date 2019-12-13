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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(@"B:\Desarrollo\C#\GIT\INVAZD\Inventario_Avanzado\CrystalReport1.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();


            // ----------Parametro Detalles----------
            crParameterDiscreteValue.Value = textBox1.Text;
            crParameterFieldDefinitions = crystalrpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["detalles"];
            crParameterValues.Add(crParameterDiscreteValue);
            //crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            // ----------Parametro cantidad----------
            crParameterDiscreteValue.Value = textBox2.Text;
            crParameterFieldDefinitions = crystalrpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["cantidad"];
            crParameterValues.Add(crParameterDiscreteValue);
            //crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues.Clear();

            crystalReportViewer2.ReportSource = crystalrpt;
            crystalReportViewer2.Refresh();
        }
    }
}
