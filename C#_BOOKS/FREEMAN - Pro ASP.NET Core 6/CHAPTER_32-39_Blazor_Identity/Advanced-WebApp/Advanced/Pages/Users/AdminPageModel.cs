using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advanced.Pages.Users;

[Authorize(Roles = "Admins")]
public class AdminPageModel : PageModel
{ 
}
