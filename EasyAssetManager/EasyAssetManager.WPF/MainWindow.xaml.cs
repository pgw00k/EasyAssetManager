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
        string TestFilePath = @"D:\Wings\Desktop\Test_EAMS.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnRefreshClick(object sender, RoutedEventArgs e)
        {

            AssetPackInfo Info = AssetPackUtils.ReadFromFile(TestFilePath);
            this.Assets.BindPack = Info;
            this.Assets.RefreshUI();

        }

        public void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            this.Assets.UpdateData();
            AssetPackInfo Info = this.Assets.BindPack;
            AssetPackUtils.WriteToFile(TestFilePath, Info);
        }

        public void BtnRecreatehClick(object sender, RoutedEventArgs e)
        {
            BaseTextureAsset Texture1 = new BaseTextureAsset();
            Texture1.Name = "Texture1";
            Texture1.FilePath = "Texture1.png";

            BaseTextureAsset Texture2 = new BaseTextureAsset();
            Texture2.Name = "Texture2";
            Texture2.FilePath = "T_Test_Noraml.png";
            Texture2.ColorSpace = ColorSpace.LINER;

            BaseTextureAsset Texture3 = new BaseTextureAsset();
            Texture3.Name = "MaskTexture";
            Texture3.FilePath = "M_Test_Mask.png";
            Texture3.ColorSpace = ColorSpace.GAMMA;

            BaseModelAsset Model = new BaseModelAsset();
            Model.AddTexture("BaseColor", Texture1);
            Model.AddTexture("Normal", Texture2);
            Model.AddTexture("Mask", Texture3);
            Model.FilePath = "Test.fbx";
            Model.Name = "Test";

            BaseModelAsset Model2 = new BaseModelAsset();
            Model2.AddTexture("BaseColor", Texture1);
            Model2.AddTexture("Normal", Texture2);
            Model2.FilePath = "Test2.fbx";
            Model2.Name = "Test2";

            BaseAsset[] Assets = new BaseAsset[] {
                Model,
                Model2
            };
            AssetPackInfo Info = new AssetPackInfo()
            {
                Assets = Assets,
            };

            AssetPackUtils.WriteToFile(TestFilePath, Info);
        }
    }
}