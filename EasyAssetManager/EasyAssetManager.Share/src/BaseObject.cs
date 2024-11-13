using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager
{
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

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string TypeName
        {
            get { return this.GetType().FullName; }
        }
    }
}
