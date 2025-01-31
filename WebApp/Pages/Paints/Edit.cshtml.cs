using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.Paints;

public class EditModel : BasePageModel
{
    private readonly IPaintService _paintService;
    private readonly IBrandService _brandService;
    private readonly IPaintTypeService _paintTypeService;

    [BindProperty]
    public Paint Paint { get; set; } = default!;
    public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();
    public IEnumerable<PaintType> PaintTypes { get; set; } = new List<PaintType>();

    public EditModel(
        ILogger<EditModel> logger,
        IPaintService paintService,
        IBrandService brandService,
        IPaintTypeService paintTypeService) : base(logger)
    {
        _paintService = paintService;
        _brandService = brandService;
        _paintTypeService = paintTypeService;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paint = await _paintService.GetByIdAsync(id.Value);
        if (paint == null)
        {
            return NotFound();
        }

        Paint = paint;
        Brands = await _brandService.GetAllAsync();
        PaintTypes = await _paintTypeService.GetAllAsync();
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Brands = await _brandService.GetAllAsync();
            PaintTypes = await _paintTypeService.GetAllAsync();
            return Page();
        }

        try
        {
            await _paintService.UpdateAsync(Paint);
            SetSuccessMessage("Paint updated successfully!");
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating paint");
            SetErrorMessage("Error updating paint. Please try again.");
            Brands = await _brandService.GetAllAsync();
            PaintTypes = await _paintTypeService.GetAllAsync();
            return Page();
        }
    }
} 