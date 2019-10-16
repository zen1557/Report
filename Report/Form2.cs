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
using Excel;
namespace Report
{
    public partial class Form2 : Form
    {
        DataSet result;
        public Form2()
        {
            InitializeComponent();
        }

        private void Combosheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = result.Tables[Combosheet.SelectedIndex];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() {Filter="Excel WorkBook|*.xls" })
            {
                if (dialog.ShowDialog()==DialogResult.OK)
                {
                    FileStream fs = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    result = reader.AsDataSet();
                    Combosheet.Items.Clear();
                    foreach (DataTable at in result.Tables)
                        Combosheet.Items.Add(at.TableName);
                    reader.Close();
                    

                }
            }       
                }
    }
}
