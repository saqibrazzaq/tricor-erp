using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TricorERP
{
    public class Common
    {
        //public static String WarehouseIDDefault = "80d6c98d-8a2b-462e-b735-efbe372f60b9";
        
        public static String WarehouseIDDefault = "1";
        public static String POSManager = "1";
        public static String POSCashier = "2";
        public static String NULL_ID = "0";

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

        public static String OrderPending = "1";
        public static String OrderReadyToManufacturing = "2";
        public static String OrderComplete = "6";
        public static string OrderApproved = "7";

    }
}