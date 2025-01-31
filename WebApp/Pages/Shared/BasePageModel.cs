using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Shared;

public abstract class BasePageModel : PageModel
{
    protected readonly ILogger<BasePageModel> _logger;

    protected BasePageModel(ILogger<BasePageModel> logger)
    {
        _logger = logger;
    }

    protected void SetSuccessMessage(string message)
    {
        TempData["SuccessMessage"] = message;
    }

    protected void SetErrorMessage(string message)
    {
        TempData["ErrorMessage"] = message;
    }
} 