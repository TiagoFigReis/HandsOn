namespace Core.Enums
{
    public enum NutrientHeader
    {
        N,
        P,
        K,
        Ca,
        Mg,
        S,
        Zn,
        B,
        Cu,
        Mn,
        Fe,
        NP,
        NK,
        NS,
        NB,
        NCu,
        PMg,
        PZn,
        KCa,
        KMg,
        KMn,
        CaMg,
        CaMn,
        FeMn,
        PhH2O,
        AlSaturation,
        PotentialAcidity,
        OrganicMatter,
        SumBases,
        CTCpH7,
        BasesSaturation,
    }

    public static class NutrientHeaderExtension
    {
        public static (string, string) ParseRelationHeader(this NutrientHeader nutrientheader)
        {
            return nutrientheader switch
            {
                NutrientHeader.NP => ("N", "P"),
                NutrientHeader.NK => ("N", "K"),
                NutrientHeader.NS => ("N", "S"),
                NutrientHeader.NB => ("N", "B"),
                NutrientHeader.NCu => ("N", "Cu"),
                NutrientHeader.PMg => ("P", "Mg"),
                NutrientHeader.PZn => ("P", "Zn"),
                NutrientHeader.KCa => ("K", "Ca"),
                NutrientHeader.KMg => ("K", "Mg"),
                NutrientHeader.KMn => ("K", "Mn"),
                NutrientHeader.CaMg => ("Ca", "Mg"),
                NutrientHeader.CaMn => ("Ca", "Mn"),
                NutrientHeader.FeMn => ("Fe", "Mn"),
                _ => ("unknown", "unknown")
            };
        }

        public static string ToFriendlyString(this NutrientHeader nutrientheader)
        {
            return nutrientheader switch
            {
                NutrientHeader.N => "N",
                NutrientHeader.P => "P",
                NutrientHeader.K => "K",
                NutrientHeader.Ca => "Ca",
                NutrientHeader.Mg => "Mg",
                NutrientHeader.S => "S",
                NutrientHeader.Zn => "Zn",
                NutrientHeader.B => "B",
                NutrientHeader.Cu => "Cu",
                NutrientHeader.Mn => "Mn",
                NutrientHeader.Fe => "Fe",
                NutrientHeader.NP => "NP",
                NutrientHeader.NK => "NK",
                NutrientHeader.NS => "NS",
                NutrientHeader.NB => "NB",
                NutrientHeader.NCu => "NCu",
                NutrientHeader.PMg => "PMg",
                NutrientHeader.PZn => "PZn",
                NutrientHeader.KCa => "KCa",
                NutrientHeader.KMg => "KMg",
                NutrientHeader.KMn => "KMn",
                NutrientHeader.CaMg => "CaMg",
                NutrientHeader.CaMn => "CaMn",
                NutrientHeader.FeMn => "FeMn",
                NutrientHeader.AlSaturation => "Saturação por Al",
                NutrientHeader.BasesSaturation => "Saturação por Bases",
                NutrientHeader.CTCpH7 => "CTC pH 7.0",
                NutrientHeader.PotentialAcidity => "Acidez Potencial",
                NutrientHeader.OrganicMatter => "Matéria Orgânica",
                NutrientHeader.SumBases => "Soma de bases",
                NutrientHeader.PhH2O => "pH H2O",
                _ => "Unknown"
            };
        }

        public static NutrientHeader ToHeader(this string nutrientheader)
        {
            return nutrientheader switch
            {
                "N" => NutrientHeader.N,
                "P" => NutrientHeader.P,
                "K" => NutrientHeader.K,
                "Ca" => NutrientHeader.Ca,
                "Mg" => NutrientHeader.Mg,
                "S" => NutrientHeader.S,
                "Zn" => NutrientHeader.Zn,
                "B" => NutrientHeader.B,
                "Cu" => NutrientHeader.Cu,
                "Mn" => NutrientHeader.Mn,
                "Fe" => NutrientHeader.Fe,
                "NP" => NutrientHeader.NP,
                "NK" => NutrientHeader.NK,
                "NS" => NutrientHeader.NS,
                "NB" => NutrientHeader.NB,
                "NCu" => NutrientHeader.NCu,
                "PMg" => NutrientHeader.PMg,
                "PZn" => NutrientHeader.PZn,
                "KCa" => NutrientHeader.KCa,
                "KMg" => NutrientHeader.KMg,
                "KMn" => NutrientHeader.KMn,
                "CaMg" => NutrientHeader.CaMg,
                "CaMn" => NutrientHeader.CaMn,
                "FeMn" => NutrientHeader.FeMn,
                "Saturação por Al" => NutrientHeader.AlSaturation,
                "Saturação por Bases" => NutrientHeader.BasesSaturation,
                "CTC pH 7.0" => NutrientHeader.CTCpH7,
                "Acidez Potencial" => NutrientHeader.PotentialAcidity,
                "Matéria Orgânica" => NutrientHeader.OrganicMatter,
                "Soma de bases" => NutrientHeader.SumBases,
                _ => NutrientHeader.N
            };
        }

        public static NutrientHeader[] GetValues()
        {
            return [
                NutrientHeader.N,
                NutrientHeader.P,
                NutrientHeader.K,
                NutrientHeader.Ca,
                NutrientHeader.Mg,
                NutrientHeader.S,
                NutrientHeader.Zn,
                NutrientHeader.B,
                NutrientHeader.Cu,
                NutrientHeader.Mn,
                NutrientHeader.Fe,
                NutrientHeader.NP,
                NutrientHeader.NK,
                NutrientHeader.NS,
                NutrientHeader.NB,
                NutrientHeader.NCu,
                NutrientHeader.PMg,
                NutrientHeader.PZn,
                NutrientHeader.KCa,
                NutrientHeader.KMg,
                NutrientHeader.KMn,
                NutrientHeader.CaMg,
                NutrientHeader.CaMn,
                NutrientHeader.FeMn,
                NutrientHeader.PhH2O,
                NutrientHeader.AlSaturation,
                NutrientHeader.BasesSaturation,
                NutrientHeader.CTCpH7,
                NutrientHeader.PotentialAcidity,
                NutrientHeader.OrganicMatter,
                NutrientHeader.SumBases,
            ];
        }
    }
}