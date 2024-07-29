
using IdealCalories.Models;

namespace IdealCalories.Services;

public class BMIService
{

    public double calculateBMI(double height, int weight)
    {
        double retval;


        retval = weight / (height * height);

        return System.Math.Round(retval, 2);
    }


}