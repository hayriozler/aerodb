using System;
using System.Threading.Tasks;

namespace AeroDb.Migration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new InstallationService().InstallDatabase().ConfigureAwait(false);
        }
    }
}
