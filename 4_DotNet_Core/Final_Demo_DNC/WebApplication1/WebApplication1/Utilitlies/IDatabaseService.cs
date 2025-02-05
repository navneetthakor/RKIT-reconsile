using System.Data;

namespace WebApplication1.Utilitlies
{
    public interface IDatabaseService
    {
        IDbConnection db { get; set; }
    }
}