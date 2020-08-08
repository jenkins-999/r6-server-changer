using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net.Configuration;

namespace R6ServerChanger
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "R6S Server Changer v1 - byJenkins";
                groupBox1.Text = "Current server";
                groupBox2.Text = "Uplay profile";
                button1.Text = "Clear profiles";
                button2.Text = "Apply";
                button3.Text = "Discord";
                button4.Text = "Readme.txt";
                button5.Text = "Github";
                comboBox2.Enabled = false;

                comboBox2.Items.Add("default");
                comboBox2.Items.Add("eastus");
                comboBox2.Items.Add("centralus");
                comboBox2.Items.Add("southcentralus");
                comboBox2.Items.Add("westus");
                comboBox2.Items.Add("brazilsouth");
                comboBox2.Items.Add("northeurope");
                comboBox2.Items.Add("westeurope");
                comboBox2.Items.Add("southafricanorth");
                comboBox2.Items.Add("eastasia");
                comboBox2.Items.Add("southeastasia");
                comboBox2.Items.Add("australiaeast");
                comboBox2.Items.Add("australiasoutheast");
                comboBox2.Items.Add("japanwest");

                String UplayID = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Rainbow Six - Siege";
                string[] files = Directory.GetDirectories(UplayID);
                foreach (string file in files)
                {
                    var prefix = UplayID + "\\";
                    var TheID = files.Where(s => s.StartsWith(prefix)).Select(s => s.Substring(prefix.Length)).ToArray();
                    comboBox1.Items.AddRange(TheID);
                }
                List<object> list = new List<object>();
                foreach (object o in comboBox1.Items)
                {
                    if (!list.Contains(o))
                    {
                        list.Add(o);
                    }
                }
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(list.ToArray());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message+"");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var UplayIDdirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Rainbow Six - Siege");
                if (MessageBox.Show("Do you want to delete your UplayID(s)?\n\n(They will be recreated when you launch r6)", "   Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    UplayIDdirectory.Delete(true);
                    MessageBox.Show("UplayID(s) has been deleted.");
                }
                else
                {

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message+"");
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/tgpsgkN");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jenkins-999/my-projects");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Source code will be available ASAP!");
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Enabled = true;

                string UplayIDText = comboBox1.Text;
                string GameSettingsLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Rainbow Six - Siege\\" + UplayIDText + "\\GameSettings.ini";
                string GameSettings = File.ReadAllText(GameSettingsLocation);
                string line = File.ReadLines(GameSettingsLocation).Skip(149).Take(1).First();
                if ((line == "DataCenterHint=default") || (line == "DataCenterHint=playfab/default"))
                {
                    comboBox2.Text = "default";
                }
                else if ((line == "DataCenterHint=eastus") || (line == "DataCenterHint=playfab/eastus"))
                {
                    comboBox2.Text = "eastus";
                }
                else if ((line == "DataCenterHint=centralus") || (line == "DataCenterHint=playfab/centralus"))
                {
                    comboBox2.Text = "centralus";
                }
                else if ((line == "DataCenterHint=southcentralus") || (line == "DataCenterHint=playfab/southcentralus"))
                {
                    comboBox2.Text = "southcentralus";
                }
                else if ((line == "DataCenterHint=westus") || (line == "DataCenterHint=playfab/westus"))
                {
                    comboBox2.Text = "westus";
                }
                else if ((line == "DataCenterHint=brazilsouth") || (line == "DataCenterHint=playfab/brazilsouth"))
                {
                    comboBox2.Text = "brazilsouth";
                }
                else if ((line == "DataCenterHint=northeurope") || (line == "DataCenterHint=playfab/northeurope"))
                {
                    comboBox2.Text = "northeurope";
                }
                else if ((line == "DataCenterHint=westeurope") || (line == "DataCenterHint=playfab/westeurope"))
                {
                    comboBox2.Text = "westeurope";
                }
                else if ((line == "DataCenterHint=southafricanorth") || (line == "DataCenterHint=playfab/southafricanorth"))
                {
                    comboBox2.Text = "southafricanorth";
                }
                else if ((line == "DataCenterHint=eastasia") || (line == "DataCenterHint=playfab/eastasia"))
                {
                    comboBox2.Text = "eastasia";
                }
                else if ((line == "DataCenterHint=southeastasia") || (line == "DataCenterHint=playfab/southeastasia"))
                {
                    comboBox2.Text = "southeastasia";
                }
                else if ((line == "DataCenterHint=australiaeast") || (line == "DataCenterHint=playfab/australiaeast"))
                {
                    comboBox2.Text = "australiaeast";
                }
                else if ((line == "DataCenterHint=australiasoutheast") || (line == "DataCenterHint=playfab/australiasoutheast"))
                {
                    comboBox2.Text = "australiasoutheast";
                }
                else if ((line == "DataCenterHint=japanwest") || (line == "DataCenterHint=playfab/japanwest"))
                {
                    comboBox2.Text = "japanwest";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message+"");
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string UplayIDText = comboBox1.Text;
                string GameSettingsLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Rainbow Six - Siege\\" + UplayIDText + "\\GameSettings.ini";
                string GameSettings = File.ReadAllText(GameSettingsLocation);
                string line = File.ReadLines(GameSettingsLocation).Skip(149).Take(1).First();
                string selectedServer = "DataCenterHint=playfab/" + comboBox2.Text;

                if ((line == "DataCenterHint=default") || (line == "DataCenterHint=playfab/default"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=eastus") || (line == "DataCenterHint=playfab/eastus"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=centralus") || (line == "DataCenterHint=playfab/centralus"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=southcentralus") || (line == "DataCenterHint=playfab/southcentralus"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=westus") || (line == "DataCenterHint=playfab/westus"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=brazilsouth") || (line == "DataCenterHint=playfab/brazilsouth"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=northeurope") || (line == "DataCenterHint=playfab/northeurope"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=westeurope") || (line == "DataCenterHint=playfab/westeurope"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=southafricanorth") || (line == "DataCenterHint=playfab/southafricanorth"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=eastasia") || (line == "DataCenterHint=playfab/eastasia"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=southeastasia") || (line == "DataCenterHint=playfab/southeastasia"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=australiaeast") || (line == "DataCenterHint=playfab/australiaeast"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=australiasoutheast") || (line == "DataCenterHint=playfab/australiasoutheast"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                else if ((line == "DataCenterHint=japanwest") || (line == "DataCenterHint=playfab/japanwest"))
                {
                    GameSettings = GameSettings.Replace(line, selectedServer);
                }
                File.WriteAllText(GameSettingsLocation, GameSettings);
                MessageBox.Show("Your server location has been changed !!", "   Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message+"");
            }
        }
    }
}
