using AutoMapper;
using Domain.Wrapper;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class PaymentService 
{

    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public PaymentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public double CalculatePayment(string product, double amount, string phoneNumber, int installmentPeriod)
    {
        double totalAmount = amount;
        int minPeriod, maxPeriod, additionalPercentage;
    
        switch (product.ToLower())
        {
            case "смартфон":
                minPeriod = 3;
                maxPeriod = 24;
                if (installmentPeriod < 9)
                {
                    return totalAmount;
                }
                else if (installmentPeriod >9)
                {
                    for (int i = 9; i < installmentPeriod; i+=6)
                    {
                        totalAmount += (amount * 3 / 100);
                    }
                }
                break;
            case "компьютер":
                minPeriod = 3;
                maxPeriod = 24;
                if (installmentPeriod < 12)
                {
                    return totalAmount;
                }
                else if (installmentPeriod > 12)
                {
                    for (int i = 12; i < installmentPeriod; i+=6)
                    {
                        totalAmount += (amount * 4/ 100);
                    }
                }
                break;
            case "телевизор":
                minPeriod = 3;
                maxPeriod = 24;
                if (installmentPeriod < 18)
                {
                    return totalAmount;
                }
                else if (installmentPeriod > 18)
                {
                    for (int i = 18; i < installmentPeriod; i+=6)
                    {
                        totalAmount += (amount * 5 / 100);
                    }
                }
                break;
            default:
                throw new ArgumentException("Неверный продукт");
        }
    
        if (installmentPeriod < minPeriod || installmentPeriod > maxPeriod)
        {
            throw new ArgumentException($"Рассрочка должна быть в диапазоне от {minPeriod} до {maxPeriod} месяцев");
        }
        return totalAmount;
    }
}