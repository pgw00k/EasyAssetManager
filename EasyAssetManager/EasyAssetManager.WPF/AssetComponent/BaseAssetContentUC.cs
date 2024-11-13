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
    public class BaseAssetContentUC : UserControl
    {
        public  BaseAsset BindAsset;

        public virtual string KeyName
        {
            get
            {
                return BindAsset.Name;
            }

            set
            {
                BindAsset.Name = value;
            }
        }

        protected bool _IsKeyCanEdit = false;

        public virtual bool IsKeyCanEdit
        {
            get
            {
                return _IsKeyCanEdit;
            }
        }

        public virtual void SetBindAsset(BaseAsset NewAsset)
        {
            BindAsset = NewAsset;
            RefreshUI();
        }

        /// <summary>
        /// 根据绑定的数据对象刷新UI
        /// </summary>
        public virtual void RefreshUI()
        {
        }

        /// <summary>
        /// 根据UI刷新绑定的数据对象
        /// </summary>
        public virtual void UpdateData()
        {

        }
    }

    public class AssetContentUC<T> : BaseAssetContentUC
        where T : BaseAsset
    {
        public virtual T TargetAsset
        {
            get
            {
                return (T)BindAsset;
            }
            set
            {
                BindAsset = value;
            }
        }
    }
}
