using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using asp_net_labs.Models;

namespace Microsoft.AspNetCore.Mvc
{
    [ApiController]
    [Route("api/company")]
    public class ApiController : ControllerBase
    {
        public Dictionary<string, object> Post(CompanyModel company)
        {
            var response = new Dictionary<string, object>();
            bool succeded = true;

            try
            {
                var viewModel = new CompanyAddedViewModel
                {
                    NumberOfCharsInName = company.Name.Length,
                    NumberOfCharsInDescription = company.Description.Length,
                    IsHidden = !company.IsVisible
                };
                response.Add("data", viewModel);
            }
            catch (Exception exception)
            {
                succeded = false;
                response.Add("errorMsg:", exception.Message);
            }

            response.Add("success", succeded);

            return response;
        }
    }
}
