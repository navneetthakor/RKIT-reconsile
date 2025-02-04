using System.Data;

namespace Final_Demo_AvanceCSharp.Utilitlies
{
    internal interface IDatabaseService
    {
        IDbConnection db { get; set; }
    }
}