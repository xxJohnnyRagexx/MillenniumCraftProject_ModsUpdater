using Business.Dto;
using DAL;
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

        public static UpdateItemDto ToDto (this UpdateInfoEntity source)
        {
            return new UpdateItemDto
            {
                Version = source.Version.ToString(),
                GameVersion = source.GameVersion,
            };
        }

        public static UpdateInfoEntity ToEntity(this UpdateItemDto source)
        {
            return new UpdateInfoEntity
            {
                Version = Convert.ToInt32(source.Version),
                GameVersion = source.GameVersion,
            };
        }
    }
}