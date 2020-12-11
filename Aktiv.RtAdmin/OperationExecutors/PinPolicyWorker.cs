﻿using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using RutokenPkcs11Interop.HighLevelAPI;
using RutokenPkcs11Interop.Common;

namespace Aktiv.RtAdmin
{
    public static class PinPolicyWorker
    {
        public static void SetPinPolicy(Slot slot, string adminPin, PinPolicy pinPolicy)
        {
            var operationParams = new PinPolicyChangeOperationParams
            {
                LoginType = CKU.CKU_SO,
                LoginPin = adminPin,
                PinPolicy = pinPolicy
            };

            new PinPolicyChangeOperation().Invoke(slot, operationParams);
        }

        public static PinPolicy GetPinPolicy(Slot slot)
        {
            var session = slot.OpenSession(SessionType.ReadOnly);
            var res = session.GetPinPolicy(CKU.CKU_USER);
            session.CloseSession();
            return res;
        }

        public static bool PinPolicySupports(Slot slot)
        {
            var session = slot.OpenSession(SessionType.ReadOnly);
            var res = session.PinPolicySupports(CKU.CKU_USER);
            session.CloseSession();
            return res;
        }
    }
}
