using Business.Dto;
using FakeDAL.Models;
using System.Runtime.CompilerServices;

namespace Business
{
    public static class MappingExtensions
    {
        public static UpdateItemDto ToDto(this UpdatesResponse source)
        {
            return new UpdateItemDto
            {
                Version = source.Version,
                GameVersion = source.GameVersion,
                Description = source.Description,
                Url = source.Url,
            };
        }
    }
}