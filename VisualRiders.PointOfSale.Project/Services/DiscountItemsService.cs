using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class DiscountItemsService
{
    private readonly DiscountItemsRepository _repository;
    private readonly IMapper _mapper;

    public DiscountItemsService(DiscountItemsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    //public DiscountItem Create(CreateUpdateDiscountItemDto dto)
    //{
    //    var discountItem = _mapper.Map<DiscountItem>(dto);

    //    _repository.Add(discountItem);
    //    _repository.SaveChanges();

    //    return discountItem;
    //}

    //public List<DiscountItem> GetAll()
    //{
    //   return  _repository.GetAll();
    //}

    //public DiscountItem? GetById(int id)
    //{
    //    return _repository.GetById(id);
    //}

    public List<ReadDiscountItemDto>? GetByDiscountId(int id)
    {
        var items = _repository.GetItemsByDiscountId(id);

        if (items == null) return null;

        return items.Select(_mapper.Map<ReadDiscountItemDto>).ToList();
    }

    //public bool RemoveById(int id)
    //{
    //    var discountItem = _repository.GetById(id);

    //    if (discountItem == null) return false;

    //    _repository.Remove(discountItem);
    //    _repository.SaveChanges();

    //    return true;
    //}
}