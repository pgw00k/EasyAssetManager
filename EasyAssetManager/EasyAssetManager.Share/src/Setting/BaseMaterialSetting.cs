using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAssetManager.Setting
{
    public interface IBaseMaterialSetting<T>
    {
        public string PropertyName { get; set; }
        public T PropertyValue { get; set; }
    }
    public class BaseMaterialSetting<T>:BaseSetting,IBaseMaterialSetting<T>
    {
        protected string _PropertyName;
        protected T _PropertyValue;

        public string PropertyName { get => _PropertyName; set => _PropertyName = value; }
        public T PropertyValue { get => _PropertyValue; set => _PropertyValue = value; }
    }
}
