using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlobStore.Models;
using BlobStore.DataContent;
using BlobStore.Services;
using BlobStore.Models.ViewModels;

namespace BlobStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly BlobStorageService _blobStorage;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, BlobStorageService blobStorage)
    {
        _logger = logger;
        _context = context;
        _blobStorage = blobStorage;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Produtos"] = _context.produtos.ToList();

        return View();
    }

    public async Task<IActionResult> SendProduct(ProdutoViewModel produto)
    {
        string pictureUrl = "";

        if (produto.file != null)
        {
            pictureUrl = await _blobStorage.UploadAsync(produto.file);
        }

        var newProduto = produto.ConvertViewModelToEntity();

        newProduto.ImageUrl = pictureUrl;

        _context.produtos.Add(newProduto);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
