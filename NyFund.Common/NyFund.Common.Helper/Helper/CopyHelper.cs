using Newtonsoft.Json;

namespace NyFund.Common.Helper.Helper
{
    public static class CopyHelper
    {
        public static T ObjectDeepCopy<T>(T obj)
        {
            var jsonObject = JsonConvert.SerializeObject(obj);
            var copyObject = JsonConvert.DeserializeObject<T>(jsonObject);
            return copyObject;
        }
    }
}
