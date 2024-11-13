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

namespace EasyAssetManager.WPF.AssetComponent
{

    public class BaseModelAssetUI : BaseFileAssetUI<BaseModelAsset>
    {
    }

    /// <summary>
    /// Interaction logic for BaseModelAssetUC.xaml
    /// </summary>
    public partial class BaseModelAssetUC : BaseModelAssetUI
    {
        public BaseModelAssetUC()
        {
            InitializeComponent();
        }

        public override void RefreshUI()
        {
            base.RefreshUI();

            foreach(var kp in this.TargetAsset.TextureDict)
            {
                AddNewTextureAssetDefine(kp.Key, kp.Value);
            }
        }

        public override void UpdateData()
        {
            base.UpdateData();

            int count = this.TVTextureDict.Items.Count;
            TargetAsset.TextureDict.Clear();
            for(int i = 0; i < count; i++)
            {
                BaseTextureAssetUC TextureUI = ((this.TVTextureDict.Items[i] as BaseAssetUC).BindContent as BaseTextureAssetUC);
                TextureUI.UpdateData();
                this.TargetAsset.AddTexture(TextureUI.KeyName, TextureUI.TargetAsset);
            }
        }


        public virtual void BtnAddClick(object sender, EventArgs e)
        {
            BaseTextureAsset NewTexture = new BaseTextureAsset();
            NewTexture.Name = $"Texture_{this.TVTextureDict.Items.Count:D04}";
            AddNewTextureAssetDefine(NewTexture.Name, NewTexture);
        }


        /// <summary>
        /// 添加一个新贴图资产UI
        /// </summary>
        /// <param name="KeyName"></param>
        /// <param name="NewAsset"></param>
        public virtual void AddNewTextureAssetDefine(string KeyName,BaseAsset NewAsset)
        {
            BaseAssetUC item = new BaseAssetUC();
            item.SetBindAsset(NewAsset);
            item.KeyName = KeyName;
            item.IsExpanded = true;
            this.TVTextureDict.Items.Add(item);

            (item.BindContent as BaseTextureAssetUC).SetKeyEditiable(true);
        }
    }
}
