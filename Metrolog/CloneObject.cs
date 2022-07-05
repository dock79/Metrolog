using System.IO;
using System.Xml.Serialization;

namespace Metrolog
{
    public static class ObjectExtension
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }
}