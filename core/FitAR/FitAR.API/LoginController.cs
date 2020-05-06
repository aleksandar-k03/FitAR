﻿using Direct;
using Direct.Fitardb.Models;
using Direct.Helpers;
using FitAR.Database;
using FitAR.Sockets;
using FitAR.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Web.API
{
  [Route("api/login")]
  [Descriptor(Name ="Логин Контролер", 
    Description = @"Логика за корисничко пријављивање преко андроид апликације")]
  public class LoginController : ARApiController
  {

    public LoginController():base() { }
    public LoginController(DashboardSocketHandler socket) : base(socket) { }

    [HttpPost]
    [Descriptor(Name = "Логин Контролер", 
      Input = typeof(LoginInputModel),
      Output = typeof(LoginModel),
      Description = @"")]
    public async Task<LoginModel> Index(LoginInputModel input)
    {
      var result = new LoginModel();
      if(string.IsNullOrEmpty(input.username) || string.IsNullOrEmpty(input.password))
      {
        result.GenerateError("Неки од података фале!");
        return result;
      }

      ClientDM client = await ARDirect.Instance.Query<ClientDM>().Where("username={0}", input.username).LoadSingleAsync();
      if(client == null)
      {
        result.GenerateError("Не постоји налог са корисничким именом!");
        return result;
      }

      if(!DirectPassword.Verify(input.password, client.password))
      {
        result.GenerateError("Погрешна шифра!");
        return result;
      }

      ClientSessionDM session = new ClientSessionDM()
      {
        clientid = client.ID.Value
      };
      await session.InsertAsync();
      session.WaitID(3);

      result.clientID = client.ID.Value;
      result.session = session.clientSessionGuid.ToString();

      this.Notify(Sockets.Dashboard.Models.DashboardModel.FunctionTypes.notifySuccess, $"Корисник '${client.username}' се улоговао!");

      return result;
    }

  }
}