using System.ComponentModel.DataAnnotations;
using IdealCalories.Services;

namespace IdealCalories.Models;

public class CalorieModel
{
    public string? description {get;set;}
    public int weightLoss {get; set;}
    public int weekly {get; set;}
    public int daily {get; set;}

    public CalorieModel(string Description, int Weekly, int Daily)
    {
        this.description = Description;
        this.weekly = Weekly;
        this.daily = Daily;
    }

}