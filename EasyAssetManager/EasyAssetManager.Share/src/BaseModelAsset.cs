using EasyAssetManager.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager
{
    public interface IBaseModelAsset<T> where T : IBaseTextureAsset 
    {
        IDictionary<string, T> TextureDict { get; set; }
        IBaseMaterialAsset[] MaterialSettings { get; set; }
        void AddTexture(string key, T texture,bool forceAdd = false);
    }

    /// <summary>
    /// 模型资产
    /// </summary>
    public class BaseModelAsset : BaseFileAsset, IBaseModelAsset<BaseTextureAsset>
    {
        protected Dictionary<string, BaseTextureAsset> _TextureDict = new Dictionary<string, BaseTextureAsset>();
        public BaseMaterialAsset[] _MaterialSettings;

        /// <summary>
        /// 和此模型相关的贴图资产（Dict）
        /// </summary>
        public IDictionary<string, BaseTextureAsset> TextureDict { get => _TextureDict; set => _TextureDict = (Dictionary<string, BaseTextureAsset>)value; }
        
        /// <summary>
        /// 和此模型相关的材质
        /// </summary>
        public IBaseMaterialAsset[] MaterialSettings { get => _MaterialSettings; set => _MaterialSettings = (BaseMaterialAsset[])value; }

        /// <summary>
        /// 和此模型相关的贴图资产
        /// </summary>
        public BaseTextureAsset[] Textures
        {
            get
            {
                return _TextureDict.Values.ToArray();
            }
        }

        /// <summary>
        /// 添加一张贴图资产到关联模型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="texture"></param>
        /// <param name="forceAdd"></param>
        /// <returns></returns>
        public virtual void AddTexture(string key, BaseTextureAsset texture, bool forceAdd = false)
        {
            if(_TextureDict.ContainsKey(key))
            {
                if(forceAdd)
                {
                    _TextureDict[key] = texture;
                }        
            }else
            {
                _TextureDict.Add(key,texture);
            }
        }
    }
}
