﻿using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class StaffMembersProfile : Profile
{
    public StaffMembersProfile()
    {
        CreateMap<CreateUpdateShiftDto, Shift>();
        CreateMap<StaffMember, ReadStaffMemberDto>();
    }
}