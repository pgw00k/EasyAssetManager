using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager
{
    /// <summary>
    /// 贴图的色彩空间
    /// </summary>
    public enum ColorSpace
    {
        SRGB = 0,
        LINER = 1,
        GAMMA = 2,
    }

    public interface IBaseTextureAsset
    {
        public ColorSpace ColorSpace { get; set; }
    }

    /// <summary>
    /// 贴图资产，对应一个本地贴图文件
    /// </summary>
    public class BaseTextureAsset : BaseFileAsset, IBaseTextureAsset
    {
        protected ColorSpace _ColorSpace = ColorSpace.SRGB;

        /// <summary>
        /// 此资产对应的颜色空间，默认为SRGB
        /// </summary>
        public ColorSpace ColorSpace { get => _ColorSpace; set => _ColorSpace = value; }
    }
}
