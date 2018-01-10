using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class PoliticManage
    {
        public static int Add(Politic politic)
        {
            return FTInterviewDAL.PoliticService.Add(politic);
        }

        public static List<Politic> GetAllPolitic()
        {
            return FTInterviewDAL.PoliticService.GetAllPolitic();
        }

    }
}
