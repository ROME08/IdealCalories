using System.Security.Cryptography.X509Certificates;
using IdealCalories.Models;

namespace IdealCalories.Services;

public class BMRService
{

    public int calculateBMR(string gender, int weight, int height, int age)
    {
        double retval = 0;

        if (gender == "male")
        {
            retval += 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age);
        }
        else
        {
            retval += 447.593 + (9.247 * weight) + (3.098 * height) - (4.33 * age);
        }
        
        
        return Convert.ToInt32(retval);        
    }

    public int calculateTDEE(int bmr, double activityFactor)
    {
        double retval = bmr * activityFactor;

        return Convert.ToInt32(retval);
    }

    

}