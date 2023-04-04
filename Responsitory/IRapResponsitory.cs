using Web_BTL.Models;
namespace Web_BTL.Responsitory
{
    public interface IRapResponsitory
    {
        TRap Add(TRap rap);
        TRap Update(TRap rap);
        TRap Delete(TRap rap);
        TRap GetHangSx(string marap);
        IEnumerable<TRap> GetAllRap();
    }
}
