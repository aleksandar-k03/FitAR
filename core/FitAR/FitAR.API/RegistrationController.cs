using Direct;
using Direct.Fitardb.Models;
using Direct.Helpers;
using FitAR.Database;
using FitAR.Sockets;
using FitAR.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Web.API
{
  [Route("api/registration")]
  [Descriptor(Name = "RegistrationController", 
    Description = @"Логика за креирање корисничког налога преко андроид апликације")]
  public class RegistrationController : ARApiController
  {

    public RegistrationController() : base() { }
    [ActivatorUtilitiesConstructor] 
    public RegistrationController(DashboardSocketHandler socket) : base(socket) { }

    [HttpPost]
    [Route("create")]
    [Descriptor(Name = "Акција", 
      Input = typeof(RegistrationInputModel),
      Output = typeof(RegistrationModel),
      Description = @"Шаљу се подаци за креирање корисничког налога")]
    public async Task<RegistrationModel> OnRegistration(RegistrationInputModel input)
    {
      RegistrationModel result = new RegistrationModel();

      if(string.IsNullOrEmpty(input.username) || string.IsNullOrEmpty(input.firstName) ||
        string.IsNullOrEmpty(input.lastName) || string.IsNullOrEmpty(input.password))
      {
        result.GenerateError("Неки од података фале!");
        return result;
      }

      // check if there is account with same username
      var db = ARDirect.Instance;
      if(await ARDirect.Instance.Query<ClientDM>().Where("username={0}", input.username).CountAsync() > 0)
      {
        result.GenerateError("Корисничко име је заузето. Одаберите неко друго!");
        return result;
      }

      ClientDM client = new ClientDM(db)
      {
        username = input.username,
        password = DirectPassword.Hash(input.password),
        firstName = input.firstName,
        lastName = input.lastName
      };
      await client.InsertAsync();

      this.Notify(Sockets.Dashboard.Models.DashboardModel.FunctionTypes.notifySuccess, $"Нови корисник се регистровао: '${client.username}'!");

      return result;
    }

  }
}
