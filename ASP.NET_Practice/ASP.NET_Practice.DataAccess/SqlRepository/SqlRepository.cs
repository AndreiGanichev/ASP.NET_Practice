using Ninject;
using ASP.NET_Practice.DataAccess.Interfaces;

namespace ASP.NET_Practice.DataAccess.SqlRepository
{
    public partial class SqlRepository : IPracticeRepository
    {
        [Inject]
        public PracticeContext DbContext { get; set; }
    }
}
