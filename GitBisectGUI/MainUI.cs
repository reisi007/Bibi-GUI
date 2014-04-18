using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;
using System.Threading;

namespace GitBisectGUI
{
    public partial class MainUI : Form
    {
        private enum Settings { FOLDER_ONDISK = 0, FOLDERR_INCLOUD, L10N, PATH_SOFFICE }
        private readonly string PATH = "bibisetting";
        private readonly string FILENAME = "main.settings";
        private string PATH_SOFFICE_EXE = System.IO.Path.Combine("instdir", "program", "soffice.exe");
        private string[] settings = new string[] { "", "", "en", "" };
        enum settingsID { folderondisk = 0, fileincloud, lang };
        private bool loadSettings()
        {
            try
            {
                List<String> list = new List<string>();
                list.AddRange(System.IO.File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, PATH, FILENAME)));
                while (list.Count < settings.Length)
                    list.Add("");
                settings = list.ToArray();
                tb_ondisk.Text = settings[(int)Settings.FOLDER_ONDISK];
                tb_incloud.Text = settings[(int)Settings.FOLDERR_INCLOUD];
                if (settings[(int)Settings.PATH_SOFFICE].Length > "soffice".Length)
                    PATH_SOFFICE_EXE = settings[(int)Settings.PATH_SOFFICE];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            /* foreach (String s in settings)
                 MessageBox.Show(s + "\t" + s.Length);*/
            return true;
        }
        private void saveSettings(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }
        private void saveSettings()
        {
            settings[(int)Settings.FOLDER_ONDISK] = tb_ondisk.Text;
            settings[(int)Settings.FOLDERR_INCLOUD] = tb_incloud.Text;
            settings[(int)Settings.PATH_SOFFICE] = PATH_SOFFICE_EXE;
            try
            {
                System.IO.Directory.CreateDirectory(PATH);
                System.IO.File.WriteAllLines(System.IO.Path.Combine(PATH, FILENAME), settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public MainUI()
        {
            InitializeComponent();
            loadSettings();
            updateDropdownList();
        }
        private void updateDropdownList()
        {
            // init repo
            if (tb_ondisk.Text.Length > 0)
            {
                git = new Repository(tb_ondisk.Text);
                List<BisectStep> bss = new List<BisectStep>();
                StringBuilder sb = new StringBuilder();
                ICommitLog commits = git.Branches["master"].Commits;
                for (int i = commits.Count() - 1; i >= 0; i--)
                    bss.Add(new BisectStep(commits.ElementAt(i)));
                steps = bss.ToArray();
                cb_from.DataSource = bss;
                cb_from.Enabled = cb_to.Enabled = b_start.Enabled = true;
            }else
            {
                cb_from.Enabled = cb_to.Enabled = b_start.Enabled = false;
            }

        }

        Repository git;

        private void b_searchRepo_Click(object sender, EventArgs e)
        {
            if (fbd_repoOnDisk.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tb_ondisk.Text = fbd_repoOnDisk.SelectedPath;
        }
        BisectStep[] steps;

        private int getArrayIndex(Object bisectStep)
        {
            for (int i = 0; i < steps.Length; i++)
                if (steps[i].Equals(bisectStep))
                    return i;
            return -1;
        }

        int LastKnownWorking = -1, FirstKnownNotWorking = -1;
        private void b_start_Click(object sender, EventArgs e)
        {
            if (git == null)
            {
                MessageBox.Show("No repository specified!");
            }
            MessageBox.Show("Total number of steps: " + (2 + Math.Round(Math.Log(steps.Length, 2), 0)));
            /*
             * Bisecting starts here
             */
            MessageBox.Show("OLDEST =" + steps[0].getCommit().Message + "\n" + steps[0].getCommit().Sha + "\nLATEST = " + steps[steps.Length - 1].getCommit().Message + "\n" + steps[steps.Length - 1].getCommit().Sha);
            // Test oldest (Has to be GOOD)
            int i = getArrayIndex(cb_from.SelectedItem);
            int r = BisectStep.Result.SKIP;
            try
            {
                while (r == BisectStep.Result.SKIP || r == BisectStep.Result.NOTSET)
                {
                    i++;
                    r = doStep(ref steps[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LastKnownWorking = i;
            if (r != BisectStep.Result.GOOD)
            {
                MessageBox.Show("Problem can't be bisected!", "Out of range");
                return;
            }
            r = BisectStep.Result.SKIP;
            i = -1;
            // Test latest (Has to be BAD)
            try
            {
                while (r == BisectStep.Result.SKIP || r == BisectStep.Result.NOTSET)
                {
                    i--;
                    r = doStep(ref steps[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FirstKnownNotWorking = i;
            int next = -1;
            while (nextStep(LastKnownWorking, FirstKnownNotWorking, out next))
            {
                next = doStep(ref steps[next]);
                if (next == BisectStep.Result.GOOD)
                    LastKnownWorking = next;
                if (next == BisectStep.Result.BAD)
                    FirstKnownNotWorking = next;
                //Test rest
                addOutputLine("Commits unknown: " + (LastKnownWorking - FirstKnownNotWorking - 1));

            }
            if (next != -1)
            {
                Commit isWorking = steps[LastKnownWorking].getCommit(), notWorking = steps[FirstKnownNotWorking].getCommit();
                addOutputLine("Rsult:\nError introduced between:\n" + isWorking.Id + "(" + isWorking.MessageShort + ")\nAND\n" + notWorking.Id + "(" + notWorking.MessageShort + ")");
            }
            else addOutputLine("An error occured. result not valid....");

        }
        //og is oldest good lb is latest bad Oldest << Latest
        private bool nextStep(int og, int lb, out int next)
        {
            next = -1;
            if (og > lb)
                return false;
            if (isSKIPonly(og, lb))
            {
                next = 0;
                return false;
            }
            next = og + (lb - og) / 2;
            if (steps[next].getResult() == BisectStep.Result.SKIP)
                next = og + 1;
            return true;
        }
        private bool isSKIPonly(int from, int to)
        {
            for (int i = from + 1; i < to; i++)
            {
                if (steps[i].getResult() != BisectStep.Result.SKIP)
                    return false;
            }
            return true;
        }

        private int doStep(ref BisectStep bss)
        {
            /* System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); // Time measurement
             sw.Start();*/
            // Checkout
            git.Checkout(bss.getCommit(), CheckoutModifiers.Force, (path, completed, total) =>
            {
                progressBar1.Value = total == 0 ? 100 : (int)((((float)completed) / total) * 100);
            }, null);
            /* sw.Stop();
             MessageBox.Show(sw.ElapsedMilliseconds / 1000f + "sec(" + bss.getCommit().Sha + ")");*/
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(System.IO.Path.Combine(new string[] { tb_ondisk.Text, PATH_SOFFICE_EXE }));
            if (System.IO.File.Exists(p.StartInfo.FileName))
                p.Start();
            else
                return BisectStep.Result.SKIP;
            GBS form = new GBS();
            DialogResult dr = form.ShowDialog();
            int result = int.MaxValue;
            while (!p.HasExited)
                MessageBox.Show("Please close LibreOffice to continue!", "Close LibreOffice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            switch (dr)
            {
                case (DialogResult.Yes):
                    result = BisectStep.Result.GOOD;
                    break;
                case (DialogResult.No):
                    result = BisectStep.Result.BAD;
                    break;
                case (DialogResult.Ignore):
                    result = BisectStep.Result.SKIP;
                    break;
            }
            bss.setResult(result);
            return result;
        }


        private void addOutputLine(string s)
        {
            output.Text = s + Environment.NewLine + output.Text;
        }

        private void bcheckSettings_Click(object sender, EventArgs e)
        {
            saveSettings();
            StringBuilder sb = new StringBuilder("The start binary would be this file:\n");
            sb.AppendLine(System.IO.Path.Combine(tb_ondisk.Text, PATH_SOFFICE_EXE));
            sb.AppendLine("If the path does not seems to be correct, is the following part correct?");
            sb.AppendLine(settings[(int)Settings.FOLDER_ONDISK]);
            sb.AppendLine("If no, please specify the folder using the \"" + b_searchRepo.Text + "\" button");
            sb.AppendLine("Otherwise please close the program, open the settings file located at: \"" + System.IO.Path.Combine(PATH, FILENAME) + "\" and edit the line with number " + ((int)Settings.PATH_SOFFICE));
            sb.AppendLine("Please keep in mind, that the program saves the settings on close!");
            MessageBox.Show(sb.ToString());
        }

        private void cb_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_to.BeginUpdate();
            int from = getArrayIndex(((ComboBox)sender).SelectedItem);
            List<BisectStep> tmp = new List<BisectStep>();
            for (int i = from + 1; i < steps.Length; i++)
                tmp.Add(steps[i]);
            cb_to.DataSource = tmp;
            if (cb_to.SelectedIndex == 0)
                cb_to.SelectedIndex = tmp.Count - 1;
            cb_to.EndUpdate();
        }

        private void tb_ondisk_Leave(object sender, EventArgs e)
        {
            updateDropdownList();
        }


    }
}
