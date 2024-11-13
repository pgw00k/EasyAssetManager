using EasyAssetManager.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager
{
    public interface IBaseModelTextureAsset<T> 
        where T : IBaseTextureAsset 
    {
        IDictionary<string, T> TextureDict { get;}
        T[] Textures { get; }
        void AddTexture(string key, T texture,bool forceAdd = false);
    }

    /// <summary>
    /// 模型资产
    /// </summary>
    public class BaseModelAsset : BaseFileAsset, IBaseModelTextureAsset<BaseTextureAsset>
    {
        protected Dictionary<string, BaseTextureAsset> _TextureDict = new Dictionary<string, BaseTextureAsset>();

        /// <summary>
        /// 和此模型相关的贴图资产（Dict）
        /// </summary>
        public virtual IDictionary<string, BaseTextureAsset> TextureDict { get => _TextureDict; }
        
        /// <summary>
        /// 和此模型相关的贴图资产
        /// </summary>
        public virtual BaseTextureAsset[] Textures
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
                    RemoveReference(_TextureDict[key]);
                    _TextureDict[key] = texture;
                    AddReference(texture);
                }        
            }else
            {
                _TextureDict.Add(key,texture);
                AddReference(texture);
            }
        }

        public override string TurnToRelativePath(string RefPath)
        {
            string relPath = base.TurnToRelativePath(RefPath);
            foreach(BaseTextureAsset texture in Textures) 
            {
                texture.FilePath = texture.TurnToRelativePath(RefPath);
            }

            FilePath = relPath;

            return relPath;
        }
    }
}
