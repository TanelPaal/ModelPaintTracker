using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.ModelPaints;

public class DeleteModel : BasePageModel
{
    private readonly IModelPaintService _modelPaintService;

    public DeleteModel(
        ILogger<DeleteModel> logger,
        IModelPaintService modelPaintService) : base(logger)
    {
        _modelPaintService = modelPaintService;
    }

    public async Task<IActionResult> OnPostAsync(int modelId, int paintId)
    {
        try
        {
            await _modelPaintService.DeleteAsync(modelId, paintId);
            SetSuccessMessage("Paint removed from model successfully!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing paint from model");
            SetErrorMessage("Error removing paint from model. Please try again.");
        }

        return RedirectToPage("./Index", new { modelId });
    }
} 