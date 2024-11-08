using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager
{
    public interface IBaseFileAsset
    {
        public string FilePath { get; set; }
    }

    /// <summary>
    /// 文件资产类，对应一个硬盘上存储的文件
    /// </summary>
    public class BaseFileAsset:BaseAsset, IBaseFileAsset
    {
        protected string _FilePath = string.Empty;
        public string FilePath { get => _FilePath; set => _FilePath = value; }
    }
}
