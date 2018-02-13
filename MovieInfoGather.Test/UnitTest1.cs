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
        public async Task TestMethod_GetBoxOffice()
        {
            var result = await kobisRepo.GetBoxOfficeAsync(new Models.KobisBoxOfficeRequest()
            {
                key = Consts.KOBIS_API_KEY,
                targetDt = "20180102",

            });

            Assert.IsNotNull(result.boxOfficeResult);

            Assert.AreNotEqual(0, result.boxOfficeResult.dailyBoxOfficeList.Count);
        }

        [TestMethod]
        public async Task TestMethod_GetMovieListAndDetail()
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

        [TestMethod]
        public async Task TestMethod_GetMovieCommonCode()
        {
            //var result = await kobisRepo.GetMovieCommCodeListAsync(new Models.KobisCommCdRequest
            //{
            //    key = Consts.KOBIS_API_KEY
            //});

            //Assert.AreNotEqual(0, result.codes.Count);
        }

        [TestMethod]
        public async Task TestMethod_GetMoviePersonListAndDetail()
        {
            var result = await kobisRepo.GetMoviePersonListAsync(new Models.KobisMoviePersonListRequest
            {
                key = Consts.KOBIS_API_KEY
            });

            Assert.AreNotEqual(0, result.peopleListResult.peopleList.Count);

            if(result != null)
            {
                foreach(var person in result.peopleListResult.peopleList)
                {
                    var subresult = kobisRepo.GetMoviePersonDetailAsync(new Models.KobisMoviePersonDetailRequest
                    {
                        key = Consts.KOBIS_API_KEY,
                        peopleCd = person.peopleCd
                    });

                    Assert.IsNotNull(subresult);
                    break;
                }
            }
        }

        [TestMethod]
        public async Task TestMethod_GetMovieCompListAndDetail()
        {
            var result = await kobisRepo.GetMovieCompListAsync(new Models.KobisMovieCompListRequest
            {
                key = Consts.KOBIS_API_KEY
            });

            Assert.AreNotEqual(0, result.companyListResult.companyList.Count);

            if (result != null)
            {
                foreach (var comp in result.companyListResult.companyList)
                {
                    var subresult = kobisRepo.GetMovieCompDetailAsync(new Models.KobisMovieCompDetailRequest
                    {
                        key = Consts.KOBIS_API_KEY,
                        companyCd = comp.companyCd
                    });

                    Assert.IsNotNull(subresult);
                    break;
                }
            }
        }
    }
}
