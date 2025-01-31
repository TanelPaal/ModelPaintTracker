using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Paints;

public class CreateModel : BasePageModel
{
    private readonly IPaintService _paintService;
    private readonly IBrandService _brandService;
    private readonly IPaintTypeService _paintTypeService;

    public CreateModel(
        ILogger<CreateModel> logger,
        IPaintService paintService,
        IBrandService brandService,
        IPaintTypeService paintTypeService) : base(logger)
    {
        _paintService = paintService;
        _brandService = brandService;
        _paintTypeService = paintTypeService;
    }

    [BindProperty]
    public Paint Paint { get; set; } = default!;
    
    public SelectList? BrandList { get; set; }
    public SelectList? PaintTypeList { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var brands = await _brandService.GetAllAsync();
        var paintTypes = await _paintTypeService.GetAllAsync();

        BrandList = new SelectList(brands, "BrandID", "BrandName");
        PaintTypeList = new SelectList(paintTypes, "PaintTypeID", "TypeName");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Repopulate the select lists if we return to the page due to validation errors
            var brands = await _brandService.GetAllAsync();
            var paintTypes = await _paintTypeService.GetAllAsync();
            BrandList = new SelectList(brands, "BrandID", "BrandName");
            PaintTypeList = new SelectList(paintTypes, "PaintTypeID", "TypeName");
            return Page();
        }

        try
        {
            await _paintService.CreateAsync(Paint);
            SetSuccessMessage("Paint created successfully!");
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating paint");
            SetErrorMessage("Error creating paint. Please try again.");
            var brands = await _brandService.GetAllAsync();
            var paintTypes = await _paintTypeService.GetAllAsync();
            BrandList = new SelectList(brands, "BrandID", "BrandName");
            PaintTypeList = new SelectList(paintTypes, "PaintTypeID", "TypeName");
            return Page();
        }
    }
} 