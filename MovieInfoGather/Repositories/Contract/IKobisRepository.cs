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
        Task<KobisMovieInfoDetailResult> GetMovieDetailAsync(KobisMovieInfoDetailRequest request);
        Task<KobisMovieListResult> GetMovieListAsync(KobisMovieListRequest request);
    }
}
