using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class ShiftsService
{
    private readonly ShiftsRepository _shiftsRepository;
    private readonly StaffMembersRepository _staffMembersRepository;
    private readonly IMapper _mapper;

    public ShiftsService(ShiftsRepository shiftsRepository, StaffMembersRepository staffMembersRepository, IMapper mapper)
    {
        _shiftsRepository = shiftsRepository;
        _staffMembersRepository = staffMembersRepository;
        _mapper = mapper;
    }

    public ReadShiftDto Create(CreateUpdateShiftDto dto)
    {
        var shift = _mapper.Map<Shift>(dto);
        
        if (_staffMembersRepository.GetById(shift.StaffMemberId) == null)
        {
            throw new ArgumentException();
        }

        _shiftsRepository.Add(shift);
        _shiftsRepository.SaveChanges();

        return _mapper.Map<ReadShiftDto>(shift);
    }

    public List<ReadShiftDto> GetAll()
    {
        return _shiftsRepository.GetAll().Select(_mapper.Map<ReadShiftDto>).ToList();
    }

    public ReadShiftDto? GetById(int id)
    {
        return _mapper.Map<ReadShiftDto>(_shiftsRepository.GetById(id));
    }

    public ReadShiftDto? UpdateById(int id, CreateUpdateShiftDto dto)
    {
        var shift = _shiftsRepository.GetById(id);

        if (shift == null) return null;

        _mapper.Map(dto, shift);
        
        _shiftsRepository.SaveChanges();

        return _mapper.Map<ReadShiftDto>(shift);
    }

    public bool RemoveById(int id)
    {
        var shift = _shiftsRepository.GetById(id);

        if (shift == null) return false;
        
        _shiftsRepository.Remove(shift);
        _shiftsRepository.SaveChanges();

        return true;
    }
}