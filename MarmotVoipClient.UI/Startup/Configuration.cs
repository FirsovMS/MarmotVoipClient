using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.UI.Startup
{
    public class Configuration
    {
        public static bool IsDebugMode { get => Properties.Settings.Default.DebugMode; }
    }
}
