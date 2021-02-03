using System;

namespace DevTrack.Foundation.Services
{
    public class ServerTime : IServerTime
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)");
        }
    }
}