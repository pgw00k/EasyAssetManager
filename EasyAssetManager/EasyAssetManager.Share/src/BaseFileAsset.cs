using System;
using System.IO;

namespace EasyAssetManager
{
    public interface IBaseFileAsset
    {
        string FilePath { get; set; }

        string TurnToRelativePath(string RefPath);
    }

    /// <summary>
    /// 文件资产类，对应一个硬盘上存储的文件
    /// </summary>
    public class BaseFileAsset:BaseAsset, IBaseFileAsset
    {
        protected string _FilePath = string.Empty;
        public string FilePath { get => _FilePath; set => _FilePath = value; }

        /// <summary>
        /// 转换到一个相对路径
        /// </summary>
        /// <param name="RefPath"></param>
        /// <returns></returns>
        public virtual string TurnToRelativePath(string RefPath)
        {
            if (Path.IsPathRooted(this.FilePath))
            {
                return Path.GetRelativePath(RefPath, this._FilePath);
            }
            return _FilePath;
        }
    }
}
