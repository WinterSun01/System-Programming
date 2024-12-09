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
using Task_Manager;
using System.Security.Principal;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        Dictionary<int, Process> processes;
        ListViewColumnSorter lvColumnSorter;
        public MainForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            LoadProcesses();
            foreach (ColumnHeader ch in this.listViewProcesses.Columns)
            {
                ch.Width = -2;
            }

            lvColumnSorter = new ListViewColumnSorter();
            listViewProcesses.ListViewItemSorter = lvColumnSorter;
        }

        void LoadProcesses()
        {
            processes = Process.GetProcesses().ToDictionary(i => i.Id);

            foreach (KeyValuePair<int, Process> p in processes)
            {
                AddProcessToListView(p.Value);
            }
        }
        void AddNewProcesses()
        {
            foreach (KeyValuePair<int, Process> p in processes)
            {
                if (!listViewProcesses.Items.ContainsKey(p.Key.ToString()))
                {
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
        }
        void DestroyProcess(int pid)
        {
            processes[pid].Kill();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshProcesses();
            toolStripStatusLabelProcessCount.Text = $"Processes count: {listViewProcesses.Items.Count.ToString()}";
        }

        private void mainMenuFileRun_Click(object sender, EventArgs e)
        {
            RunFileDlg(this.Handle, IntPtr.Zero, "C:\\Windows\\System32\\", "Run PD_311", "Поиск", 1);
        }
        
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

        [DllImport("advapi32.dll", SetLastError = true)]

        static extern bool OpenProcessToken(IntPtr handle, uint DesiredAcces, out IntPtr TokenHandle);
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
        private void mainMenuViewTopmost_Click(object sender, EventArgs e)
        {
            this.TopMost = mainMenuViewTopmost.Checked;
        }

        private void mainMenuViewHide_Click(object sender, EventArgs e)
        {
            if (mainMenuViewHide.Checked)
            {
                this.SizeChanged += MainForm_SizeChanged;
            }
            else
            {
                this.SizeChanged -= MainForm_SizeChanged;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && mainMenuViewHide.Checked)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
            }
        }

        private void InitializeNotifyIcon()
        {
            this.notifyIcon = new NotifyIcon(this.components)
            {
                Text = "TaskManagerPD_311",
                Icon = System.Drawing.SystemIcons.Application,
                Visible = false
            };
            this.notifyIcon.Click += (s, ev) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.notifyIcon.Visible = false;
            };
        }
    }
}