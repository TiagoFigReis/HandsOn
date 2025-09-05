namespace Core.Enums
{
    public enum Tipo
    {
        Solo,
        Foliar
    }

    public static class TipoExtension
    {
        public static string ToFriendlyString(this Tipo source)
        {
            return source switch
            {
                Tipo.Solo => "Solo",
                Tipo.Foliar => "Foliar",
                _ => throw new NotSupportedException()
            };
        }

        public static Tipo ToSource(this string source)
        {
            return source switch
            {
                "Solo" => Tipo.Solo,
                "Foliar" => Tipo.Foliar,
                _ => throw new NotSupportedException()
            };
        }

        public static Tipo[] GetValues()
        {
            return [Tipo.Solo, Tipo.Foliar];
        }
    }
}