using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmergencyClient
{
    public partial class SaveForm : Form
    {
        Serializer serializer;
        List<string> savingHeaders;
        public SaveForm(List<EmergencyInfo> list)
        {
            serializer = new Serializer(list);
            savingHeaders = new List<string>();

            InitializeComponent();

            wordRadioButton.Checked = true;
        }

        private void FillSavingHeaders()
        {
            if (phoneCheckBox.Checked == true)
                savingHeaders.Add(phoneCheckBox.Text);
            if (statusCheckBox.Checked == true)
                savingHeaders.Add(statusCheckBox.Text);
            if (DepartmentCheckBox.Checked == true)
                savingHeaders.Add(DepartmentCheckBox.Text);
            if (userGroupCheckBox.Checked == true)
                savingHeaders.Add(userGroupCheckBox.Text);
            if (longitudeCheckBox.Checked == true)
                savingHeaders.Add(longitudeCheckBox.Text);
            if (latitudeCheckBox.Checked == true)
                savingHeaders.Add(latitudeCheckBox.Text);
            if (emailCheckBox.Checked == true)
                savingHeaders.Add(emailCheckBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FillSavingHeaders();

            if (savingHeaders != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();

                if (excelRadioButton.Checked)
                {
                    saveDialog.Filter = "Excel File (*.xlsx)|*.xlsx|Excel File (*.xls)|*.xls";
                    saveDialog.Title = "Сохранение в Excel";
                }
                else
                {
                    saveDialog.Filter = "Word File (*.docx)|*.docx|Word File (*.doc)|*.doc";
                    saveDialog.Title = "Сохранение в Word";
                }

                DialogResult result = saveDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (wordRadioButton.Checked)
                    {
                        serializer.WordSerialization(saveDialog.FileName, savingHeaders);
                    }

                    if (excelRadioButton.Checked)
                    {
                        serializer.ExcelSerialization(saveDialog.FileName, savingHeaders);
                    }
                }

                this.Close();
            }
            else
                MessageBox.Show("Для сохранения должно быть отмечено хотя бы одно поле...", 
                                "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
