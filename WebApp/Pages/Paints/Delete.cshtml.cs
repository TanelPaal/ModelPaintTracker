using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.Paints;

public class DeleteModel : BasePageModel
{
    private readonly IPaintService _paintService;

    [BindProperty]
    public Paint Paint { get; set; } = default!;

    public DeleteModel(
        ILogger<DeleteModel> logger,
        IPaintService paintService) : base(logger)
    {
        _paintService = paintService;
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
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        try
        {
            await _paintService.DeleteAsync(id.Value);
            SetSuccessMessage("Paint deleted successfully!");
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting paint");
            SetErrorMessage("Error deleting paint. Please try again.");
            return Page();
        }
    }
} 