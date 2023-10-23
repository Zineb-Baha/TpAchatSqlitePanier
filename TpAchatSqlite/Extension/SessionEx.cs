using Newtonsoft.Json;

namespace TpAchatSqlite.Extension
{
    public static class SessionEx
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            session.SetString(key, serializedValue);
        }

        public static T Get<T>(this ISession session, string key)
        {
            var serializedValue = session.GetString(key);
            return serializedValue == null ? default : JsonConvert.DeserializeObject<T>(serializedValue)!;

        }
    }
}

