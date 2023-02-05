using ModsUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsUpdater.ViewModels
{
    public class VersionsViewModel
    {
        private readonly VersionItemModel _versionItemModel;

        public string Version
        {
            get => _versionItemModel.Version;
            set => _versionItemModel.Version = value;
        }

        public string GameVersion
        {
            get => _versionItemModel.GameVersion;
            set => _versionItemModel.GameVersion = value;
        }

        public string Description
        {
            get => _versionItemModel.Description;
            set => _versionItemModel.Description = value;
        }

        public string Url
        {
            get => _versionItemModel.Url;
            set => _versionItemModel.Url = value;
        }
        public VersionsViewModel(VersionItemModel versionItemModel)
        {
            _versionItemModel = versionItemModel;
        }
    }
}
