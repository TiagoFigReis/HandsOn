namespace Core.Enums
{
    public enum NutrientTableDivision
    {
        Annual,     //Anual
        Semiannual, //Semestral
        Quarterly,  //Trimestral
        Bimonthly   //Bimestral
    }

    public static class NutrientTableDivisionExtension
    {
        public static int GetMonthIndex(this string month, NutrientTableDivision division)
        {
            var monthNames = new[]
            {
                "janeiro", "fevereiro", "marco", "abril",
                "maio", "junho", "julho", "agosto",
                "setembro", "outubro", "novembro", "dezembro"
            };

            int monthNumber = Array.FindIndex(monthNames, m => m == month);
            if (monthNumber == -1)
                return -1;

            int monthsPerPeriod = division switch
            {
                NutrientTableDivision.Bimonthly => 2,
                NutrientTableDivision.Quarterly => 3,
                NutrientTableDivision.Semiannual => 6,
                _ => 12
            };

            return monthNumber / monthsPerPeriod;
        }

        public static string ToFriendlyString(this NutrientTableDivision division)
        {
            return division switch
            {
                NutrientTableDivision.Bimonthly => "Bimestral",
                NutrientTableDivision.Quarterly => "Trimestral",
                NutrientTableDivision.Semiannual => "Semestral",
                NutrientTableDivision.Annual => "Anual",
                _ => "Anual"
            };
        }

        public static NutrientTableDivision ToDivision(this string division)
        {
            return division switch
            {
                "Bimestral" => NutrientTableDivision.Bimonthly,
                "Trimestral" => NutrientTableDivision.Quarterly,
                "Semestral" => NutrientTableDivision.Semiannual,
                "Anual" => NutrientTableDivision.Annual,
                _ => NutrientTableDivision.Annual
            };
        }

        public static NutrientTableDivision[] GetValues()
        {
            return new[]
            {
                NutrientTableDivision.Bimonthly,
                NutrientTableDivision.Quarterly,
                NutrientTableDivision.Semiannual,
                NutrientTableDivision.Annual
            };
        }
    }
}