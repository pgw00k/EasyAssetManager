using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager 
{ 
    public interface IBaseAsset
    {
    }

    /// <summary>
    /// 基础资产类
    /// </summary>
    public class BaseAsset:BaseObject,IBaseAsset,IReference<BaseAsset>
    {
        protected Dictionary<string,BaseAsset> _ReferenceDict = new Dictionary<string,BaseAsset>();
        public IList<BaseAsset> References
        {
            get { return _ReferenceDict.Values.ToList(); }
        }


        public virtual void AddReference(BaseAsset RefAsset)
        {
            _ReferenceDict.TryAdd(RefAsset.Name, RefAsset);
        }

        public virtual void RemoveReference(BaseAsset RefAsset)
        {
            _ReferenceDict.Remove(RefAsset.Name);
        }


        /// <summary>
        /// 重新计算引用资产
        /// <para>To do 暂时未确定要如何实现，先留空</para>
        /// </summary>
        public virtual void RecalcReference()
        {

        }

    }
}
