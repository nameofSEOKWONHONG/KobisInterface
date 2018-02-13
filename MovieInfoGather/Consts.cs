using System;
using System.IO;

namespace MovieInfoGather
{
    public class Consts
    {
        /// <summary>
        /// 타이머 인터벌
        /// </summary>
        public static readonly string INTERVAL = System.Configuration.ConfigurationManager.AppSettings["INTERVAL"];

        /// <summary>
        /// 로그 경로
        /// </summary>
        public static readonly string LOG_FILE_NAME = System.Configuration.ConfigurationManager.AppSettings["LOG_FILE_NAME"];

        public static readonly string KOBIS_BOX_OFFICE_DAILY_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_BOX_OFFICE_DAILY_URL"];
        public static readonly string KOBIS_BOX_OFFICE_WEEKLY_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_BOX_OFFICE_WEEKLY_URL"];
        public static readonly string KOBIS_COMMON_CODE_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_COMMON_CODE_URL"];
        public static readonly string KOBIS_MOVIE_LIST_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_MOVIE_LIST_URL"];
        public static readonly string KOBIS_MOVIE_DETAIL_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_MOVIE_DETAIL_URL"];
        public static readonly string KOBIS_MOVIE_COMP_LIST_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_MOVIE_COMP_LIST_URL"];
        public static readonly string KOBIS_MOVIE_COMP_DETAIL_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_MOVIE_COMP_DETAIL_URL"];
        public static readonly string KOBIS_MOVIE_PERSON_LIST_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_MOVIE_PERSON_LIST_URL"];
        public static readonly string KOBIS_MOVIE_PERSON_DETAIL_URL = System.Configuration.ConfigurationManager.AppSettings["KOBIS_MOVIE_PERSON_DETAIL_URL"];

        public static readonly string KOBIS_API_KEY = System.Configuration.ConfigurationManager.AppSettings["KOBIS_API_KEY"];
    }
}
