using System.Data;

namespace WebApplication1.Utilitlies
{
    internal interface IDatabaseService
    {
        IDbConnection db { get; set; }
    }
}