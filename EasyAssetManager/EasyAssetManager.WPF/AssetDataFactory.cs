using EasyAssetManager.WPF.AssetComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager.WPF
{
    public class AssetDataFactory
    {
        protected static AssetDataFactory _Instance = null;

        public static AssetDataFactory Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new AssetDataFactory();
                }
                return _Instance;
            }
        }

        public static Dictionary<string, Type> TypeDictShort
        {
            get
            {
                return Instance._TypeDictShort;
            }
        }

        protected Dictionary<string, Type> _TypeDictShort = new Dictionary<string, Type>();
        protected Dictionary<string, Type> _TypeDictLong = new Dictionary<string, Type>();

        public AssetDataFactory()
        {
            RegisterUIType(typeof(BaseFileAsset), typeof(BaseDefaultFileAssetUC));
            RegisterUIType(typeof(BaseModelAsset),typeof(BaseModelAssetUC));
            RegisterUIType(typeof(BaseTextureAsset),typeof(BaseTextureAssetUC));
        }

        public virtual void RegisterUIType(Type ty,Type tyui)
        {
            _TypeDictShort.TryAdd(ty.Name, ty);
            _TypeDictLong.Add(ty.FullName, tyui);
        }

        public static BaseAssetContentUC CreateContentUI(string TypeName)
        {
            if(Instance._TypeDictLong.TryGetValue(TypeName,out Type UIType))
            {
                BaseAssetContentUC obj = (BaseAssetContentUC)Activator.CreateInstance(UIType);
                return obj;
            }

            return null;
        }
    }
}
