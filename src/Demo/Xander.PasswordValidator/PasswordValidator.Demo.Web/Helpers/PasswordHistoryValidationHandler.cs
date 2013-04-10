﻿using System.Linq;
using System.Web;
using Xander.PasswordValidator;

namespace PasswordValidator.Demo.Web.Helpers
{
  public class PasswordHistoryValidationHandler : CustomValidationHandler<Repository>
  {
    public override bool Validate(string password)
    {
      var user = HttpContext.Current.User;
      var history = CustomData.GetPasswordHistory(user.Identity.Name);
      return !history.Any(h => string.Compare(password, h, true) == 0);
    }
  }
}