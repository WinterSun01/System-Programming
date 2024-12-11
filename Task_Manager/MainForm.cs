using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Task_Manager;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        Dictionary<int, Process> processes;
        ListViewColumnSorter lvColumnSorter;

        Dictionary<string, bool> selectedColumns = new Dictionary<string, bool>();

        public MainForm()
        {
            InitializeComponent();
            LoadProcesses();


            lvColumnSorter = new ListViewColumnSorter();
            listViewProcesses.ListViewItemSorter = lvColumnSorter;

            AdjustColumnsWidth();

            AllocConsole();
            InitSelectedColumns();
        }
        void InitSelectedColumns()
        {
            foreach (ToolStripMenuItem i in mainMenuViewColumns.DropDownItems)
            {
                selectedColumns[i.Text] = i.Checked;
            }
            PrintSelectedColumns();
        }
        void SetColumnsVisibility()
        {
            AdjustColumnsWidth();
            for (int i = 1; i < listViewProcesses.Columns.Count; i++)
            {
                if (selectedColumns[listViewProcesses.Columns[i].Text] == false)
                    listViewProcesses.Columns[i].Width = 0;
            }
        }
        //void SetColumns()
        //{
        //	listViewProcesses.Columns.Clear();
        //	listViewProcesses.Columns.Add("Name");
        //	//Console.WriteLine(listViewProcesses.Items[0].SubItems["PID"].Name);
        //	if (mainMenuViewSelectColumnsPID.Checked) listViewProcesses.Columns.Add("PID");
        //	if (mainMenuViewSelectColumnsOwner.Checked) listViewProcesses.Columns.Add("Owner");
        //	if (mainMenuViewSelectColumnsPath.Checked) listViewProcesses.Columns.Add("Path");

        //	AdjustColumnsWidth();
        //}
        void AdjustColumnsWidth()
        {
            foreach (ColumnHeader ch in this.listViewProcesses.Columns)
            {
                //https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/sort-listview-by-column#:~:text=foreach%20(ColumnHeader%20ch%20in%20this.listView1.Columns)%0A%7B%0A%20%20%20%20ch.Width%20%3D%20%2D2%3B%0A%7D
                //https://stackoverflow.com/questions/1257500/c-sharp-listview-column-width-auto
                ch.Width = -1;//????
            }
        }
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        int GetColumnIndex(string name)
        {
            for (int i = 0; i < listViewProcesses.Columns.Count; i++)
            {
                if (listViewProcesses.Columns[i].Text == name) return i;
            }
            return -1;
        }
        void LoadProcesses()
        {
            processes = Process.GetProcesses().ToDictionary(i => i.Id);
            //for (int i = 0; i < processes.Count; i++)
            //{
            //	//listViewProcesses.Items
            //	//	.Add(processes[i]).SubItems
            //	//	.Add(processes[i].ProcessName);
            //}
            foreach (KeyValuePair<int, Process> p in processes)
            {
                //listViewProcesses.Items.Add(p.Key.ToString()).SubItems.Add(p.Value.ProcessName);
                //----------------------
                //ListViewItem item = new ListViewItem();
                //item.Name = item.Text = p.Key.ToString();
                //item.SubItems.Add(p.Value.ProcessName);
                //listViewProcesses.Items.Add(item);
                AddProcessToListView(p.Value);
            }
        }
        void AddNewProcesses()
        {
            foreach (KeyValuePair<int, Process> p in processes)
            {
                if (!listViewProcesses.Items.ContainsKey(p.Key.ToString()))
                {
                    //listViewProcesses.Items.Add(p.Key.ToString()).SubItems.Add(p.Value.ProcessName);
                    //------------------------------
                    AddProcessToListView(p.Value);
                }
            }
        }
        void AddProcessToListView(Process p)
        {
            ListViewItem item = new ListViewItem();
            item.Name = p.Id.ToString();
            item.Text = p.ProcessName;
            //item.Name = item.Text = p.Id.ToString();
            item.SubItems.Add(p.Id.ToString());
            item.SubItems.Add(GetProcessUser(p));
            try
            {
                item.SubItems.Add(p.MainModule.FileName);
            }
            catch (Win32Exception ex)
            {
                item.SubItems.Add("");
            }

            listViewProcesses.Items.Add(item);
        }
        void RemoveOldProcesses()
        {
            foreach (ListViewItem i in listViewProcesses.Items)
            {
                //if (processes[Convert.ToInt32(i.SubItems[0].Text)])
                if (!processes.ContainsKey(Convert.ToInt32(i.SubItems[1].Text)))
                {
                    listViewProcesses.Items.Remove(i);
                }
            }
        }
        void RefreshProcesses()
        {
            processes = Process.GetProcesses().ToDictionary(i => i.Id);
            RemoveOldProcesses();
            AddNewProcesses();
            //foreach (ColumnHeader ch in this.listViewProcesses.Columns)
            //{
            //	//https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/sort-listview-by-column#:~:text=foreach%20(ColumnHeader%20ch%20in%20this.listView1.Columns)%0A%7B%0A%20%20%20%20ch.Width%20%3D%20%2D2%3B%0A%7D
            //	//https://stackoverflow.com/questions/1257500/c-sharp-listview-column-width-auto
            //	ch.Width = -2;//????
            //}
        }
        void DestroyProcess(int pid)
        {
            processes[pid].Kill();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshProcesses();
            toolStripStatusLabelProcessCount.Text = $"Processes count: {listViewProcesses.Items.Count.ToString()}";
            //SetColumns();
        }

        private void mainMenuFileRun_Click(object sender, EventArgs e)
        {
            RunFileDlg(this.Handle, IntPtr.Zero, "C:\\Windows\\System32\\", "Run PD_311", "Task manager! Привет от PD_311 ;-)", 1);
        }
        //https://stackoverflow.com/questions/9331088/how-to-start-windows-run-dialog-from-c-sharp
        [DllImport("shell32.dll", EntryPoint = "#61", CharSet = CharSet.Unicode)]
        public static extern int RunFileDlg
            (
                [In] IntPtr hwnd,
                [In] IntPtr icon,
                [In] string path,
                [In] string title,
                [In] string prompt,
                [In] uint flags
            );

        private void destroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count > 0)
                DestroyProcess(Convert.ToInt32(listViewProcesses.SelectedItems[0].Name));
        }

        private void contextMenuProcList_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemOpenFileLocation.Enabled =
            toolStripMenuItemDestroy.Enabled =
                listViewProcesses.SelectedItems.Count > 0;
        }

        private void toolStripMenuItemOpenFileLocation_Click(object sender, EventArgs e)
        {
            string filename = processes[Convert.ToInt32(listViewProcesses.SelectedItems[0].Name)].MainModule.FileName;
            //MessageBox.Show(this, filename, "Location", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //filename = filename.Remove(filename.LastIndexOf("\\"));
            ShellExecute(this.Handle, "open", "explorer.exe", $"/select, \"{filename}\"", "", 1);
            //Process.Start("explorer", filename);
        }
        //https://stackoverflow.com/questions/1746079/how-can-i-open-windows-explorer-to-a-certain-directory-from-within-a-wpf-app
        //https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shellexecutea
        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute
            (
                IntPtr hwnd,
                string lpOperation,
                string lpFile,
                string lpParameters,
                string lpDirectory,
                int nCmdShow
            );

        private void listViewProcesses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvColumnSorter.SortColumn)
            {
                if (lvColumnSorter.Order == SortOrder.Ascending)
                    lvColumnSorter.Order = SortOrder.Descending;
                else
                    lvColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                lvColumnSorter.SortColumn = e.Column;
                lvColumnSorter.Order = SortOrder.Ascending;
            }
            this.listViewProcesses.Sort();
        }

        //Process owner:
        //https://stackoverflow.com/questions/777548/how-do-i-determine-the-owner-of-a-process-in-c
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool OpenProcessToken(IntPtr handle, uint DesiredAccess, out IntPtr TokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        static string GetProcessUser(Process process)
        {
            string username = "N/A";
            IntPtr processHandle = IntPtr.Zero;
            try
            {
                OpenProcessToken(process.Handle, 8, out processHandle);
                using (WindowsIdentity wi = new WindowsIdentity(processHandle))
                {
                    username = wi.Name;
                }
            }
            catch (Win32Exception ex)
            {

            }
            return username;
        }
        void PrintSelectedColumns()
        {
            foreach (KeyValuePair<string, bool> p in selectedColumns)
            {
                Console.WriteLine(p.Key + "\t" + p.Value);
            }
            Console.WriteLine("\n------------------------------------\n");
        }
        private void mainMenuViewSelectColumns_Click(object sender, EventArgs e)
        {
            selectedColumns[(sender as ToolStripMenuItem).Text] = (sender as ToolStripMenuItem).Checked;
            PrintSelectedColumns();
            SetColumnsVisibility();
        }

        //private void mainMenuViewSelectColumnsOwner_Click(object sender, EventArgs e)
        //{
        //	selectedColumns[(sender as ToolStripMenuItem).Text] = (sender as ToolStripMenuItem).Checked;
        //	PrintSelectedColumns();
        //}

        //private void mainMenuViewSelectColumnsPath_Click(object sender, EventArgs e)
        //{
        //	selectedColumns[(sender as ToolStripMenuItem).Text] = (sender as ToolStripMenuItem).Checked;
        //	PrintSelectedColumns();
        //}
    }
}