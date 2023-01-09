using Microsoft.EntityFrameworkCore;

namespace XGame.Infra.Persistence
{
    public class XGameContext : DbContext
    {
        public XGameContext() : base("")
        {
            Configuration.ProxyCreationEnabled = false;
        }

    }
}
