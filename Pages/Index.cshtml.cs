using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdealCalories.Models;

namespace IdealCalories.Pages;
//Defines page handlers for requests, and encapsulates data properties and logic scoped to its Razor page.
public class IndexModel : PageModel
{

    [BindProperty]
    public BmrModel bmrModel{ get; set; } = default!;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        System.Console.WriteLine($"{bmrModel.Units}, {bmrModel.Heightft}, {bmrModel.Heightin}, {bmrModel.Heightcm}, {bmrModel.Weightlbs}, {bmrModel.Weightkg}, {bmrModel.Gender}, {bmrModel.Activity}");


        System.Console.WriteLine($"bmr: {bmrModel.bmrCalculate()}");
        return RedirectToPage("Index");
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
