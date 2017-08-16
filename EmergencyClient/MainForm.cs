using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace EmergencyClient
{
    public partial class MainForm : Form
    {
        string userName;

        int WIDTH = 600;
        int HEIGHT = 599;

        int messageCounter;
        List<EmergencyInfo> emergencyData = new List<EmergencyInfo>();
        List<EmergencyInfo> gridData = new List<EmergencyInfo>();
        Dictionary<string, int> readyDepartments = new Dictionary<string, int>();
        Dictionary<string, int> notReadyDepartments = new Dictionary<string, int>();
        LoginForm loginForm = new LoginForm();
        WebClient client = new WebClient();
        string lastDate;
        string data;

        Resizer resizer;
        int lastFormSize;
        bool isMaximized = false;

        public MainForm(string userName, LoginForm loginForm)
        {
            InitializeComponent();

            findButton.Visible = false;

            resizer = new Resizer(new Font("Microsoft Sans Serif", 11f, FontStyle.Regular), 50, HEIGHT, false);

            this.loginForm = loginForm;
            this.userName = userName;
            userNameLabel.Text = this.userName;

            lastFormSize = this.Height;
            this.MinimumSize = new Size(WIDTH, HEIGHT);
            this.Size = this.MinimumSize;

            FillDepartments();
            CloseSearch();

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                dataGridView1.Columns[i].HeaderCell.Style = style;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.ColumnCount;
            }
        }

        private void ClearDataGridView()
        {
            while (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
        }

        private void ClearAllData()
        {
            ClearDataGridView();
            richTextBox1.Clear();
            gridData.Clear();
            readyDepartments.Clear();
            notReadyDepartments.Clear();
            FillDepartments();
        }

        private void ShowSearch()
        {
            this.tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1].Height = 16;
            this.MinimumSize = new Size(WIDTH, HEIGHT + 122);
            this.Size = this.MinimumSize;
        }

        private void CloseSearch()
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1].Height = 0;
                this.MinimumSize = new Size(WIDTH, HEIGHT);
                this.Size = this.MinimumSize;
            }
        }

        private EmergencyInfo FillEmergencyInfo(ref int counter)
        {
            EmergencyInfo emInfo = new EmergencyInfo();

            if (nameTextBox.Text != "")
            {
                emInfo.userName = nameTextBox.Text;
                counter++;
            }
            if (departmentTextBox.Text != "")
            {
                emInfo.department = departmentTextBox.Text;
                counter++;
            }
            if (userGroupTextBox.Text != "")
            {
                emInfo.userGroup = userGroupTextBox.Text;
                counter++;
            }
            if (readyCheckBox.Checked)
            {
                emInfo.status = "1";
                counter++;
            }
            if (notReadyCheckBox.Checked)
            {
                emInfo.status = "0";
                counter++;
            }
            if (emailTextBox.Text != "")
            {
                emInfo.email = emailTextBox.Text;
                counter++;
            }
            if (longitudeTextBox.Text != "")
            {
                emInfo.longitude = longitudeTextBox.Text;
                counter++;
            }
            if (latitudeTextBox.Text != "")
            {
                emInfo.latitude = latitudeTextBox.Text;
                counter++;
            }

            return emInfo;
        }

        private void FillDepartments()
        {
            readyDepartments.Add("Supervisor", 0);
            notReadyDepartments.Add("Supervisor", 0);

            readyDepartments.Add("Сотрудники БОКК", 0);
            notReadyDepartments.Add("Сотрудники БОКК", 0);

            readyDepartments.Add("РЦУРЧС", 0);
            notReadyDepartments.Add("РЦУРЧС", 0);

            readyDepartments.Add("Руководство", 0);
            notReadyDepartments.Add("Руководство", 0);

            readyDepartments.Add("Минское городское УМЧС", 0);
            notReadyDepartments.Add("Минское городское УМЧС", 0);

            readyDepartments.Add("ЦА", 0);
            notReadyDepartments.Add("ЦА", 0);

            readyDepartments.Add("Анонимные пользователи", 0);
            notReadyDepartments.Add("Анонимные пользователи", 0);
        }

        private void RefrshButton_Click(object sender, EventArgs e)
        {
            ClearAllData();

            messageCounter = 0;

            DateTime dateTime = monthCalendar1.SelectionStart;
            lastDate = dateTime.ToString("yyy-MM-dd");

            try
            {
                data = client.DownloadString("http://alfasoft.by/jdir-mchs-test/test-request/" + "?date=" + lastDate);

                if (data != null)
                    FillGridWithData(messageCounter);
                else
                    MessageBox.Show("Нет запрашиваемых данных.", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Нет подключения. Проверьте соединение с сервером.", 
                                "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            int fieldsCount = 0;
            int counter = 0;
            string geoData1;
            string geoData2;

            if (emergencyData.Count != 0)
            {
                EmergencyInfo info = FillEmergencyInfo(ref fieldsCount);

                if (fieldsCount != 0)
                {
                    gridData.Clear();
                    ClearDataGridView();

                    foreach (EmergencyInfo emInfo in emergencyData)
                    {
                        if (emInfo.userName == info.userName && emInfo.userName != null)
                            counter++;
                        if (emInfo.department == info.department && emInfo.department != null)
                            counter++;
                        if (emInfo.messageCount == info.messageCount && emInfo.messageCount != null)
                            counter++;
                        if (emInfo.userGroup == info.userGroup && emInfo.userGroup != null)
                            counter++;
                        if (emInfo.longitude != null && info.longitude != null)
                        {
                            geoData1 = emInfo.longitude.Replace('.', ',');
                            geoData2 = info.longitude.Replace('.', ',');

                            if ((Math.Abs(double.Parse(geoData1) - double.Parse(geoData2))*200000 <= 30))
                                counter++;
                        }
                        if (emInfo.latitude != null && info.latitude != null)
                        {
                            geoData1 = emInfo.latitude.Replace('.', ',');
                            geoData2 = info.latitude.Replace('.', ',');

                            if ((Math.Abs(double.Parse(geoData1) - double.Parse(geoData2))*100000 <= 30))
                                counter++;
                        }
                        if (emInfo.email == info.email && emInfo.email != null)
                            counter++;
                        if (emInfo.status == info.status && emInfo.status != null)
                            counter++;

                        if (counter == fieldsCount)
                            AddFoundData(emInfo);

                        counter = 0;
                    }

                    if (dataGridView1.Rows.Count == 0)
                        MessageBox.Show("Искомые данные не найдены. Проверьте корректность вводимых данных.", 
                                        "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Для выполнения поиска необходимо заполнить хотя бы одно поле...", 
                                    "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Для выполнения поиска необходимо заполнить таблицу. Выполните обновление данных", 
                                "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddFoundData(EmergencyInfo emInfo)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = resizer.GridRowHeight;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font = resizer.GridFont;

            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = emInfo.userName;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = emInfo.department;
            if (emInfo.status == "1")
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Готов";
            if (emInfo.status == "0")
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Не готов";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = emInfo.messageCount;

            gridData.Add(emInfo);
        }

        private void FillGridWithData(int messageCounter)
        {
            byte[] bytes = Encoding.Default.GetBytes(data);
            data = Encoding.UTF8.GetString(bytes);

            emergencyData = JsonConvert.DeserializeObject<List<EmergencyInfo>>(data);

            foreach (EmergencyInfo emInfo in emergencyData)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = resizer.GridRowHeight;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font = resizer.GridFont;

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = emInfo.userName;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = emInfo.department;
                if (emInfo.status == "1")
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Готов";
                else
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Не готов";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = emInfo.messageCount;

                if (readyDepartments.Keys.Contains(emInfo.department))
                {
                    if (emInfo.status == "1")
                        readyDepartments[emInfo.department]++;
                    else if (emInfo.status == "0")
                        notReadyDepartments[emInfo.department]++;
                }

                gridData.Add(emInfo);
                messageCounter += Int32.Parse(emInfo.messageCount);
            }

            FillRichTextBoxWithData();
        }

        private void FillRichTextBoxWithData()
        {
            richTextBox1.AppendText("Общие данные:\n");
            richTextBox1.AppendText("За текущая дата - " + messageCounter + " сообщений\n\n");
            richTextBox1.AppendText("Статус готовности:\n");

            foreach (KeyValuePair<string, int> department in readyDepartments)
            {
                richTextBox1.AppendText(department.Key + "\n");
                richTextBox1.AppendText("Готовы - " + department.Value + ", Не готовы - " + 
                                        notReadyDepartments[department.Key] + "\n\n");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ShowSearch();
                findButton.Visible = true;      
            }
            else
            {
                CloseSearch();
                findButton.Visible = false;
            }
        }

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void geoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(46))
            {
                e.Handled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //private void reloginButton_Click(object sender, EventArgs e)
        //{
        //    ClearAllData();
        //    this.Hide();
        //    loginForm.Show();
        //}

        private void MainForm_Resize(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = dataGridView1.Width / dataGridView1.ColumnCount;

            if (this.WindowState == FormWindowState.Maximized)
            {
                checkBox1.Checked = true;
                checkBox1.Enabled = false;

                resizer.ResizeForm(this.Height, isMaximized, dataGridView1, this.Controls);
                lastFormSize = this.Height;
                isMaximized = true;
            }

            if (this.WindowState == FormWindowState.Normal && isMaximized)
            {
                checkBox1.Enabled = true;

                resizer.ResizeForm(lastFormSize, isMaximized, dataGridView1, this.Controls);
                lastFormSize = this.Height;
                isMaximized = false;

                //checkBox1.Checked = false;
                ShowSearch();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                SaveForm saveForm = new SaveForm(gridData);
                saveForm.ShowDialog();
            }
            else
                MessageBox.Show("Для сохранения выполните поиск пользователей.", 
                                "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                List<Message> messages = new List<Message>();

                string userName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                try
                {
                    data = client.DownloadString("http://alfasoft.by/jdir-mchs-test/test-request/?user=" + userName + "&date=" + lastDate);

                    if (data != null)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(data);
                        data = Encoding.UTF8.GetString(bytes);

                        messages = JsonConvert.DeserializeObject<List<Message>>(data);

                        foreach (EmergencyInfo emInfo in emergencyData)
                        {
                            if (emInfo.userName == userName)
                            {
                                DetailedData detailedData = new DetailedData(emInfo, messages);
                                detailedData.Show();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Нет запрашиваемых данных.", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show("Нет подключения. Проверьте соединение с сервером.", 
                                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void readyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (readyCheckBox.Checked)
                notReadyCheckBox.Checked = false;
        }

        private void notReadyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (notReadyCheckBox.Checked)
                readyCheckBox.Checked = false;
        }

        private void latitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(46))
            {
                e.Handled = true;
            }
        }
    }
}

