using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.ModelPaints;

public class DeleteModel : BasePageModel
{
    private readonly IModelPaintService _modelPaintService;
    private readonly IModelService _modelService;
    private readonly IPaintService _paintService;

    [BindProperty]
    public int ModelId { get; set; }
    
    [BindProperty]
    public int PaintId { get; set; }
    
    public Model? Model { get; set; }
    public Paint? Paint { get; set; }
    public ModelPaint? ModelPaint { get; set; }

    public DeleteModel(
        ILogger<DeleteModel> logger,
        IModelPaintService modelPaintService,
        IModelService modelService,
        IPaintService paintService) : base(logger)
    {
        _modelPaintService = modelPaintService;
        _modelService = modelService;
        _paintService = paintService;
    }

    public async Task<IActionResult> OnGetAsync(int modelId, int paintId)
    {
        ModelId = modelId;
        PaintId = paintId;

        Model = await _modelService.GetByIdAsync(modelId);
        Paint = await _paintService.GetByIdAsync(paintId);
        ModelPaint = await _modelPaintService.GetByModelAndPaintIdAsync(modelId, paintId);

        if (Model == null || Paint == null || ModelPaint == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await _modelPaintService.DeleteAsync(ModelId, PaintId);
            SetSuccessMessage("Paint removed from model successfully!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing paint from model");
            SetErrorMessage("Error removing paint from model. Please try again.");
        }

        return RedirectToPage("./Index", new { modelId = ModelId });
    }
} 