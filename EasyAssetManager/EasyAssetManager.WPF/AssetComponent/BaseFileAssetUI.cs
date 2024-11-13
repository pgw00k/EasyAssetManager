using EasyAssetManager.WPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyAssetManager.WPF.AssetComponent
{
    public class BaseFileAssetUI<T> : AssetContentUC<T>
        where T : BaseFileAsset
    {

        protected FileSelector _FSTargetFile;

        public override void EndInit()
        {
            base.EndInit();
            _FSTargetFile = (FileSelector)this.FindName("FSTargetFile");
        }

        public override void RefreshUI()
        {
            base.RefreshUI();
            if(_FSTargetFile != null)
            {
                this._FSTargetFile.TargetFilePath = this.TargetAsset.FilePath;
            }
        }

        public override void UpdateData()
        {
            base.UpdateData();
            if (_FSTargetFile != null)
            {
                this.TargetAsset.FilePath = this._FSTargetFile.TargetFilePath;
            }
        }
    }

}
