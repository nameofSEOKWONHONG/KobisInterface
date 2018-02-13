using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfoGather.Models
{
    public class KobisBaseRequest
    {
        /// <summary>
        /// 발급받은키 값을 입력합니다.
        /// </summary>
        public string key { get; set; }
    }

    #region 박스오피스 
    public class KobisBoxOfficeRequest : KobisBaseRequest
    {
        /// <summary>
        /// 조회하고자 하는 날짜를 yyyymmdd 형식으로 입력합니다.
        /// </summary>
        public string targetDt { get; set; }

        /// <summary>
        /// 결과 ROW 의 개수를 지정합니다.(default : “10”, 최대 : “10“)
        /// </summary>
        public string itemPerPage { get; set; }

        /// <summary>
        /// 다양성 영화/상업영화를 구분지어 조회할 수 있습니다. “Y” : 다양성 영화 “N” : 상업영화(default : 전체)
        /// </summary>
        public string multiMovieYn { get; set; }

        /// <summary>
        /// 한국/외국 영화별로 조회할 수 있습니다. “K: : 한국영화 “F” : 외국영화(default : 전체)
        /// </summary>
        public string repNationCd { get; set; }

        /// <summary>
        /// 상영지역별로 조회할 수 있으며, 지역코드는 공통코드 조회 서비스에서 “0105000000” 로서 조회된 지역코드입니다. (default : 전체)
        /// </summary>
        public string wideAreaCd { get; set; }
    }

    public class KobisBoxOfficeWeeklyRequest : KobisBoxOfficeRequest
    {
        /// <summary>
        /// 주간/주말/주중을 선택 입력합니다. “0” : 주간 (월~일)	“1” : 주말 (금~일) (default)	“2” : 주중 (월~목)
        /// </summary>
        public string weekGb { get; set; }
    }

    public class DailyBoxOfficeList
    {
        public string rnum { get; set; }
        public string rank { get; set; }
        public string rankInten { get; set; }
        public string rankOldAndNew { get; set; }
        public string movieCd { get; set; }
        public string movieNm { get; set; }
        public string openDt { get; set; }
        public string salesAmt { get; set; }
        public string salesShare { get; set; }
        public string salesInten { get; set; }
        public string salesChange { get; set; }
        public string salesAcc { get; set; }
        public string audiCnt { get; set; }
        public string audiInten { get; set; }
        public string audiChange { get; set; }
        public string audiAcc { get; set; }
        public string scrnCnt { get; set; }
        public string showCnt { get; set; }
    }    

    public class WeeklyBoxOfficeList
    {
        public string rnum { get; set; }
        public string rank { get; set; }
        public string rankInten { get; set; }
        public string rankOldAndNew { get; set; }
        public string movieCd { get; set; }
        public string movieNm { get; set; }
        public string openDt { get; set; }
        public string salesAmt { get; set; }
        public string salesShare { get; set; }
        public string salesInten { get; set; }
        public string salesChange { get; set; }
        public string salesAcc { get; set; }
        public string audiCnt { get; set; }
        public string audiInten { get; set; }
        public string audiChange { get; set; }
        public string audiAcc { get; set; }
        public string scrnCnt { get; set; }
        public string showCnt { get; set; }
    }

    public class BoxOfficeResult
    {
        public string boxofficeType { get; set; }
        public string showRange { get; set; }
        public string yearWeekTime { get; set; }
        public List<DailyBoxOfficeList> dailyBoxOfficeList { get; set; }
        public List<WeeklyBoxOfficeList> weeklyBoxOfficeList { get; set; }
    }

    public class KobisBoxOfficeResult
    {
        public BoxOfficeResult boxOfficeResult { get; set; }
    }
    #endregion

    #region 공통코드
    public class KobisCommCdRequest : KobisBaseRequest
    {
        /// <summary>
        /// 조회하고자 하는 상위코드를 입력합니다.
        /// </summary>
        public string commCode { get; set; }
    }

    public class Code
    {
        public string fullCd { get; set; }
        public string korNm { get; set; }
        public string engNm { get; set; }
    }

    public class KobisCommCodeResult
    {
        public List<Code> codes { get; set; }
    }
    #endregion

    #region 영화목록
    public class KobisMovieListRequest : KobisBaseRequest
    {
        public string curPage { get; set; }
        public string itemPerPage { get; set; }
        public string movieNm { get; set; }
        public string directorNm { get; set; }
        public string openStartDt { get; set; }
        public string openEndDt { get; set; }
        public string prdtStartYear { get; set; }
        public string prdtEndYear { get; set; }
        public string repNationCd { get; set; }
        public string movieTypeCd { get; set; }

    }

    public class MovieList
    {
        public string movieCd { get; set; }
        public string movieNm { get; set; }
        public string movieNmEn { get; set; }
        public string prdtYear { get; set; }
        public string openDt { get; set; }
        public string typeNm { get; set; }
        public string prdtStatNm { get; set; }
        public string nationAlt { get; set; }
        public string genreAlt { get; set; }
        public string repNationNm { get; set; }
        public string repGenreNm { get; set; }
        public List<object> directors { get; set; }
        public List<object> companys { get; set; }
    }

    public class MovieListResult
    {
        public int totCnt { get; set; }
        public string source { get; set; }
        public List<MovieList> movieList { get; set; }
    }

    public class KobisMovieListResult
    {
        public MovieListResult movieListResult { get; set; }
    }
    #endregion

    #region 영화상세
    public class KobisMovieInfoDetailRequest : KobisBaseRequest
    {
        public string movieCd { get; set; }
    }

    public class Nation
    {
        public string nationNm { get; set; }
    }

    public class Genre
    {
        public string genreNm { get; set; }
    }

    public class Director
    {
        public string peopleNm { get; set; }
        public string peopleNmEn { get; set; }
    }

    public class Actor
    {
        public string peopleNm { get; set; }
        public string peopleNmEn { get; set; }
        public string cast { get; set; }
        public string castEn { get; set; }
    }

    public class ShowType
    {
        public string showTypeGroupNm { get; set; }
        public string showTypeNm { get; set; }
    }

    public class Company
    {
        public string companyCd { get; set; }
        public string companyNm { get; set; }
        public string companyNmEn { get; set; }
        public string companyPartNm { get; set; }
    }

    public class Audit
    {
        public string auditNo { get; set; }
        public string watchGradeNm { get; set; }
    }

    public class Staff
    {
        public string peopleNm { get; set; }
        public string peopleNmEn { get; set; }
        public string staffRoleNm { get; set; }
    }

    public class MovieInfo
    {
        public string movieCd { get; set; }
        public string movieNm { get; set; }
        public string movieNmEn { get; set; }
        public string movieNmOg { get; set; }
        public string showTm { get; set; }
        public string prdtYear { get; set; }
        public string openDt { get; set; }
        public string prdtStatNm { get; set; }
        public string typeNm { get; set; }
        public List<Nation> nations { get; set; }
        public List<Genre> genres { get; set; }
        public List<Director> directors { get; set; }
        public List<Actor> actors { get; set; }
        public List<ShowType> showTypes { get; set; }
        public List<Company> companys { get; set; }
        public List<Audit> audits { get; set; }
        public List<Staff> staffs { get; set; }
    }

    public class MovieInfoResult
    {
        public MovieInfo movieInfo { get; set; }
        public string source { get; set; }
    }

    public class KobisMovieInfoDetailResult
    {
        public MovieInfoResult movieInfoResult { get; set; }
    }
    #endregion

    #region 영화사 목록
    public class KobisMovieCompListRequest : KobisBaseRequest
    {
        public string curPage { get; set; }

        public string itemPerPage { get; set; }

        public string companyNm { get; set; }

        public string ceoNm { get; set; }

        public string companyPartCd { get; set; }
    }

    public class CompanyList
    {
        public string companyCd { get; set; }
        public string companyNm { get; set; }
        public string companyNmEn { get; set; }
        public string companyPartNames { get; set; }
        public string ceoNm { get; set; }
        public string filmoNames { get; set; }
    }

    public class CompanyListResult
    {
        public int totCnt { get; set; }
        public List<CompanyList> companyList { get; set; }
        public string source { get; set; }
    }

    public class KobisMovieCompListResult
    {
        public CompanyListResult companyListResult { get; set; }
    }
    #endregion

    #region 영화사 상세
    public class KobisMovieCompDetailRequest : KobisBaseRequest
    {
        public string companyCd { get; set; }
    }

    public class Part
    {
        public string companyPartNm { get; set; }
    }

    public class CompanyInfo
    {
        public string companyCd { get; set; }
        public string companyNm { get; set; }
        public string companyNmEn { get; set; }
        public string ceoNm { get; set; }
        public List<Part> parts { get; set; }
        public List<Filmo> filmos { get; set; }
    }

    public class CompanyInfoResult
    {
        public CompanyInfo companyInfo { get; set; }
        public string source { get; set; }
    }

    public class KobisMovieCompDetailResult
    {
        public CompanyInfoResult companyInfoResult { get; set; }
    }
    #endregion

    #region 영화인 목록
    public class KobisMoviePersonListRequest : KobisBaseRequest
    {
        public string curPage { get; set; }
        public string itemPerPage { get; set; }
        public string peopleNm { get; set; }
        public string filmoNames { get; set; }
    }

    public class PeopleList
    {
        public string peopleCd { get; set; }
        public string peopleNm { get; set; }
        public string peopleNmEn { get; set; }
        public string repRoleNm { get; set; }
        public string filmoNames { get; set; }
    }

    public class PeopleListResult
    {
        public int totCnt { get; set; }
        public List<PeopleList> peopleList { get; set; }
        public string source { get; set; }
    }

    public class KobisMoviePersonListResult
    {
        public PeopleListResult peopleListResult { get; set; }
    }


    #endregion

    #region 영화인 상세
    public class KobisMoviePersonDetailRequest : KobisBaseRequest
    {
        public string peopleCd { get; set; }
    }

    public class Filmo
    {
        public string movieCd { get; set; }
        public string movieNm { get; set; }
        public string moviePartNm { get; set; }
    }

    public class PeopleInfo
    {
        public string peopleCd { get; set; }
        public string peopleNm { get; set; }
        public string peopleNmEn { get; set; }
        public string sex { get; set; }
        public string repRoleNm { get; set; }
        public List<object> homepages { get; set; }
        public List<Filmo> filmos { get; set; }
    }

    public class PeopleInfoResult
    {
        public PeopleInfo peopleInfo { get; set; }
        public string source { get; set; }
    }

    public class KobisMoviePersonDetailResult
    {
        public PeopleInfoResult peopleInfoResult { get; set; }
    }
    #endregion
}
