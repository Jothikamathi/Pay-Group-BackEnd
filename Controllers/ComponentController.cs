using Microsoft.AspNetCore.Mvc;
using payapi.Models;
namespace payapi.Controllers;
using Microsoft.EntityFrameworkCore;
// using System.Data.Entity;
//  using System.Data.Entity.Infrastructure;
[ApiController]
[Route("Api/User")]
public class ComponentController : ControllerBase
{
    private readonly ComponentContext DB;
    public ComponentController(ComponentContext dbContext) 
    {
        this.DB = dbContext;
    }
    [HttpGet("GetPayDetails")]
    public  IQueryable<TbComponent>GetAll()
    {
        var users = this.DB.TbComponents;
        return users;
    }
    [HttpGet("GetPayDetailsById/{uid}")]
    public IActionResult GetById(int uid)
    {
        var users=this.DB.TbComponents.FirstOrDefault(o=>o.ComponentCode==uid);
        return Ok(users);
    }
    [HttpDelete("DeleteUserDetails/{uid}")]
    public IActionResult DeleteRegister(int uid)
    {
        string message = "";
        var user = this.DB.TbComponents.Find(uid);
        if(user==null)
        {
            return NotFound();
        }
        this.DB.TbComponents.Remove(user);
        int result = this.DB.SaveChanges();
        if(result>0)
        {
            message = "User has been successfully deleted";
        }
        else
        {
            message="failed";
        }
        return Ok(message);
    }
    [HttpPost("InsertPayDetails")]
  public object InsertPay(TbComponent comObj)
  {
     string message = ""; 
    try{
        TbComponent tb = new TbComponent();
        if(tb.ComponentCode==0)
        {

            tb.ComponentCode = comObj.ComponentCode;
            tb.StartDate = comObj.StartDate;
            tb.EndDate = comObj.EndDate;
            tb.ComponentDescription = comObj.ComponentDescription;
            tb.MonthlyLimit = comObj.MonthlyLimit;
            tb.FortNightLimit = comObj.FortNightLimit;
            //Add
            DB.TbComponents.Add(tb);
                int result = this.DB.SaveChanges();
                    if (result > 0)
                    {
                        message = "User has been sucessfully added";
                    }
                    else
                    {
                        message = "failed";
                    }
                      return Ok(message);
            //Add

            //save it in the database
            DB.SaveChanges();

            return new Response{Status="Success" , Message = "Employee Added!"};

        }
    }
    catch(System.Exception)
    {
throw;
    }

    return new Response{Status="Error" , Message="Invalid Information"};
  }   
  [HttpPut]
[Route("UpdateEmployeeDetails")]
public IActionResult putEmployee(TbComponent user)
{
    string message = "";
    if(!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    try{
        TbComponent  obj = new TbComponent();
        // obj= DB.TbEmployees.Find(user.Id);
        obj = this.DB.TbComponents.Find(user.ComponentCode);
        if(obj !=null){
             obj.ComponentCode=user.ComponentCode;
            obj.StartDate = user.StartDate;
            obj.EndDate=user.EndDate;
            obj.ComponentDescription=user.ComponentDescription;
            obj.MonthlyLimit=user.MonthlyLimit;
            obj.FortNightLimit=user.FortNightLimit;
        }
        int result=this.DB.SaveChanges();
        if(result>0){
            message="updated";
        }
        else{
            message="failed";
        }       
    }
    catch(Exception){
        throw;
    }
    return Ok(message);
}
}
    
  
