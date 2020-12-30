﻿using Net.Pkcs11Interop.Common;
using Net.RutokenPkcs11Interop.Common;
using Net.RutokenPkcs11Interop.HighLevelAPI;
using Net.RutokenPkcs11Interop.HighLevelAPI.Factories;

namespace Aktiv.RtAdmin
{
    public class VolumeInfo
    {
        public uint Id { get; set; }
        public ulong Size { get; set; }
        public FlashAccessMode AccessMode { get; set; }
        public uint Owner { get; set; }

        public IVolumeFormatInfoExtended ToVolumeFormatInfoExtended(IVolumeInfo volumeInfo)
        {
            var factory = new VolumeFormatInfoExtendedFactory();
            return factory.Create(volumeInfo.VolumeSize, volumeInfo.AccessMode, (CKU)volumeInfo.VolumeOwner, 0);
        }
    }
}
