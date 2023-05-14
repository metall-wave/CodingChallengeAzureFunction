using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CodingChallengeAzureFunction.Models;
using System.Linq;

namespace CodingChallengeAzureFunction
{
    public static class SalesDataFunction
    {
        [FunctionName("sales-data")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SalesDataFunction processed a request.");

            var body = await req.GetBodyAsync<SalesData>();

            if (body.IsValid)
            {
                SalesData newSalesData = body.Value;
                using AppDbContext context = new AppDbContext();

                SalesData existingSalesData = context.SalesData.FirstOrDefault(sd => sd.TransactionId.Equals(newSalesData.TransactionId));

                if (existingSalesData != null)
                {
                    existingSalesData.Amount = newSalesData.Amount;
                    existingSalesData.BranchId = newSalesData.BranchId;
                    existingSalesData.TransactionDate = newSalesData.TransactionDate;
                    existingSalesData.LoyaltyCardNumber = newSalesData.LoyaltyCardNumber;
                }
                else
                {
                    await context.SalesData.AddAsync(newSalesData);
                }

                await context.SaveChangesAsync();

                return new OkObjectResult(newSalesData);
            }
            else
            {
                return new BadRequestObjectResult($"Model is invalid: {string.Join(", ", body.ValidationResults.Select(s => s.ErrorMessage).ToArray())}");
            }
        }
    }
}
