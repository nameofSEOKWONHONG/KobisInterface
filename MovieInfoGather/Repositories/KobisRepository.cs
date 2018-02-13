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

        public async Task<KobisMoviePersonListResult> GetMoviePersonListAsync(KobisMoviePersonListRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisMoviePersonListResult>(Consts.KOBIS_MOVIE_PERSON_LIST_URL, request.ToGetParam<KobisMoviePersonListRequest>());
        }

        public async Task<KobisMoviePersonDetailResult> GetMoviePersonDetailAsync(KobisMoviePersonDetailRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisMoviePersonDetailResult>(Consts.KOBIS_MOVIE_PERSON_DETAIL_URL, request.ToGetParam<KobisMoviePersonDetailRequest>());
        }

        public async Task<KobisCommCodeResult> GetMovieCommCodeListAsync(KobisCommCdRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisCommCodeResult>(Consts.KOBIS_COMMON_CODE_URL, request.ToGetParam<KobisCommCdRequest>());
        }

        public async Task<KobisMovieCompListResult> GetMovieCompListAsync(KobisMovieCompListRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisMovieCompListResult>(Consts.KOBIS_MOVIE_COMP_LIST_URL, request.ToGetParam<KobisMovieCompListRequest>());
        }

        public async Task<KobisMovieCompDetailResult> GetMovieCompDetailAsync(KobisMovieCompDetailRequest request)
        {
            var rHelper = new RequestHelper();
            return await rHelper.GetRequestAsync<KobisMovieCompDetailResult>(Consts.KOBIS_MOVIE_COMP_DETAIL_URL, request.ToGetParam<KobisMovieCompDetailRequest>());
        }
    }
}
