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

namespace EasyAssetManager.WPF
{
    /// <summary>
    /// Interaction logic for AssetList.xaml
    /// </summary>
    public partial class AssetList : UserControl
    {
        public AssetList()
        {
            InitializeComponent();
            InitUI();
        }

        public AssetPackInfo BindPack;

        public virtual void RefreshUI()
        {
            if(BindPack == null)
            {
                return;
            }

            this.TVAssets.Items.Clear();

            foreach(BaseAsset Asset in BindPack.Assets)
            {
                AddNewAssetDefine(Asset);
            }
        }

        public virtual void InitUI()
        {
            RefreshUI();
        }


        /// <summary>
        /// 从当前UI界面更新绑定类资产信息
        /// </summary>
        public virtual void UpdateData()
        {
            int Count = this.TVAssets.Items.Count;
            BaseAsset[] NewAssets = new BaseAsset[Count];

            for(int i = 0; i < Count; i++)
            {
                BaseAssetUC item = (BaseAssetUC)this.TVAssets.Items[i];
                item.UpdateData();
                NewAssets[i] = item.BindContent.BindAsset;
            }

            BindPack.Assets = NewAssets;
        }

        public virtual void BtnAddClick(object sender, EventArgs e)
        {
            BaseFileAsset NewFileAsset = new BaseFileAsset();
            NewFileAsset.Name = $"Asset_{this.TVAssets.Items.Count:D04}";
            AddNewAssetDefine(NewFileAsset);
        }

        /// <summary>
        /// 添加一个新资产UI
        /// </summary>
        /// <param name="NewAsset"></param>
        public virtual void AddNewAssetDefine(BaseAsset NewAsset)
        {
            BaseAssetUC item = new BaseAssetUC();
            item.SetBindAsset(NewAsset);
            item.IsExpanded = true;
            this.TVAssets.Items.Add(item);
        }
    }
}
