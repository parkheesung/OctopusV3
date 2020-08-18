using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.API
{
    public class KobisBoxOffice
    {
        public string boxofficeType { get; set; } = string.Empty;

        public string showRange { get; set; } = string.Empty;

        public string yearWeekTime { get; set; } = string.Empty;

        public List<KobisBoxOfficeItem> weeklyBoxOfficeList { get; set; } = new List<KobisBoxOfficeItem>();

        public KobisBoxOffice()
        {
        }
    }

    public class KobisBoxOfficeItem
    {
        public int rnum { get; set; } = 0;

        public int rank { get; set; } = 0;  //해당일자의 박스오피스 순위를 출력합니다.

        public int rankInten { get; set; } = 0;  //전일대비 순위의 증감분을 출력합니다.

        public string rankOldAndNew { get; set; } = string.Empty;

        public string movieCd { get; set; } = string.Empty;

        public string movieNm { get; set; } = string.Empty;

        public string openDt { get; set; } = string.Empty;

        public long salesAmt { get; set; } = 0;  //해당일의 매출액을 출력합니다.

        public double salesShare { get; set; } = 0;  //해당일자 상영작의 매출총액 대비 해당 영화의 매출비율을 출력합니다.

        public double salesInten { get; set; } = 0;  //전일 대비 매출액 증감분을 출력합니다.

        public double salesChange { get; set; } = 0;  //전일 대비 매출액 증감 비율을 출력합니다.

        public long salesAcc { get; set; } = 0;  //누적매출액을 출력합니다.

        public int audiCnt { get; set; } = 0; //해당일의 관객수를 출력합니다.

        public double audiInten { get; set; } = 0;  //전일 대비 관객수 증감분을 출력합니다.

        public double audiChange { get; set; } = 0;  //전일 대비 관객수 증감 비율을 출력합니다.

        public long audiAcc { get; set; } = 0;  //누적관객수

        public int scrnCnt { get; set; } = 0;  //해당일자 스크린수

        public int showCnt { get; set; } = 0;  //해당일자 상영횟수
    }
}
