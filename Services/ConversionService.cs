

using System.ComponentModel;

namespace IdealCalories.Services
{
    public class ConversionService
    {
        public int lbsconvert_kg(int lbs)
        {
            return Convert.ToInt32(lbs / 2.20462);
        }

        public int ft_inchesconvert_cm(int ft, int inches)
        {
            inches += ft * 12;
            return Convert.ToInt32(inches / 0.393701);
        }

        public double cmconvert_m(int cm)
        {
            return (cm / 100.00);
        }


        //
        public int cmconvert_ft(int cm)
        {
            int ft = Convert.ToInt32(cm / 30.48);
            return (ft);
        }
        public int cmconvert_in(int cm)
        {
            int inches = Convert.ToInt32(cm / 2.54);
            inches = inches % 12;
            return (inches);
        }
        public int kgconvert_lbs(int kg)
        {
            int lbs = Convert.ToInt32(kg * 2.20462);
            return (lbs);
        }


    }
}