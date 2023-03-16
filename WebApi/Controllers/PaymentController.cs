using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentControler:ControllerBase
{
    private readonly PaymentService _service;
    
    public PaymentControler(PaymentService service)
    {
        _service = service;
    }
    [HttpGet("GetCalculator")]
    public async Task<decimal> Calculate2(string product, double amount, string phoneNumber, int installmentPeriod)
    {
        return  (decimal)_service.CalculatePayment(product, amount, phoneNumber, installmentPeriod);
    }
}