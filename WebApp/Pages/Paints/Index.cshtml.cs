using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using WebApp.Pages.Shared;

namespace WebApp.Pages.Paints;

public class IndexModel : BasePageModel
{
    private readonly IPaintService _paintService;
    private readonly IBrandService _brandService;

    public IEnumerable<Paint> Paints { get; set; } = new List<Paint>();
    public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();

    public IndexModel(
        ILogger<IndexModel> logger,
        IPaintService paintService,
        IBrandService brandService) : base(logger)
    {
        _paintService = paintService;
        _brandService = brandService;
    }

    public async Task OnGetAsync()
    {
        Paints = await _paintService.GetAllAsync();
        Brands = await _brandService.GetAllAsync();
    }
} 