using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Utility
{
    public static class OptionsValidate
    {
        public static void Confirm(KdniaoOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrEmpty(options.EBusinessID))
            {
                throw new ArgumentNullException(nameof(options.EBusinessID));
            }

            if (string.IsNullOrEmpty(options.AppKey))
            {
                throw new ArgumentNullException(nameof(options.AppKey));
            }
        }
    }
}
