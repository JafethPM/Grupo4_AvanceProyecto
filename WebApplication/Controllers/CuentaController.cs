using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

public class CuentaController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly AppDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CuentaController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        AppDbContext context,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _roleManager = roleManager;
    }


    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(
            email, password, false, false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ViewBag.Error = "Credenciales incorrectas";
        return View();
    }


    public IActionResult Registro()
    {
        return View("Registro");
    }

    [HttpPost]
    public async Task<IActionResult> Registro(string email, string password, string rol)
    {

        if (!await _roleManager.RoleExistsAsync(rol))
        {
            ViewBag.Error = "El rol no existe";
            return View("Registro");
        }


        var user = new IdentityUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            ViewBag.Error = string.Join(", ", result.Errors.Select(e => e.Description));
            return View("Registro");
        }


        await _userManager.AddToRoleAsync(user, rol);

        return RedirectToAction("Login");
    }


    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}