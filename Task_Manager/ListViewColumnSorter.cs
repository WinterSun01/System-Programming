using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Task_Manager
{
    internal class ListViewColumnSorter : IComparer
    {
        //int columnToSort;
        //SortOrder orderOfSort;
        CaseInsensitiveComparer objectCompare;
        public int SortColumn { get; set; }
        //{
        //    get => columnToSort;
        //    set => columnToSort = value;
        //}
        public SortOrder Order { get; set; }
        //{
        //    get => orderOfSort;
        //    set => orderOfSort = value;
        //}

        public ListViewColumnSorter()
        {
            //columnToSort = 0;
            //orderOfSort = SortOrder.None;
            SortColumn = 0;
            Order = SortOrder.None;
            objectCompare = new CaseInsensitiveComparer();
        }
        public int Compare(object x, object y)
        {
            ListViewItem listViewX = (ListViewItem)x;
            ListViewItem listViewY = (ListViewItem)y;
            int compareResult;
            if (double.TryParse(listViewX.SubItems[SortColumn].Text, out _))
            {
                compareResult = objectCompare.Compare
                    (
                    Convert.ToDouble(listViewX.SubItems[SortColumn].Text),
                    Convert.ToDouble(listViewY.SubItems[SortColumn].Text)
                    );
            }
            else
            {
                compareResult =
                objectCompare.Compare
                (
                    listViewX.SubItems[SortColumn].Text,
                    listViewY.SubItems[SortColumn].Text
                );
            }

            if (Order == SortOrder.Ascending)
                return compareResult;
            else if (Order == SortOrder.Descending)
                return -compareResult;
            //else
            return compareResult;
        }
    }
}