using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdealCalories.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using IdealCalories.Services;

namespace IdealCalories.Pages;
//Defines page handlers for requests, and encapsulates data properties and logic scoped to its Razor page.
public class IndexModel : PageModel
{
    [BindProperty]
    public BmrModel bmrModel{ get; set; } = new BmrModel();
    [BindProperty]
    public List<CalorieModel> calorieGuideLine {get; set;}
    public bool IsFormSubmitted { get; set; }
    private readonly ILogger<IndexModel> _logger;
    private readonly CalorieService _calorieService;


    public IndexModel(ILogger<IndexModel> logger, CalorieService calorieService)
    {
         calorieGuideLine =  new List<CalorieModel>();
        _calorieService = calorieService;
        _logger = logger;
    }

    
    public void OnGet()
    {       

    }

    public void OnPost()
    {
        bmrModel.assignActivityFactor();
        bmrModel.BMR = _calorieService.calculateBMR(bmrModel);
        bmrModel.TDEE = _calorieService.calculateTDEE(bmrModel);
        calorieGuideLine = _calorieService.calorieGuideLine(bmrModel);    
       
        if(ModelState.IsValid)
        {
            IsFormSubmitted = true;
        }
    }
   
}
