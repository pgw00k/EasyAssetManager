using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EasyAssetManager
{
    public class IgnorePropertiesResolver : DefaultContractResolver
    {
        public IgnorePropertiesResolver() { }
        public IgnorePropertiesResolver(Dictionary<Type, IEnumerable<string>> Dict)
            :this()
        {
            RegisterIgnoreProperty = Dict;
        }

        public bool IsCheckSubClass = true;

        public Dictionary<Type, IEnumerable<string>> RegisterIgnoreProperty = new Dictionary<Type, IEnumerable<string>>();

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            // 创建属性列表，过滤掉不需要的属性
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            if(IsCheckSubClass)
            {
                foreach (var key in RegisterIgnoreProperty.Keys)
                {
                    if (key.Equals(type) || type.IsSubclassOf(key))
                    {
                        var values = RegisterIgnoreProperty[key];
                        properties = properties.Where(p => !values.Contains(p.PropertyName)).ToList();
                    }
                }
            }
            else
            {
                if (RegisterIgnoreProperty.TryGetValue(type, out IEnumerable<string> values))
                {
                    properties = properties.Where(p => !values.Contains(p.PropertyName)).ToList();
                }
            }

            return properties;
        }
    }
}
