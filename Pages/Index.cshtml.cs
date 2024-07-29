using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdealCalories.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using IdealCalories.Services;
using System.ComponentModel.DataAnnotations;

namespace IdealCalories.Pages;
//Defines page handlers for requests, and encapsulates data properties and logic scoped to its Razor page.
public class IndexModel : PageModel
{
    [BindProperty]
    public MeasurementsModel measurementsModel { get; set; } = new MeasurementsModel();
    public BmrModel bmrModel { get; set; }
    public bool IsFormSubmitted { get; set; }

    [BindProperty]
    public List<CalorieModel> calorieGuideLine { get; set; } = new List<CalorieModel>();
    [BindProperty]
    public double bmi { get; set; }
    private readonly ILogger<IndexModel> _logger;


    private readonly BMIService _bmiService;
    private readonly BMRService _bmrService;
    private readonly CalorieService _calorieService;
    private readonly ConversionService _conversionService;

    public IndexModel(ILogger<IndexModel> logger, BMIService bmiService, BMRService bmrService, CalorieService calorieService, ConversionService conversionService)
    {
        _bmiService = bmiService;
        _bmrService = bmrService;
        _calorieService = calorieService;
        _conversionService = conversionService;
        _logger = logger;
    }


    public void OnGet()
    {

    }

    public void OnPost()
    {
        if (measurementsModel.Units == "us")
        {
            measurementsModel.Heightcm = _conversionService.ft_inchesconvert_cm(measurementsModel.Heightft, measurementsModel.Heightin);
            measurementsModel.Weightkg = _conversionService.lbsconvert_kg(measurementsModel.Weightlbs);
        }
        else
        {
            measurementsModel.Heightft = _conversionService.cmconvert_ft(measurementsModel.Heightcm);
            measurementsModel.Heightin = _conversionService.cmconvert_in(measurementsModel.Heightcm);
            measurementsModel.Weightlbs = _conversionService.kgconvert_lbs(measurementsModel.Weightkg);
        }
        measurementsModel.HeightM = _conversionService.cmconvert_m(measurementsModel.Heightcm);
        measurementsModel.assignActivityFactor(measurementsModel.ActivityOption);

        bmrModel = new BmrModel(measurementsModel.Heightcm, measurementsModel.Weightkg, measurementsModel.Age, measurementsModel.Gender, measurementsModel.ActivityOption, measurementsModel.ActivityFactor);
        bmrModel.BMR = _bmrService.calculateBMR(bmrModel.Gender, bmrModel.Weight, bmrModel.Height, bmrModel.Age);
        bmrModel.TDEE = _bmrService.calculateTDEE(bmrModel.BMR, bmrModel.ActivityFactor);

        calorieGuideLine = _calorieService.createGuideLine(bmrModel);

        bmi = _bmiService.calculateBMI(measurementsModel.HeightM, measurementsModel.Weightkg);

        if (ModelState.IsValid)
        {
            IsFormSubmitted = true;
        }
    }

}
