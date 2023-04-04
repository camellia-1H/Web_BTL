using Web_BTL.Models;

namespace Web_BTL.Responsitory
{
    public class RapResponsitory : IRapResponsitory
    {
        private readonly TheTicketMovieContext _context;
        public RapResponsitory(TheTicketMovieContext context)
        {
            _context = context;
        }
        public TRap Add(TRap rap)
        {
            _context.TRaps.Add(rap);
            _context.SaveChanges();
            return rap;
        }

        public TRap Delete(TRap rap)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TRap> GetAllRap()
        {
            return _context.TRaps;
        }

        public TRap GetHangSx(string marap)
        {
            throw new NotImplementedException();
        }

        public TRap GetRap(string marap)
        {
            return _context.TRaps.Find(marap);
        }

        public TRap Update(TRap rap)
        {
            _context.Update(rap);
            _context.SaveChanges();
            return rap;
        }
    }
}
