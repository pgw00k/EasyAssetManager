using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EasyAssetManager
{
    /// <summary>
    /// 读取定义文件
    /// </summary>
    public class AssetPackUtils
    {
        public static AssetPackInfo ReadFromFile(string FileFullPath)
        {
            return null;
        }

        public static bool WriteToFile(string FileFullPath,AssetPackInfo Info)
        {

            // 配置序列化设置
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            // 将对象转换为 JSON 字符串，并应用设置
            string json = JsonConvert.SerializeObject(Info, settings);
            File.WriteAllText(FileFullPath, json);

            return true;
        }
    }
}
