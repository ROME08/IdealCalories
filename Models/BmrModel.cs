using System.ComponentModel.DataAnnotations;
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
    public required int Activity {get; set;}

    public double bmrCalculate()
    {
        double bmr = 0;
        double height;
        double weight;
        if(Units == "us")
        {
            height = ConversionService.ft_inchesconvert_cm(Heightft, Heightin);
            weight = ConversionService.lbsconvert_kg(Weightlbs);  
        }
        else
        {
            height = Heightcm;
            weight = Weightkg;
        }

        if(Gender == "male")
        {
            bmr += 88.362 + (13.397*weight) + (4.799*height) - (5.677*Age);
        }else
        {
            bmr += 447.593 + (9.247*weight) + (3.098*height) - (4.33*Age);
        }
        
        switch(Activity)
        {
            case 1: 
                bmr *= 1.2;
            break;
            case 2:
                bmr *= 1.375;
            break;
            case 3:
                bmr *= 1.55;
            break;
            case 4:
                bmr *= 1.725;
            break;
            case 5:
                bmr *= 1.9;
            break;
        }

        return bmr;
    }

}