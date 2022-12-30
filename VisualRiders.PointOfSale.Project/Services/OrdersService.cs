using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class OrdersService
{
    private readonly OrdersRepository _ordersRepository;
    private readonly ClientsRepository _clientsRepository;
    private readonly ProductsRepository _productsRepository;
    private readonly ServicesRepository _servicesRepository;
    private readonly OrderItemsRepository _orderItemsRepository;
    private readonly TaxesRepository _taxesRepository;
    private readonly CategoriesRepository _categoriesRepository;
    private readonly IMapper _mapper;

    public OrdersService(OrdersRepository ordersRepository,
        ClientsRepository clientsRepository,
        ProductsRepository productsRepository,
        ServicesRepository servicesRepository,
        OrderItemsRepository orderItemsRepository,
        TaxesRepository taxesRepository,
        CategoriesRepository categoriesRepository,
        IMapper mapper)
    {
        _ordersRepository = ordersRepository;
        _clientsRepository = clientsRepository;
        _productsRepository = productsRepository;
        _servicesRepository = servicesRepository;
        _orderItemsRepository = orderItemsRepository;
        _taxesRepository = taxesRepository;
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;
    }

    private decimal GetProductTaxRate(Product product)
    {
        if (product.TaxId.HasValue)
        {
            return _taxesRepository.GetById(product.TaxId.Value)!.Percentage;
        }

        var category = _categoriesRepository.GetById(product.CategoryId)!;

        if (category.TaxId.HasValue)
        {
            return _taxesRepository.GetById(category.TaxId.Value)!.Percentage;
        }

        return 0;
    }

    private void ProcessOrderItem(OrderItem orderItem)
    {
        if (!(orderItem.ProductId.HasValue ^ orderItem.ServiceId.HasValue))
        {
            throw new UnprocessableEntity("Order Item must reference either a product or a service");
        }

        if (orderItem.ProductId.HasValue)
        {
            var product = _productsRepository.GetById(orderItem.ProductId.Value);

            if (product == null)
            {
                throw new UnprocessableEntity($"Product with Id = {orderItem.ProductId} does not exist");
            }

            orderItem.Price = product.Cost;

            orderItem.TaxRate = GetProductTaxRate(product);
        }

        if (orderItem.ServiceId.HasValue)
        {
            var service = _servicesRepository.GetById(orderItem.ServiceId.Value);
                
            if (service == null)
            {
                throw new UnprocessableEntity($"Service with Id = {orderItem.ServiceId} does not exist");
            }

            orderItem.Price = service.Cost;
        }
        
        orderItem.Subtotal = orderItem.Price * orderItem.Quantity;
        orderItem.TaxAmount = orderItem.Subtotal * orderItem.TaxRate;
        orderItem.Total = orderItem.Subtotal + orderItem.TaxAmount;
    }

    private void ProcessOrder(Order order)
    {
        order.Subtotal = order.Items.Sum(i => i.Subtotal);
        order.TaxTotal = order.Items.Sum(i => i.TaxAmount);
        order.Total = order.Items.Sum(i => i.Total);
    }

    public ReadOrderDto Create(CreateOrderDto dto)
    {
        var order = _mapper.Map<Order>(dto);

        order.BusinessEntityId = 1;
        order.TimeCreated = DateTime.Now;
        order.Status = OrderStatus.Created;

        if (order.ClientId.HasValue && _clientsRepository.GetById(order.ClientId.Value) == null)
        {
            throw new UnprocessableEntity($"Client with Id = {order.ClientId} does not exist");
        }

        foreach (var orderItem in order.Items)
        {
            ProcessOrderItem(orderItem);
        }

        ProcessOrder(order);
        
        _ordersRepository.Add(order);
        _ordersRepository.SaveChanges();

        return _mapper.Map<ReadOrderDto>(order);
    }

    public List<ReadOrderListDto> GetAll()
    {
        return _ordersRepository.GetAll().Select(_mapper.Map<ReadOrderListDto>).ToList();
    }

    public ReadOrderDto? GetById(int id)
    {
        var order = _ordersRepository.GetById(id);

        if (order == null) return null;

        order.Items = _orderItemsRepository.GetByOrderId(id);

        return _mapper.Map<ReadOrderDto>(order);
    }

    public ReadOrderDto? UpdateStatus(int orderId, UpdateOrderStatusDto dto)
    {
        var order = _ordersRepository.GetById(orderId);

        if (order == null) return null;

        order.Items = _orderItemsRepository.GetByOrderId(orderId);
        order.Status = dto.Status;
        
        _ordersRepository.SaveChanges();

        return _mapper.Map<ReadOrderDto>(order);
    }
    
    public ReadOrderDto? UpdateTips(int orderId, UpdateOrderTipsDto dto)
    {
        var order = _ordersRepository.GetById(orderId);

        if (order == null) return null;

        order.Items = _orderItemsRepository.GetByOrderId(orderId);
        order.Tips = dto.Amount;
        
        _ordersRepository.SaveChanges();

        return _mapper.Map<ReadOrderDto>(order);
    }

    public ReadOrderDto? AddItem(int orderId, CreateOrderItemDto dto)
    {
        var order = _ordersRepository.GetById(orderId);

        if (order == null) return null;

        var orderItem = _mapper.Map<OrderItem>(dto);
        
        ProcessOrderItem(orderItem);

        order.Items = _orderItemsRepository.GetByOrderId(orderId);
        order.Items.Add(orderItem);

        ProcessOrder(order);
        
        _ordersRepository.SaveChanges();

        return _mapper.Map<ReadOrderDto>(order);
    }

    public ReadOrderDto? UpdateItem(int orderId, int itemId, UpdateOrderItemDto dto)
    {
        var order = _ordersRepository.GetById(orderId);

        if (order == null) return null;

        order.Items = _orderItemsRepository.GetByOrderId(orderId);

        var orderItem = order.Items.Find(i => i.Id == itemId);

        if (orderItem == null) return null;

        _mapper.Map(dto, orderItem);
        
        ProcessOrderItem(orderItem);

        ProcessOrder(order);
        
        _ordersRepository.SaveChanges();

        return _mapper.Map<ReadOrderDto>(order);
    }

    public ReadOrderDto? DeleteItem(int orderId, int itemId)
    {
        var order = _ordersRepository.GetById(orderId);

        if (order == null) return null;

        order.Items = _orderItemsRepository.GetByOrderId(orderId);

        var orderItem = order.Items.Find(i => i.Id == itemId);

        if (orderItem != null)
        {
            order.Items.Remove(orderItem);
        }

        ProcessOrder(order);
        
        _ordersRepository.SaveChanges();

        return _mapper.Map<ReadOrderDto>(order);
    }

    public bool Delete(int id)
    {
        var order = _ordersRepository.GetById(id);

        if (order == null) return false;
        
        _ordersRepository.Remove(order);
        _ordersRepository.SaveChanges();

        return true;
    }
}