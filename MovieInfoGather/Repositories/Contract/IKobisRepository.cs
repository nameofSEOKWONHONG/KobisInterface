using MovieInfoGather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfoGather.Repositories.Contract
{
    public interface IKobisRepository
    {
        Task<KobisBoxOfficeResult> GetBoxOfficeAsync(KobisBoxOfficeRequest request);
        Task<KobisBoxOfficeResult> GetBoxOfficeWeeklyAsync(KobisBoxOfficeRequest request);
        Task<KobisCommCodeResult> GetMovieCommCodeListAsync(KobisCommCdRequest request);
        Task<KobisMovieCompDetailResult> GetMovieCompDetailAsync(KobisMovieCompDetailRequest request);
        Task<KobisMovieCompListResult> GetMovieCompListAsync(KobisMovieCompListRequest request);
        Task<KobisMovieInfoDetailResult> GetMovieDetailAsync(KobisMovieInfoDetailRequest request);
        Task<KobisMovieListResult> GetMovieListAsync(KobisMovieListRequest request);
        Task<KobisMoviePersonDetailResult> GetMoviePersonDetailAsync(KobisMoviePersonDetailRequest request);
        Task<KobisMoviePersonListResult> GetMoviePersonListAsync(KobisMoviePersonListRequest request);
    }
}
