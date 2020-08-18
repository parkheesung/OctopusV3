using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.API
{
    public class KobisMovieInfo
    {
        public KobisMovieInfomation movieInfoResult { get; set; } = new KobisMovieInfomation();

        public KobisMovieInfo()
        {
        }
    }

    public class KobisMovieInfomation
    {
        public KobisMovieInfoDetail movieInfo { get; set; } = new KobisMovieInfoDetail();

        public KobisMovieInfomation()
        {
        }
    }

    public class KobisMovieInfoDetail
    {
        public string movieCd { get; set; } = string.Empty;
        public string movieNm { get; set; } = string.Empty;
        public string movieNmEn { get; set; } = string.Empty;
        public string movieNmOg { get; set; } = string.Empty;
        public int showTm { get; set; } = 0;
        public int prdtYear { get; set; } = 0;
        public string openDt { get; set; } = string.Empty;
        public string prdtStatNm { get; set; } = string.Empty;
        public string typeNm { get; set; } = string.Empty;

        public List<KobisMovieInfoNation> nations { get; set; } = new List<KobisMovieInfoNation>();

        public List<KobisMovieInfoGenre> genres { get; set; } = new List<KobisMovieInfoGenre>();

        public List<KobisMovieInfoDirector> directors { get; set; } = new List<KobisMovieInfoDirector>();

        public List<KobisMovieInfoActor> actors { get; set; } = new List<KobisMovieInfoActor>();

        public List<KobisMovieInfoShowType> showTypes { get; set; } = new List<KobisMovieInfoShowType>();

        public List<KobisMovieInfoCompany> companys { get; set; } = new List<KobisMovieInfoCompany>();

        public List<KobisMovieInfoAudit> audits { get; set; } = new List<KobisMovieInfoAudit>();

        public List<KobisMovieInfoStaff> staffs { get; set; } = new List<KobisMovieInfoStaff>();

        public string source { get; set; } = string.Empty;

        public KobisMovieInfoDetail()
        {
        }
    }

    public class KobisMovieInfoNation
    {
        public string nationNm { get; set; } = string.Empty;

        public KobisMovieInfoNation()
        {
        }
    }

    public class KobisMovieInfoGenre
    {
        public string genreNm { get; set; } = string.Empty;

        public KobisMovieInfoGenre()
        {
        }
    }

    public class KobisMovieInfoDirector
    {
        public string peopleNm { get; set; } = string.Empty;

        public string peopleNmEn { get; set; } = string.Empty;

        public KobisMovieInfoDirector()
        {
        }
    }

    public class KobisMovieInfoActor
    {
        public string peopleNm { get; set; } = string.Empty;
        public string peopleNmEn { get; set; } = string.Empty;
        public string cast { get; set; } = string.Empty;
        public string castEn { get; set; } = string.Empty;

        public KobisMovieInfoActor()
        {
        }
    }

    public class KobisMovieInfoShowType
    {
        public string showTypeGroupNm { get; set; } = string.Empty;

        public string showTypeNm { get; set; } = string.Empty;

        public KobisMovieInfoShowType()
        {
        }
    }

    public class KobisMovieInfoCompany
    {
        public string companyCd { get; set; } = string.Empty;
        public string companyNm { get; set; } = string.Empty;
        public string companyNmEn { get; set; } = string.Empty;
        public string companyPartNm { get; set; } = string.Empty;

        public KobisMovieInfoCompany()
        {
        }
    }

    public class KobisMovieInfoAudit
    {
        public string auditNo { get; set; } = string.Empty;

        public string watchGradeNm { get; set; } = string.Empty;

        public KobisMovieInfoAudit()
        {
        }
    }

    public class KobisMovieInfoStaff
    {
        public string peopleNm { get; set; } = string.Empty;

        public string peopleNmEn { get; set; } = string.Empty;

        public string staffRoleNm { get; set; } = string.Empty;

        public KobisMovieInfoStaff()
        {
        }
    }
}
