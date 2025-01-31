using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.ModelPaints;

public class IndexModel : BasePageModel
{
    private readonly IModelPaintService _modelPaintService;
    private readonly IModelService _modelService;
    private readonly IPaintService _paintService;

    public Model Model { get; set; } = default!;
    public IEnumerable<ModelPaint> ModelPaints { get; set; } = new List<ModelPaint>();
    public IEnumerable<Paint> AvailablePaints { get; set; } = new List<Paint>();

    public IndexModel(
        ILogger<IndexModel> logger,
        IModelPaintService modelPaintService,
        IModelService modelService,
        IPaintService paintService) : base(logger)
    {
        _modelPaintService = modelPaintService;
        _modelService = modelService;
        _paintService = paintService;
    }

    public async Task<IActionResult> OnGetAsync(int? modelId)
    {
        if (modelId == null)
        {
            return NotFound();
        }

        var model = await _modelService.GetByIdWithDetailsAsync(modelId.Value);
        if (model == null)
        {
            return NotFound();
        }

        Model = model;
        ModelPaints = await _modelPaintService.GetByModelIdWithDetailsAsync(modelId.Value);
        AvailablePaints = await _paintService.GetAllWithDetailsAsync();
        
        return Page();
    }
} 