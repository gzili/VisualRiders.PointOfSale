using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class PaymentsService
{
    private readonly PaymentsRepository _paymentsRepository;
    private readonly OrdersRepository _ordersRepository;
    private readonly IMapper _mapper;

    public PaymentsService(PaymentsRepository paymentsRepository, OrdersRepository ordersRepository, IMapper mapper)
    {
        _paymentsRepository = paymentsRepository;
        _ordersRepository = ordersRepository;
        _mapper = mapper;
    }

    public ReadPaymentDto Create(CreatePaymentDto dto)
    {
        var order = _ordersRepository.GetById(dto.OrderId);
        if (order == null)
        {
            throw new UnprocessableEntity($"Order with Id = {dto.OrderId} does not exist");
        }

        var existingPayments = _paymentsRepository.FindByOrderId(dto.OrderId);
        var totalPaid = existingPayments.Sum(p => p.Amount);
        if (totalPaid >= order.Total)
        {
            throw new UnprocessableEntity("Order is already paid for");
        }

        var payment = _mapper.Map<Payment>(dto);
        var change = totalPaid + payment.Amount - order.Total;
        if (change > 0)
        {
            payment.Change = change;
        }
        
        _paymentsRepository.Add(payment);
        _paymentsRepository.SaveChanges();

        return _mapper.Map<ReadPaymentDto>(payment);
    }

    public List<ReadPaymentDto> GetAll(int? orderId)
    {
        List<Payment> payments;

        if (orderId.HasValue)
        {
            payments = _paymentsRepository.FindByOrderId(orderId.Value);
        }
        else
        {
            payments = _paymentsRepository.GetAll();
        }

        return payments.Select(_mapper.Map<ReadPaymentDto>).ToList();
    }

    public ReadPaymentDto? UpdateStatus(int paymentId, UpdatePaymentStatusDto dto)
    {
        var payment = _paymentsRepository.GetById(paymentId);

        if (payment == null) return null;

        payment.Status = dto.Status;
        
        _paymentsRepository.SaveChanges();

        return _mapper.Map<ReadPaymentDto>(payment);
    }
}