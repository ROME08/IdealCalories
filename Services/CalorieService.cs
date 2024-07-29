using System.Security.Cryptography.X509Certificates;
using IdealCalories.Models;

namespace IdealCalories.Services;

public class CalorieService
{

    public List<CalorieModel> createGuideLine(BmrModel bmr)
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