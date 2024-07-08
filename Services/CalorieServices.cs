using System.Security.Cryptography.X509Certificates;
using IdealCalories.Models;

namespace IdealCalories.Services;

public class CalorieService
{

    public int calculateBMR(BmrModel bmr)
    {

        double height;
        double weight;
        double retval = 0;
        if (bmr.Units == "us")
        {
            height = ConversionService.ft_inchesconvert_cm(bmr.Heightft, bmr.Heightin);
            weight = ConversionService.lbsconvert_kg(bmr.Weightlbs);
        }
        else
        {
            height = bmr.Heightcm;
            weight = bmr.Weightkg;
        }

        if (bmr.Gender == "male")
        {
            retval += 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * bmr.Age);
        }
        else
        {
            retval += 447.593 + (9.247 * weight) + (3.098 * height) - (4.33 * bmr.Age);
        }
        
        
        return Convert.ToInt32(retval);        
    }

    public int calculateTDEE(BmrModel bmr)
    {
        double retval = calculateBMR(bmr) * bmr.ActivityFactor;

        return Convert.ToInt32(retval);
    }

    public List<CalorieModel> calorieGuideLine(BmrModel bmr)
    {
        int weekWeightMaintain = bmr.TDEE * 7;
        int weekWeightOne = (bmr.TDEE * 7) - 3500;
        int weekWeightTwo = (bmr.TDEE * 7) - 7000;

        List<CalorieModel> guide = new List<CalorieModel>();

        guide.Add(new CalorieModel("Maintain Your Weight", weekWeightMaintain, bmr.TDEE));
        guide.Add(new CalorieModel("Lose 1 Pound", weekWeightOne, bmr.TDEE - 500));
        guide.Add(new CalorieModel("Lose 2 Pounds", weekWeightTwo, bmr.TDEE - 1000));

        return guide;
    }

}