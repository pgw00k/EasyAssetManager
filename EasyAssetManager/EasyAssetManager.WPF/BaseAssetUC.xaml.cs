using EasyAssetManager.WPF.AssetComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for BaseAssetUC.xaml
    /// </summary>
    public partial class BaseAssetUC : TreeViewItem
    {
        public static string[] TypeKeys
        {
            get
            {
                return AssetDataFactory.TypeDictShort.Keys.ToArray();
            }
        }

        public BaseAssetUC()
        {
            InitializeComponent();
            InitCommon();
        }

        protected BaseAssetContentUC _BindContent;

        public virtual BaseAssetContentUC BindContent
        {
            get
            {
                return _BindContent;
            }
        }

        public virtual bool IsVaild
        {
            get
            {
                return BindContent != null && BindContent.BindAsset != null;
            }
        }

        public virtual string AssetName
        {
            get
            {
                if(IsVaild)
                {
                    return BindContent.BindAsset.Name;
                }

                return "None";
            }

            set
            {
                BindContent.BindAsset.Name = value;
            }
        }

        public virtual bool IsKeyCanEdit
        {
            get
            {
                return BindContent != null && BindContent.IsKeyCanEdit;
            }
        }

        /// <summary>
        /// 作为节点显示的名称
        /// </summary>
        public virtual string KeyName
        {
            get
            {
                if (BindContent != null)
                {
                    return BindContent.KeyName;
                }
                return AssetName;
            }

            set
            {
                if (BindContent != null)
                {
                    BindContent.KeyName = value;
                }    
            }
        }

        protected string _TypeNameShort;

        public virtual string TypeNameShort
        {
            get
            {
                return _TypeNameShort;
            }

            set
            {
                _TypeNameShort = value;
            }
        }

        public virtual void InitCommon()
        {
            this.DataContext = this;
            Refresh();
        }


        public virtual void Refresh()
        {
        }

        /// <summary>
        /// 设置绑定的资产
        /// </summary>
        /// <param name="NewAsset"></param>
        public virtual void SetBindAsset(BaseAsset NewAsset)
        {
            if(_BindContent != null)
            {
                this.AssetContentNode.Children.Remove(_BindContent);
            }

            _TypeNameShort = NewAsset.GetType().Name;

            _BindContent = AssetDataFactory.CreateContentUI(NewAsset.TypeName);
            _BindContent.SetBindAsset(NewAsset);

            this.AssetContentNode.Children.Add(_BindContent);
            Refresh();
        }

        public virtual void AssetTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsVaild)
            {
                string SourceShortName = BindContent.BindAsset.GetType().Name;
                if (!SourceShortName.Equals(_TypeNameShort))
                {
                    Type NewType = AssetDataFactory.TypeDictShort[_TypeNameShort];
                    BaseAsset NewAsset = (BaseAsset)Activator.CreateInstance(NewType);
                    SetBindAsset(NewAsset);
                }
            }
        }

        public virtual void OnKeyNameChanged(object sender, TextChangedEventArgs e)
        {
        }

        public virtual void UpdateData()
        {
            if (_BindContent != null)
            {
                _BindContent.UpdateData();
            }
        }

        public virtual void DeleteSelf(object sender, EventArgs e)
        {
            (this.Parent as TreeView).Items.Remove(this);
        }
    }
}
