using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyAssetManager.Setting;
using static System.Net.Mime.MediaTypeNames;

namespace EasyAssetManager
{
    public interface IBaseMaterialAsset<Tex>
        where Tex:IBaseTextureAsset
    {
        public IBaseMaterialTextureSetting<Tex>[] TextureSettings { get; set; }
    }

    /// <summary>
    /// 材质资产
    /// </summary>
    public class BaseMaterialAsset:BaseAsset, IBaseMaterialAsset<BaseTextureAsset>
    {
        protected BaseMaterialTextureSetting[] _TextureSettings;
        public IBaseMaterialTextureSetting<BaseTextureAsset>[] TextureSettings { get => _TextureSettings; set => _TextureSettings = (BaseMaterialTextureSetting[])value; }
    }
}
