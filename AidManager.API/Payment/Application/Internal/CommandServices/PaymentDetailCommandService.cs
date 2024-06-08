using AidManager.API.Payment.Domain.Model.Aggregates;
using AidManager.API.Payment.Domain.Model.Commands;
using AidManager.API.Payment.Domain.Repositories;
using AidManager.API.Payment.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Payment.Application.Internal.CommandServices;

public class PaymentDetailCommandService(IPaymentDetailRepository paymentDetailRepository, IUnitOfWork unitOfWork) : IPaymentDetailCommandService
{
    public async Task<PaymentDetail> Handle(CreatePaymentDetailCommand command)
    {
        Console.WriteLine("command service called");
        var paymentDetail = new PaymentDetail(command);
        Console.WriteLine("payment detail Aggregate created");
        paymentDetailRepository.CreatePaymentDetail(paymentDetail);
        Console.WriteLine("payment detail added to repository");
        await unitOfWork.CompleteAsync();
        Console.WriteLine("unit of work completed");
        return paymentDetail;
    }

}