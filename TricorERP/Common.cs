using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TricorERP
{
    public class Common
    {
        //public static String WarehouseIDDefault = "80d6c98d-8a2b-462e-b735-efbe372f60b9";
        
        public static String WarehouseIDDefault = "a2f94df2-636d-4b25-a0c9-297e99f363e0";
        public static String POSManager = "7987e088-90d4-4525-b656-14f19d80a9c1";
        public static String POSCashier = "5387b2d6-7b04-4c8d-9e44-5e7744c4245c";
        public static String scm1 = "2a1b956f-f62a-4530-8937-22ec28c57257";
        public static String scm2 = "ffa0dc20-20c0-48d3-bfa2-e19ac6b5e703";
        public static String NULL_ID = Guid.Empty.ToString();

        internal static String CheckNullString(string variableToCheck)
        {
            if (variableToCheck == null ||
                variableToCheck == "null" ||
                variableToCheck == "" ||
                variableToCheck == "0")
                return Common.NULL_ID;
            else
                return variableToCheck;
        }

        public static String OrderPending = "cbe0d897-8f8b-4a76-8b77-00828efe180a";
        public static String OrderReadyToManufacturing = "797d295b-6d65-412a-8e59-489e1fa42cf0";
        public static String OrderComplete = "ac2e4413-8e83-4e5a-b1d9-8c93a0ec0898";

        public static string OrderApproved = "6e31117c-a2d6-4331-87d0-bba13d467193";
    }
}