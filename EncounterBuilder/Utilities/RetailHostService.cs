using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace EncounterBuilder.Utilities
{
    public class RetailHostService : WebHostService
    {
        public RetailHostService(IWebHost host) : base(host)
        {
        }
        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            base.OnStopping();
        }
    }
}
