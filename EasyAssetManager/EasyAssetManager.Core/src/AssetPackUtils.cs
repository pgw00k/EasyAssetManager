using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EasyAssetManager
{
    /// <summary>
    /// 读取定义文件
    /// </summary>
    public class AssetPackUtils
    {
        public static JsonSerializerSettings ToJsonSetting = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new IgnorePropertiesResolver()
            {
                RegisterIgnoreProperty = new Dictionary<Type, IEnumerable<string>>()
                {
                    {typeof(BaseModelAsset),new string[]{ "Textures"} },
                }
            },
        };

        public static JsonSerializerSettings FromJsonSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter> { new BaseObjectTypeNameConverter() },
        };

        public static AssetPackInfo ReadFromFile(string FileFullPath)
        {
            string raw = File.ReadAllText(FileFullPath);
            AssetPackInfo Info = JsonConvert.DeserializeObject<AssetPackInfo>(raw, FromJsonSetting);
            return Info;
        }

        public static bool WriteToFile(string FileFullPath,AssetPackInfo Info)
        {
            // 将对象转换为 JSON 字符串，并应用设置
            string json = JsonConvert.SerializeObject(Info, ToJsonSetting);
            File.WriteAllText(FileFullPath, json);

            return true;
        }
    }
}
