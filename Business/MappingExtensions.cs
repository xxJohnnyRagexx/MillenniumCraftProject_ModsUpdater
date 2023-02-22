using Business.Dto;
using System.Runtime.CompilerServices;
using UpdatesServiceHttpClient;

namespace Business
{
    public static class MappingExtensions
    {
        public static UpdateItemDto ToDto(this UpdatesResponse source)
        {
            return new UpdateItemDto
            {
                Version = source.Version.ToString(),
                GameVersion = source.GameVersion,
                Description = source.Description,
            };
        }
    }
}