using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieInfoGather.Repositories;
using MovieInfoGather.Repositories.Contract;
using System.Threading.Tasks;

namespace MovieInfoGather.Test
{
    [TestClass]
    public class UnitTest1
    {
        IKobisRepository kobisRepo;

        public UnitTest1()
        {
            kobisRepo = new KobisRepository();
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            var result = await kobisRepo.GetBoxOfficeAsync(new Models.KobisBoxOfficeRequest()
            {
                key = Consts.KOBIS_API_KEY,
                targetDt = "20180102",

            });

            Assert.AreNotEqual(0, result.boxOfficeResult.dailyBoxOfficeList.Count);
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            var result = await kobisRepo.GetMovieListAsync(new Models.KobisMovieListRequest
            {
                key = Consts.KOBIS_API_KEY,
                openStartDt = "2018",
                openEndDt = "2018"
            });

            Assert.AreNotEqual(0, result.movieListResult.movieList.Count);

            foreach(var movie in result.movieListResult.movieList)
            {
                var subresult = await kobisRepo.GetMovieDetailAsync(new Models.KobisMovieInfoDetailRequest
                {
                    key = Consts.KOBIS_API_KEY,
                    movieCd = movie.movieCd
                });

                Assert.AreNotEqual("", subresult.movieInfoResult.movieInfo.movieNm);

                break;
            }
        }
    }
}
