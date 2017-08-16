using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmergencyClient
{
    public partial class DetailedData : Form
    {
        EmergencyInfo emInfo;
        bool isMaximized = false;
        int lastFormSize;
        List<string> fileNames = new List<string>();
        ImageList images = new ImageList();
        List<Message> messages = new List<Message>();
        WebClient client = new WebClient();
        Resizer resizer;

        int HEIGHT;
        int fieldsCount = 7;

        public delegate void myDelegate();

        public DetailedData(EmergencyInfo info, List<Message> messages)
        {
            InitializeComponent();

            dataGridView1.RowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            this.messages = messages;
            HEIGHT = this.Height;
            resizer = new Resizer(dataGridView1.RowsDefaultCellStyle.Font, 50, HEIGHT, true);
            emInfo = info;

            for (int i = 0; i < fieldsCount; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = 50;

                if (i == 0)
                    FillRow("Номер", emInfo.userName);
                if (i == 1)
                    FillRow("Подразделение", emInfo.department);
                if (i == 2)
                {
                    if (emInfo.status == "1")
                        FillRow("Статус", "Готов");
                    else
                        FillRow("Статус", "Не готов");
                }
                if (i == 3)
                    FillRow("Группа пользователя", emInfo.userGroup);
                if (i == 4)
                    FillRow("Долгота", emInfo.longitude);
                if (i == 5)
                    FillRow("Широта", emInfo.latitude);
                if (i == 6)
                    FillRow("E-mail", emInfo.email);
            }

            if (messages.Count != 0)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = 50;

                    FillRow("Сообщение " + (i + 1),"[" + messages[i].date + "]: " + messages[i].message);
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = dataGridView1.Width / 2;
            }
        }

        private void FillRow(string name, string value)
        {
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = name;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = value;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailedData_Resize(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = dataGridView1.Width / dataGridView1.ColumnCount;

            if (this.WindowState == FormWindowState.Maximized)
            {
                resizer.ResizeForm(this.Height, isMaximized, dataGridView1, this.Controls);
                lastFormSize = this.Height;
                isMaximized = true;
            }

            if (this.WindowState == FormWindowState.Normal && isMaximized)
            {
                resizer.ResizeForm(lastFormSize, isMaximized, dataGridView1, this.Controls);
                lastFormSize = this.Height;
                isMaximized = false;
            }
        }

        //private void listView_ItemActivate(object sender, EventArgs e)
        //{
        //    if (listView.FocusedItem != null)
        //    {
        //        ImageViewer imageViewer = new ImageViewer();

        //        Image image = imageList.Images[fileNames[listView.FocusedItem.Index]];
        //        imageViewer.SetImage(fileNames[listView.FocusedItem.Index]);
        //        imageViewer.Show();
        //    }
        //}

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string item = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                MessageBox.Show(item, name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //if (e.ColumnIndex == 0 && e.RowIndex > 6)
            //{
                //imageList.Images.Clear();
                //fileNames.Clear();
                //listView.Clear();

                //int index = e.RowIndex - 6;
                //string id = messages[index - 1].messageId;

                //string data = client.DownloadString("http://alfasoft.by/jdir-mchs-test/test-request/?message=" + id);

                //if (data != null)
                //{
                //    fileNames = JsonConvert.DeserializeObject<List<string>>(data);

                //    foreach (string fileName in fileNames)
                //        imageList.Images.Add(LoadImage(fileName));

                //    for (int i = 1; i < imageList.Images.Count; i++)
                //        listView.Items.Add("Image" + i, i);
                //}
                //else
                //    MessageBox.Show("Нет подключения.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ////fileNames.Add("http://edm.eatsleepedm.com/wp-content/uploads/2016/09/1473376075_maxresdefault-1000x600.jpg");
                ////fileNames.Add("http://7wallpapers.net/wp-content/uploads/20_Blueberry.jpg");

                ////foreach (string fileName in fileNames)
                ////    imageList.Images.Add(LoadImage(fileName));

                ////for (int i = 0; i < imageList.Images.Count; i++)
                ////    listView.Items.Add("Image" + i, i);
            //}
        }

        private Image LoadImage(string url)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();

            Bitmap bmp = new Bitmap(responseStream);

            responseStream.Dispose();

            return bmp;
        }

    }
}
