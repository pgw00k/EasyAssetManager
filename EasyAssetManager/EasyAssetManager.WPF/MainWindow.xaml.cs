using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EasyAssetManager;
using Newtonsoft.Json;

namespace EasyAssetManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            TargetFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Asset_EAMS.json");
            this.TextTargetFilePath.DataContext = this.FSTargetFile;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void BtnRefreshClick(object sender, RoutedEventArgs e)
        {
            ReloadFile();
        }

        public virtual void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            SaveFile();
            ReloadFile();
        }


        public virtual void BtnRecreatehClick(object sender, RoutedEventArgs e)
        {
            RecreateFile();
            ReloadFile();
        }

        public virtual void ReloadFile()
        {
            if (!File.Exists(TargetFilePath))
            {
                MessageBox.Show($"Not found {TargetFilePath}");
                return;
            }

            AssetPackInfo Info = AssetPackUtils.ReadFromFile(TargetFilePath);
            this.Assets.BindPack = Info;
            this.Assets.RefreshUI();
        }

        public virtual void SaveFile()
        {
            this.Assets.UpdateData();
            AssetPackInfo Info = this.Assets.BindPack;
            AssetPackUtils.WriteToFile(TargetFilePath, Info);
        }

        public virtual void RecreateFile()
        {
            AssetPackInfo Info = new AssetPackInfo();
            AssetPackUtils.WriteToFile(TargetFilePath, Info);
        }

        public string TargetFilePath
        {
            get
            {
                return this.FSTargetFile.TargetFilePath;
            }

            set
            {
                this.FSTargetFile.TargetFilePath = value;
            }
        }
    }
}