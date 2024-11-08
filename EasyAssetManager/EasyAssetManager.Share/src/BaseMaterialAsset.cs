using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyAssetManager.Setting;

namespace EasyAssetManager
{
    public interface IBaseMaterialAsset
    {
        public IBaseMaterialTextureSetting<BaseTextureAsset>[] TextureSettings { get; set; }
        //public IBaseMaterialSetting<float>[] ScaleSettings { get; set; }
    }

    /// <summary>
    /// 材质资产
    /// </summary>
    public class BaseMaterialAsset:BaseAsset, IBaseMaterialAsset
    {
        protected BaseMaterialTextureSetting[] _TextureSettings;
        public IBaseMaterialTextureSetting<BaseTextureAsset>[] TextureSettings { get => _TextureSettings; set => _TextureSettings = (BaseMaterialTextureSetting[])value; }
    }
}
