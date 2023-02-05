using Business.Dto;
using ModsUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsUpdater
{
    internal static class MappingExtensions
    {
        public static VersionItemModel ToModel(this UpdateItemDto source)
        {
            return new VersionItemModel
            {
                Version = source.Version,
                GameVersion = source.GameVersion,
                Description = source.Description,
                Url = source.Url,
            };
        }
    }
}
