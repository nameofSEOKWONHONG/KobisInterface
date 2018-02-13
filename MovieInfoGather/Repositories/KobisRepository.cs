using MovieInfoGather.Models;
using MovieInfoGather.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfoGather.Repositories
{
    public class KobisRepository : IKobisRepository
    {
        public KobisRepository()
        {
        }

        public async Task<KobisBoxOfficeResult> GetBoxOfficeAsync(KobisBoxOfficeRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisBoxOfficeResult>(Consts.KOBIS_BOX_OFFICE_DAILY_URL, request.ToGetParam<KobisBoxOfficeRequest>());
        }

        public async Task<KobisBoxOfficeResult> GetBoxOfficeWeeklyAsync(KobisBoxOfficeRequest request)
        {
            var pHelper = new ParameterHelper(
                new { Key = nameof(request.key), Value = request.key },
                new { Key = nameof(request.targetDt), Value = request.targetDt }
            );

            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisBoxOfficeResult>(Consts.KOBIS_BOX_OFFICE_WEEKLY_URL, pHelper.ToGetParam());
        }

        public async Task<KobisMovieListResult> GetMovieListAsync(KobisMovieListRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisMovieListResult>(Consts.KOBIS_MOVIE_LIST_URL, request.ToGetParam<KobisMovieListRequest>());
        }

        public async Task<KobisMovieInfoDetailResult> GetMovieDetailAsync(KobisMovieInfoDetailRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisMovieInfoDetailResult>(Consts.KOBIS_MOVIE_DETAIL_URL, request.ToGetParam<KobisMovieInfoDetailRequest>());
        }
    }
}
