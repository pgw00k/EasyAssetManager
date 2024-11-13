using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager
{
    public interface IReference<T>
        where T:IBaseObject
    {
        /// <summary>
        /// 此对象引用的对象
        /// </summary>
        IList<T> References { get; }

        /// <summary>
        /// 添加一个资产引用
        /// </summary>
        /// <param name="NewReference"></param>
        void AddReference(T NewReference);

        /// <summary>
        /// 删除一个资产引用
        /// </summary>
        /// <param name="Reference"></param>
        void RemoveReference(T Reference);

        /// <summary>
        /// 重新计算关联资产
        /// </summary>
        void RecalcReference();
    }

    public interface IBaseObject
    {
        string Name { get; set; }
        string TypeName { get; }
    }

    /// <summary>
    /// 基础资产类
    /// </summary>
    public class BaseObject : IBaseObject
    {
        protected string _Name = string.Empty;

        /// <summary>
        /// 在资产定义中，应当保持唯一值，这是用以判断引用的关键标准
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string TypeName
        {
            get { return this.GetType().FullName; }
        }

        public BaseObject() {
            _Name = $"{GetType().Name}_{DateTime.UtcNow}";
        } 
    }
}
