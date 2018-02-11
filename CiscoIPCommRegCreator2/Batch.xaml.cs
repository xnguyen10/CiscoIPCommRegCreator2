using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace CiscoIPCommRegCreator2
{
    /// <summary>
    /// Interaction logic for Batch.xaml
    /// </summary>
    public partial class Batch : Window
    {
        public Batch()
        {
            InitializeComponent();
        }

        string xlsxName;
        string folderName;
        Registry reg;
        private void btnRunBatch_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Clear();
            
            if (!string.IsNullOrWhiteSpace(txtFile.Text) && !string.IsNullOrWhiteSpace(txtFolder.Text))
            {
               ImportExcel();
            }
            else
            {
                txtResults.Text = "Error.  Please select file and folder." + Environment.NewLine;
            }
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            txtFile.Text = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "XLSX files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
                xlsxName = txtFile.Text;
            }      
        }

        private void btnSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            txtFolder.Text = "";

            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtFolder.Text = dialog.SelectedPath;
                folderName = txtFolder.Text;
            }
        }

        private void ImportExcel()
        {
            try
            {
                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"d:\joe.xlsx");
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(xlsxName);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                string[] value = new string[3];

               
                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        //write the value to the temp array to send to AddCreateReg function
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            txtResults.Text += (xlRange.Cells[i, j].Value2.ToString() + "\t");
                        }

                        value[j] = xlRange.Cells[i, j].Value2.ToString();
                    }
                    txtResults.Text += ("\r\n");
                    //MessageBox.Show(value[2].ToString());
                    //Launch func with 2 strings, user & phone and repeat
                    AddCreateReg(value[1], value[2]);
                }
                

                //Cleanup Microsoft.Office.Interop.Excel and close Excel
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkbook);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorksheet);
                xlApp.Quit();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Error, missing or corrupt file.");
            }
        }

        private void AddCreateReg(string name, string number)
        {
            string HostName = "SEP00" + number;

            //** Create new Object Registry Class **//
            reg = new Registry(HostName);

            string strRegText = reg.ToString();

            string regFile = folderName + "\\" + name + ".reg";

            // This text is added only once to the file.
            if (!File.Exists(regFile))
            {
                // Create a file to write to.
                File.WriteAllText(regFile, strRegText);
            }
        }
    }
}
