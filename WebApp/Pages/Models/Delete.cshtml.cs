using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.Models;

public class DeleteModel : BasePageModel
{
    private readonly IModelService _modelService;

    public Model Model { get; set; } = default!;

    public DeleteModel(
        ILogger<DeleteModel> logger,
        IModelService modelService) : base(logger)
    {
        _modelService = modelService;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniature = await _modelService.GetByIdAsync(id.Value);
        if (miniature == null)
        {
            return NotFound();
        }

        Model = miniature;
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
            await _modelService.DeleteAsync(id.Value);
            SetSuccessMessage("Model deleted successfully!");
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting model with ID: {Id}", id);
            SetErrorMessage("Error deleting model. Please try again.");
            return RedirectToPage("./Index");
        }
    }
} 