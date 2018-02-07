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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;


namespace CiscoIPCommRegCreator2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtDeviceName.Text = "SEP00";
            txtUserName.Focus();
        }

        Registry reg;
        private void btnCreateReg_Click(object sender, RoutedEventArgs e)
        {
            string HostName = txtDeviceName.Text;
            reg = new Registry(HostName);

            SaveFile();
        }

        private void SaveFile()
        {
            //** Export Reg file//

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Reg File | *.reg";
            sfd.Title = "Save as Reg File";
            sfd.FileName = txtUserName.Text;

            //** Save As Dialog Box to location
            System.Windows.Forms.DialogResult result = sfd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string name = sfd.FileName;
                File.WriteAllText(name, reg.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
    
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDeviceName.Text = "SEP00";
            txtUserName.Text = "";
        }

        private void btnBatch_Click(object sender, RoutedEventArgs e)
        {
            Batch batch = new Batch();
            batch.ShowDialog();
        }
    }
}
