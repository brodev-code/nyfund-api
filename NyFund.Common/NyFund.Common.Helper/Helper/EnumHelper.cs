using NyFund.Common.Dto.Lookup;
using System.ComponentModel;

namespace NyFund.Common.Helper.Helper
{
    public static class EnumHelper
    {
        public static string[] GetDescriptions<T>() where T : Enum
        {
            var attributes = new List<DescriptionAttribute>();

            foreach (var attribute in typeof(T).GetMembers().SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>()))
            {
                attributes.Add(attribute);
            }

            var descriptions = attributes.Select(x => x.Description).ToArray();

            return descriptions;
        }

        public static List<LookupBaseResponse> ToLookupDto<T>() where T : Enum
        {
            var data = new List<LookupBaseResponse>();

            var enums = GetDescriptions<T>();

            for (int i = 0; i < enums.Length; i++)
            {
                var item = enums[i];

                var record = new LookupBaseResponse
                {
                    Id = i,
                    Name = item.ToString()
                };

                data.Add(record);
            }

            return data;
        }

        public static string GetDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
