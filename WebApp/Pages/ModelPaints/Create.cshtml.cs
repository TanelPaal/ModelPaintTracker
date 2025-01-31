using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.ModelPaints;

public class CreateModel : BasePageModel
{
    private readonly IModelPaintService _modelPaintService;
    private readonly IModelService _modelService;
    private readonly IPaintService _paintService;

    [BindProperty]
    public ModelPaint ModelPaint { get; set; } = default!;
    public Model Model { get; set; } = default!;
    public SelectList? PaintList { get; set; }

    public CreateModel(
        ILogger<CreateModel> logger,
        IModelPaintService modelPaintService,
        IModelService modelService,
        IPaintService paintService) : base(logger)
    {
        _modelPaintService = modelPaintService;
        _modelService = modelService;
        _paintService = paintService;
    }

    public async Task<IActionResult> OnGetAsync(int modelId)
    {
        var model = await _modelService.GetByIdAsync(modelId);
        if (model == null)
        {
            return NotFound();
        }

        Model = model;
        ModelPaint = new ModelPaint { ModelID = modelId };
        
        // Get all paints not already associated with this model
        var existingPaints = await _modelPaintService.GetByModelIdAsync(modelId);
        var allPaints = await _paintService.GetAllWithDetailsAsync();
        
        var availablePaints = allPaints
            .Where(p => !existingPaints.Any(ep => ep.PaintID == p.PaintID))
            .Select(p => new 
            {
                p.PaintID,
                PaintName = $"{p.PaintName} ({p.Brand?.BrandName})"
            });
        
        PaintList = new SelectList(
            availablePaints,
            "PaintID",
            "PaintName"
        );

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("OnPostAsync called with ModelPaint: ModelID={ModelID}, PaintID={PaintID}", 
            ModelPaint.ModelID, ModelPaint.PaintID);

        if (!ModelState.IsValid)
        {
            var errors = string.Join("; ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            _logger.LogWarning("ModelState is invalid: {Errors}", errors);
            
            var model = await _modelService.GetByIdAsync(ModelPaint.ModelID);
            if (model == null)
            {
                return NotFound();
            }

            Model = model;
            
            // Repopulate the select list
            var existingPaints = await _modelPaintService.GetByModelIdAsync(ModelPaint.ModelID);
            var allPaints = await _paintService.GetAllWithDetailsAsync();
            var availablePaints = allPaints
                .Where(p => !existingPaints.Any(ep => ep.PaintID == p.PaintID))
                .Select(p => new 
                {
                    p.PaintID,
                    PaintName = $"{p.PaintName} ({p.Brand?.BrandName})"
                });
            
            PaintList = new SelectList(
                availablePaints,
                "PaintID",
                "PaintName"
            );
            
            return Page();
        }

        try
        {
            // Check if this paint is already linked to the model
            if (await _modelPaintService.ExistsAsync(ModelPaint.ModelID, ModelPaint.PaintID))
            {
                SetErrorMessage("This paint is already added to the model.");
                return RedirectToPage("./Index", new { modelId = ModelPaint.ModelID });
            }

            _logger.LogInformation("Creating ModelPaint: ModelID={ModelID}, PaintID={PaintID}", 
                ModelPaint.ModelID, ModelPaint.PaintID);
            
            await _modelPaintService.CreateAsync(ModelPaint);
            
            SetSuccessMessage("Paint added to model successfully!");
            return RedirectToPage("./Index", new { modelId = ModelPaint.ModelID });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding paint to model: ModelID={ModelID}, PaintID={PaintID}", 
                ModelPaint.ModelID, ModelPaint.PaintID);
            SetErrorMessage("Error adding paint to model. Please try again.");
            return RedirectToPage("./Index", new { modelId = ModelPaint.ModelID });
        }
    }
} 