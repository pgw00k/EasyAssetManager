using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager
{
    public interface IAssetPackInfo<T> where T : IBaseAsset
    {
        public T[] Assets { get; set; }
    }

    /// <summary>
    /// 资产包信息
    /// </summary>
    public class AssetPackInfo : IAssetPackInfo<BaseAsset>
    {
        protected BaseAsset[] _Assets;

        public BaseAsset[] Assets
        {
            get { return _Assets; }
            set { _Assets = value; }
        }
    }
}
