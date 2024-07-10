using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using IdealCalories.Services;


namespace IdealCalories.Models;

public class BmrModel
{

    [Required]
    public  string Units {get; set;} = "us";
    public int Heightft {get; set;} = 5;
    public int Heightin {get; set;} = 7;
    public int Heightcm {get; set;} = 170;
    public int Weightlbs {get; set;} = 140;
    public int Weightkg {get; set;} = 64;
    public int Age {get; set;} = 25;
    public  string Gender {get; set;} = "male"; 
    public int BMR {get; set;} 
    public int TDEE {get; set;}
    public  int ActivityOption {get; set;} = 1;
    public double ActivityFactor {get; set;} = 1.2;


  
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