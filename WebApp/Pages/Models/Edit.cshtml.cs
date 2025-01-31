using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Models;

public class EditModel : BasePageModel
{
    private readonly IModelService _modelService;
    private readonly IFactionService _factionService;
    private readonly IStateService _stateService;

    [BindProperty]
    public Model Model { get; set; } = default!;
    public IEnumerable<Faction> Factions { get; set; } = new List<Faction>();
    public IEnumerable<State> States { get; set; } = new List<State>();
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

        var model = await _modelService.GetByIdAsync(id.Value);
        if (model == null)
        {
            return NotFound();
        }

        Model = model;
        Factions = await _factionService.GetAllAsync();
        States = await _stateService.GetAllAsync();
        
        var factions = await _factionService.GetAllAsync();
        var states = await _stateService.GetAllAsync();
        
        FactionList = new SelectList(factions, "FactionID", "FactionName");
        StateList = new SelectList(states, "StateID", "StateName");
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Factions = await _factionService.GetAllAsync();
            States = await _stateService.GetAllAsync();
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
            _logger.LogError(ex, "Error updating model");
            SetErrorMessage("Error updating model. Please try again.");
            Factions = await _factionService.GetAllAsync();
            States = await _stateService.GetAllAsync();
            return Page();
        }
    }
} 