using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.Models;

public class EditModel : BasePageModel
{
    private readonly IModelService _modelService;
    private readonly IFactionService _factionService;
    private readonly IStateService _stateService;

    [BindProperty]
    public Model Model { get; set; } = default!;
    public SelectList? FactionList { get; set; }
    public SelectList? StateList { get; set; }

    public EditModel(
        ILogger<EditModel> logger,
        IModelService modelService,
        IFactionService factionService,
        IStateService stateService) : base(logger)
    {
        _modelService = modelService;
        _factionService = factionService;
        _stateService = stateService;
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

        try
        {
            Model = miniature;
            var factions = await _factionService.GetAllAsync();
            var states = await _stateService.GetAllAsync();
        
            FactionList = new SelectList(factions, "FactionID", "FactionName");
            StateList = new SelectList(states, "StateID", "StateName");
        
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading edit model page for ID: {Id}", id);
            SetErrorMessage("Error loading page. Please try again.");
            return RedirectToPage("./Index");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var factions = await _factionService.GetAllAsync();
            var states = await _stateService.GetAllAsync();
        
            FactionList = new SelectList(factions, "FactionID", "FactionName");
            StateList = new SelectList(states, "StateID", "StateName");
            
            return Page();
        }

        try
        {
            await _modelService.UpdateAsync(Model);
            SetSuccessMessage("Model updated successfully!");
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating model with ID: {Id}", Model.ModelID);
            SetErrorMessage("Error updating model. Please try again.");
            
            var factions = await _factionService.GetAllAsync();
            var states = await _stateService.GetAllAsync();
        
            FactionList = new SelectList(factions, "FactionID", "FactionName");
            StateList = new SelectList(states, "StateID", "StateName");
            
            return Page();
        }
    }
} 