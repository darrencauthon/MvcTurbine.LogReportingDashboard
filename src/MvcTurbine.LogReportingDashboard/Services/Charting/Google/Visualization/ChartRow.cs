using System.Collections;

namespace MvcTurbine.LogReportingDashboard.Services.Charting.Google.Visualization
{
    public class ChartRow
    {
        private ArrayList _cellItems = new ArrayList();

        public ChartCellItem[] c
        {
            get
            {
                ChartCellItem[] myCellItems = (ChartCellItem[])_cellItems.ToArray(typeof(ChartCellItem));
                return myCellItems;
            }
        }

        public void AddCellItem(ChartCellItem cellItem)
        {
            _cellItems.Add(cellItem);
        }

    }
}