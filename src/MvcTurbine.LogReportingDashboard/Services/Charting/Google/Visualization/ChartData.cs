using System.Collections;

namespace MvcTurbine.LogReportingDashboard.Services.Charting.Google.Visualization
{
    public class ChartData
    {
        private readonly ArrayList _cols = new ArrayList();
        private readonly ArrayList _rows = new ArrayList();

        /// <summary>
        ///   An array of columns
        /// </summary>
        public ChartColumn[] cols
        {
            get
            {
                var myCols = (ChartColumn[]) _cols.ToArray(typeof (ChartColumn));
                return myCols;
            }
        }

        /// <summary>
        ///   An array of rows
        /// </summary>
        public ChartRow[] rows
        {
            get
            {
                var myRows = (ChartRow[]) _rows.ToArray(typeof (ChartRow));
                return myRows;
            }
        }

        public void AddColumn(ChartColumn column)
        {
            _cols.Add(column);
        }

        public void AddRow(ChartRow row)
        {
            _rows.Add(row);
        }
    }
}