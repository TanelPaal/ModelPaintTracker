using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.Models;

public class CreateModel : BasePageModel
{
    private readonly IModelService _modelService;
    private readonly IFactionService _factionService;
    private readonly IStateService _stateService;

    [BindProperty]
    public Model Model { get; set; } = default!;
    public SelectList? FactionList { get; set; }
    public SelectList? StateList { get; set; }

    public CreateModel(
        ILogger<CreateModel> logger,
        IModelService modelService,
        IFactionService factionService,
        IStateService stateService) : base(logger)
    {
        _modelService = modelService;
        _factionService = factionService;
        _stateService = stateService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            var factions = await _factionService.GetAllAsync();
            var states = await _stateService.GetAllAsync();
        
            FactionList = new SelectList(factions, "FactionID", "FactionName");
            StateList = new SelectList(states, "StateID", "StateName");
        
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading create model page");
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
            Model.UserID = 1; // TODO: Replace with actual user ID from authentication
            await _modelService.CreateAsync(Model);
            SetSuccessMessage("Model created successfully!");
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating model");
            SetErrorMessage("Error creating model. Please try again.");
            
            var factions = await _factionService.GetAllAsync();
            var states = await _stateService.GetAllAsync();
        
            FactionList = new SelectList(factions, "FactionID", "FactionName");
            StateList = new SelectList(states, "StateID", "StateName");
            
            return Page();
        }
    }
} 