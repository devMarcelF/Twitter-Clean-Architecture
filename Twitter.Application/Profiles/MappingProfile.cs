using AutoMapper;
using Twitter.Application.Features.TwitterStatistics;
using Twitter.Application.Features.TwitterStatistics.Commands.CreateTwitterStatistic;
using Twitter.Application.Features.TwitterStatistics.Commands.DeleteTwitterStatistic;
using Twitter.Application.Features.TwitterStatistics.Commands.UpdateTwitterStatistic;
using Twitter.Application.Features.TwitterStatistics.Queries.GetMostRecentTwitterStatisticDetail;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsExport;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsList;
using Twitter.Domain.Entities;

namespace Twitter.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // TwitterStatistic mapping
        CreateMap<TwitterStatistic, TwitterStatisticListVm>().ReverseMap();
        CreateMap<TwitterStatistic, TwitterStatisticDetailVm>().ReverseMap();
        CreateMap<TwitterStatistic, MostRecentTwitterStatisticsDetailVm>().ReverseMap();

        CreateMap<TwitterStatistic, CreateTwitterStatisticCommand>().ReverseMap();
        CreateMap<TwitterStatistic, UpdateTwitterStatisticCommand>().ReverseMap();
        CreateMap<TwitterStatistic, DeleteTwitterStatisticCommand>().ReverseMap();

        CreateMap<TwitterStatistic, CreateTwitterStatisticDto>().ReverseMap();
        CreateMap<TwitterStatistic, TwitterStatisticExportDto>().ReverseMap();
        
    }
}