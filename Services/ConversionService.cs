

using System.ComponentModel;

namespace IdealCalories.Services
{
    public class ConversionService
    {
        public static double kgconvert_lbs(int kg)
        {
            return Convert.ToInt32(2.20462*kg);
        }

        public static double lbsconvert_kg(int lbs)
        {
            return Convert.ToInt32(lbs/2.20462);
        }

        public static double cmconvert_inches(int cm)
        {
            return Convert.ToInt32(cm*0.393701);
        }

        public static double ft_inchesconvert_cm(int ft, int inches)
        {
             inches += ft * 12;
             return Convert.ToInt32(inches/0.393701);
        }

        public static double inchesconvert_cm(int inches)
        {
            return Convert.ToInt32(inches/0.393701);
        }
    }
}