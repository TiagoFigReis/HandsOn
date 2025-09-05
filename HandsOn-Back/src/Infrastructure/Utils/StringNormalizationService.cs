using System.Globalization;
using System.Text;

namespace Infrastructure.Utils
{
    public class StringNormalizationService
    {
        public static string? NormalizeString(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string normalized = input.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);

                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString().ToLowerInvariant();
        }
    }
}