using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class orderController : ControllerBase
{


    private readonly ordercontext context;

    public orderController(ordercontext context)
    {
        this.context = context;
    }

    [HttpPost]
    public ActionResult<order> Postorder(order neworder)
    {
        context.order.Add(neworder);
        context.SaveChanges();
        return neworder;
    }
    [HttpDelete("id")]
    public ActionResult Deleteorder(string id)
    {
        var target = context.order.FirstOrDefault(o => o.ID == id);
        if(target!=null)
        {
            context.Remove(target);
            context.SaveChanges();
        }
        return NoContent();
    }
    [HttpGet("id")]
    public ActionResult<order> Getorder(string id)
    {
        var target = context.order.FirstOrDefault(o => o.ID == id);
        if (target == null)
        {
            return NotFound();           
        }
        return target;
    }
    [HttpPut("id")]
    public ActionResult<order> Putorder(string id, order target)
    {
        if (id != target.ID)
        {
            return BadRequest("Id cannot be modified!");
        }
        context.Entry(target).State = EntityState.Modified;
        context.SaveChanges();
        return NoContent();
    }

}
