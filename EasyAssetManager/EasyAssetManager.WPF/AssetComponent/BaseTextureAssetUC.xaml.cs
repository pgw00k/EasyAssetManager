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

    public class BaseTextureAssetUI : BaseFileAssetUI<BaseTextureAsset>
    {
    }

    /// <summary>
    /// Interaction logic for BaseTextureAssetUC.xaml
    /// </summary>
    public partial class BaseTextureAssetUC : BaseTextureAssetUI
    {
        public BaseTextureAssetUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        protected string _KeyName;

        public override string KeyName { get => _KeyName; set => _KeyName = value; }

        public virtual void SetKeyEditiable(bool IsEdit = true)
        {
            _IsKeyCanEdit = IsEdit;
        }

        public virtual ColorSpace TextureColorSpace
        {
            get
            {
                if(TargetAsset != null)
                {
                    return TargetAsset.ColorSpace;
                }
                return ColorSpace.SRGB;
            }

            set
            {
                if (TargetAsset != null)
                {
                    TargetAsset.ColorSpace = value;
                }
            }
        }

        
    }
}
