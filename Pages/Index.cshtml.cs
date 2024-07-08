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
    public BmrModel bmrModel{ get; set; } = default!;
    [BindProperty]
    public List<CalorieModel> calorieGuideLine {get; set;}
    public bool IsFormSubmitted { get; set; }
    private readonly ILogger<IndexModel> _logger;
    private readonly CalorieService _calorieService;

    public IndexModel(ILogger<IndexModel> logger, CalorieService calorieService)
    {
        _calorieService = calorieService;
        _logger = logger;
    }

    
    public void OnGet()
    {       
    }

    public void OnPost()
    {
        System.Console.WriteLine($"{bmrModel.Units}, {bmrModel.Heightft}, {bmrModel.Heightin}, {bmrModel.Heightcm}, {bmrModel.Weightlbs}, {bmrModel.Weightkg}, {bmrModel.Gender}, {bmrModel.ActivityOption}");    


        bmrModel.assignActivityFactor();
        bmrModel.BMR = _calorieService.calculateBMR(bmrModel);
        bmrModel.TDEE = _calorieService.calculateTDEE(bmrModel);
        calorieGuideLine = _calorieService.calorieGuideLine(bmrModel);    

        
        System.Console.WriteLine($"your BMR: {bmrModel.BMR} your TDEE: {bmrModel.TDEE}");

        // foreach(var calorieLine in calorieGuideLine)
        // {
        //     Console.WriteLine($"Line: Daily: {calorieLine.daily}, Weekly: {calorieLine.weekly}, Weight Loss: {calorieLine.weightLoss} ");
        // }    

        if(ModelState.IsValid)
        {
            IsFormSubmitted = true;
        }

    }

    public PartialViewResult PV()
    {
        return new PartialViewResult
        {
            ViewName = "partial" 
        };
    }

    // COMMENT: If you don't bind a model you can just you HTML name attribute.
    // public IActionResult OnPost(string units, int heightft, int heightin, int heightcm, int weight, string gender, string activity)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         foreach (var state in ModelState)
    //         {
    //             foreach (var error in state.Value.Errors)
    //             {
    //                 // Log or inspect the errors here
    //                 System.Diagnostics.Debug.WriteLine($"Key: {state.Key}, Error: {error.ErrorMessage}");
    //             }
    //         }
    //         return Page();
    //     }

    //     System.Console.WriteLine($"{units}, {heightft}, {heightin}, {heightcm}, {weight}, {gender}, {activity}");
    //     // ...

    //     return RedirectToPage("Index");
    // }
   
}
