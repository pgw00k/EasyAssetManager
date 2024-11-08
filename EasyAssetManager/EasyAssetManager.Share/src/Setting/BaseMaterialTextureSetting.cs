using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager.Setting
{
    public interface IBaseMaterialTextureSetting<T> : IBaseMaterialSetting<T>
        where T : IBaseTextureAsset
    {

    }
    public class BaseMaterialTextureSetting : IBaseMaterialTextureSetting<BaseTextureAsset>
    {
        protected string _PropertyName;
        protected BaseTextureAsset _PropertyValue;
        public string PropertyName { get => _PropertyName; set => _PropertyName = value; }
        public BaseTextureAsset PropertyValue { get => _PropertyValue; set => _PropertyValue = value; }
    }
}
