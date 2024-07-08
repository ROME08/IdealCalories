using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using IdealCalories.Services;


namespace IdealCalories.Models;

public class BmrModel
{

    [Required]
    public required string Units {get; set;}
    public int Heightft {get; set;} = 0;
    public int Heightin {get; set;} = 0;
    public int Heightcm {get; set;} = 0;
    [Required]
    public int Weightlbs {get; set;} = 0;
    [Required]
    public int Weightkg {get; set;} = 0;
    [Required]
    public int Age {get; set;} = 0;
    [Required]
    public required string Gender {get; set;}
    public int BMR {get; set;} = 0;
    public int TDEE {get; set;} = 0;
    public required int ActivityOption {get; set;}
    public double ActivityFactor {get; set;}

    public void assignActivityFactor()
    {
        switch(ActivityOption)
        {
            case 1: 
                ActivityFactor = 1.2;
            break;
            case 2: 
                ActivityFactor = 1.375;
            break;
            case 3:
                ActivityFactor = 1.55;
            break;
            case 4:
                ActivityFactor = 1.725;
            break;
            case 5:
                ActivityFactor = 1.9;
            break;
        }
    }

}