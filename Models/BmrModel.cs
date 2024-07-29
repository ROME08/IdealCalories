using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using IdealCalories.Services;


namespace IdealCalories.Models;

public class BmrModel
{    
    public int Height {get;set;}
    public int Weight {get; set;}
    public int Age {get; set;}
    public  string Gender {get; set;}
    public int BMR {get; set;} 
    public int TDEE {get; set;}
    public  int ActivityOption {get; set;}
    public double ActivityFactor {get; set;}
    
    public BmrModel(int height, int weight, int age, string gender, int activityOption, double activityFactor)
    {
        this.Height = height;
        this.Weight = weight;
        this.Age = age;
        this.Gender = gender;
        this.ActivityOption = activityOption;
        this.ActivityFactor = activityFactor;
    }

}