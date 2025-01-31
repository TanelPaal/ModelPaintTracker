using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.Models;

public class IndexModel : BasePageModel
{
    private readonly IModelService _modelService;
    private readonly IFactionService _factionService;
    private readonly IStateService _stateService;

    public IEnumerable<Model> Models { get; set; } = new List<Model>();
    public IEnumerable<Faction> Factions { get; set; } = new List<Faction>();
    public IEnumerable<State> States { get; set; } = new List<State>();

    public IndexModel(
        ILogger<IndexModel> logger,
        IModelService modelService,
        IFactionService factionService,
        IStateService stateService) : base(logger)
    {
        _modelService = modelService;
        _factionService = factionService;
        _stateService = stateService;
    }

    public async Task OnGetAsync()
    {
        Models = await _modelService.GetAllWithDetailsAsync();
        Factions = await _factionService.GetAllAsync();
        States = await _stateService.GetAllAsync();
    }
}