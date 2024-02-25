using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.Database.DomainModelsı;
using Limakaz.ViewModels.Officies;
using Limakaz.ViewModels.OrderStatus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Admin;

[Route("admin/orderstatus")]
public class OrderStatusController : Controller
{
    public readonly LimakDbContext _limakDbContext;
    public readonly ILogger<OrderStatusController> _logger;

    public OrderStatusController(ILogger<OrderStatusController> logger, LimakDbContext limakDbContext)
    {
        _logger = logger;
        _limakDbContext = limakDbContext;
    }

    [HttpGet("list", Name ="orderstatus-list")]
    public IActionResult OrderStatus()
    {
        var list = _limakDbContext.OrderStatus.ToList();

        return View("Views/Admin/OrderStatus/OrderStatus.cshtml", list);
    }

    [HttpGet("add", Name = "add-order-status")]
    public IActionResult Add()
    {
        return View("Views/Admin/OrderStatus/AddStatus.cshtml");
    }

    [HttpPost("add", Name = "add-order-status-post")]
    public IActionResult Add(OrderStatusRequestViewModel model)
    {

        if(!ModelState.IsValid) return BadRequest(ModelState);

        if(model == null) return NoContent();

        var existStatus = _limakDbContext.OrderStatus.FirstOrDefault(x => x.StatusName == model.StatusName);
        if (existStatus != null)
        {
            return BadRequest();

        }

        var statusAdd = new OrderStatus
        {
            StatusName = model.StatusName
        };

        _limakDbContext.OrderStatus.Add(statusAdd);
        _limakDbContext.SaveChanges();

        return RedirectToAction("OrderStatus");
    }


    #region Update Status

    [HttpGet("update", Name = "update-order-status")]
    public async Task<IActionResult> Update([FromQuery] int id)
    {
        var status = await _limakDbContext.OrderStatus.FirstOrDefaultAsync(x => x.Id == id);
        if (status == null) return BadRequest(ModelState);

        var statusModel = new OrderStatusRequestViewModel
        {
            Id = status.Id,
            StatusName = status.StatusName

        };

        return View("Views/Admin/OrderStatuss/UpdateStatus.cshtml", statusModel);
    }

    [HttpPost("update", Name = "update-order-status-post")]
    public async Task<IActionResult> Update([FromQuery] int id, OrderStatusRequestViewModel model)
    {
        if (!ModelState.IsValid) { return BadRequest(); }

        var newStatus = new OrderStatus
        {
            Id = model.Id,
            StatusName = model.StatusName
        };

        _limakDbContext.OrderStatus.Update(newStatus);
        _limakDbContext.SaveChanges();

        return RedirectToAction("OrderStatus");

    }

    #endregion

    [HttpGet("delete", Name = "delete-status")]
    public async Task<IActionResult> Delete(int id)
    {
        OrderStatus status = await _limakDbContext.OrderStatus.FirstOrDefaultAsync(p => p.Id == id);
        if (status == null)
        {
            return NotFound();
        }

        _limakDbContext.Remove(status);
        _limakDbContext.SaveChangesAsync();

        return RedirectToAction("OrderStatus");

    }
}
