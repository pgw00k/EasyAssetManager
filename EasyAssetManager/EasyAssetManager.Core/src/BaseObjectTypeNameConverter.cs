using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using EasyAssetManager.Setting;
using System.Text.Json.Nodes;
using System.Runtime.InteropServices.Marshalling;


namespace EasyAssetManager
{
    public class BaseObjectTypeNameConverter : JsonConverter
    {
        public string TypeHashKey = "TypeName";
        public Dictionary<string, Type> TypeDict = new Dictionary<string, Type>()
        {

        };

        public void RegisterClassType(Type type)
        {
            string id = type.FullName;
            if(!TypeDict.ContainsKey(id))
            {
                TypeDict.Add(id, type);
            }
        }

        public void RegisterBaseClassType()
        {
            RegisterClassType(typeof(BaseObject));

            RegisterClassType(typeof(BaseAsset));
            RegisterClassType(typeof(BaseFileAsset));
            RegisterClassType(typeof(BaseMaterialAsset));
            RegisterClassType(typeof(BaseModelAsset));
            RegisterClassType(typeof(BaseTextureAsset));
            RegisterClassType(typeof(BaseMaterialAsset));

            RegisterClassType(typeof(BaseSetting));
            RegisterClassType(typeof(BaseMaterialTextureSetting));
        }

        public BaseObjectTypeNameConverter() 
        {
            RegisterBaseClassType();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IBaseObject).IsAssignableFrom(objectType);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            /*
             * 未完成，仅可用状态，后续需要调整升级
             * 当前状态下可能存在性能问题
             */

            // 解析 JSON 对象
            JObject jsonObject = JObject.Load(reader);

            // 检查是否包含 TypeName 字段
            if (jsonObject.TryGetValue(TypeHashKey, StringComparison.OrdinalIgnoreCase, out JToken jtTypeId))
            {
                string typeName = jtTypeId.ToString();
                if (TypeDict.TryGetValue(typeName, out Type type))
                {
                    return JsonConvert.DeserializeObject(jsonObject.ToString(), type);
                }
            }
            return serializer.Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
