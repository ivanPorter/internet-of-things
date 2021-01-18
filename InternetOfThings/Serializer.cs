namespace InternetOfThings
{
    static class Serializer
    {
        internal static string SerializePayLoad(Payload payload)
        {
            return System.Text.Json.JsonSerializer.Serialize(payload);
        }
    }
}
