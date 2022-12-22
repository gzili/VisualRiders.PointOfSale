﻿using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class StaffMembersService
{
    private readonly StaffMembersRepository _repository;
    private readonly BusinessEntitiesService _businessEntitiesService;
    private readonly IMapper _mapper;

    public StaffMembersService(StaffMembersRepository repository, BusinessEntitiesService businessEntitiesService, IMapper mapper)
    {
        _businessEntitiesService = businessEntitiesService;
        _repository = repository;
        _mapper = mapper;
    }

    public StaffMember Create(CreateUpdateStaffMemberDto dto)
    {
        var staffMember = _mapper.Map<StaffMember>(dto);
        if (_businessEntitiesService.GetById(staffMember.BusinessEntityId) == null)
        {
            throw new ArgumentException();
        }
        
        _repository.Add(staffMember);
        _repository.SaveChanges();

        return staffMember;
    }

    public List<StaffMember> GetAll()
    {
        return _repository.GetAll();
    }

    public StaffMember? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public StaffMember? UpdateById(int id, CreateUpdateStaffMemberDto dto)
    {
        var staffMember = _repository.GetById(id);

        if (staffMember == null) return null;

        staffMember.BusinessEntityId = dto.BusinessEntityId;
        staffMember.PhoneNum = dto.PhoneNum;
        staffMember.SocSecNum = dto.SocSecNum;
        staffMember.Occupancy = dto.Occupancy;
        staffMember.BankAcc = dto.BankAcc;
        staffMember.Username = dto.Username;
        
        _repository.SaveChanges();

        return staffMember;
    }

    public bool RemoveById(int id)
    {
        var staffMember = _repository.GetById(id);

        if (staffMember == null) return false;
        
        _repository.Remove(staffMember);
        _repository.SaveChanges();

        return true;
    }
}