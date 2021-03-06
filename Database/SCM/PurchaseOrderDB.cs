﻿using Models.SCM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.SCM
{
    public class PurchaseOrderDB
    {
        public static PurchaseOrderModel addPurchaseProduct(PurchaseOrderModel POModel)
        {
            String sql = @"INSERT INTO [dbo].[PurchaseOrder]
                        ([WHID],[SID],[OrderDate],[OrderType])
		                output inserted.ID 
                        VALUES ('" + POModel.WHID + "','" + POModel.SID + "','" +
                                 POModel.OrderDate + "','" + POModel.OrderType + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            POModel.ID = int.Parse(id.ToString());
            return POModel;
        }
        public static List<PurchaseOrderModel> getPurchaseOrderList(String searchtext)
        {
            List<PurchaseOrderModel> POList = new List<PurchaseOrderModel>();
            String sql = @"select PurchaseOrder.ID ID, PurchaseOrder.WHID WHID, PurchaseOrder.SID SID,
                            PurchaseOrder.OrderDate, PurchaseOrder.OrderType OrderType
                        from PurchaseOrder
                        where 1=1
                        and 
	                    (PurchaseOrder.WHID like '%" + searchtext + "%' or PurchaseOrder.SID like '%" + searchtext +
                        "%' or PurchaseOrder.OrderDate like '%" + searchtext + "%' or PurchaseOrder.ID like '%" +
                        searchtext + "%' or PurchaseOrder.OrderType like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                PurchaseOrderModel POMOdel = new PurchaseOrderModel();
                POMOdel.ID = int.Parse(reader["ID"].ToString());
                POMOdel.WHID = int.Parse(reader["WHID"].ToString());
                POMOdel.SID = int.Parse(reader["SID"].ToString());
                POMOdel.OrderDate = reader["OrderDate"].ToString();
                POMOdel.OrderType = reader["OrderType"].ToString();
                POList.Add(POMOdel);
            }
            return POList;
        }
        public static PurchaseOrderModel getPurchaseOrderInFo(String ID)
        {
            PurchaseOrderModel poModel = null;
            String sql = @"select  PurchaseOrder.WHID WHID, PurchaseOrder.SID SID,
                        PurchaseOrder.OrderDate OrderDate, PurchaseOrder.OrderType OrderType
                        from PurchaseOrder where PurchaseOrder.ID='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                poModel = new PurchaseOrderModel();
                poModel.WHID = int.Parse(reader["WHID"].ToString());
                poModel.SID = int.Parse(reader["SID"].ToString());
                poModel.OrderDate = reader["OrderDate"].ToString();
                poModel.OrderType = reader["OrderType"].ToString();

            }
            return poModel;
        }

        public static int updatePurchaseOrder(PurchaseOrderModel poModel)
        {
            String sql = @"UPDATE [dbo].[PurchaseOrder]
                         SET [WHID] = '" + poModel.WHID + "' ,[SID] = '" + poModel.SID
                        + "', [OrderDate]='" + poModel.OrderDate + "', [OrderType]='" + poModel.OrderType
                        + "' WHERE PurchaseOrder.ID = '" + poModel.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        /////----------------- PurchaseOrder Items ---------------------------/////////

        public static PurchaseOrderItemsModel addPurchaseProductItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"INSERT INTO [dbo].[PurchaseOrderItems]
                        ([POID],[PID],[Quantity],[PurchasePrice],[RecivedQuantity])
		                output inserted.ID 
                        VALUES ('" + POIModel.PurchaseOrderID + "','" + POIModel.ProductID + "','" +
                                 POIModel.Quantity + "','" + POIModel.PurchasePrice + "','"+0+"')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            POIModel.ID = int.Parse(id.ToString());
            return POIModel;
        }
        public static List<PurchaseOrderItemsModel> getAllPurchaseOrderitemsList(String searchtext)
        {
            List<PurchaseOrderItemsModel> POIList = new List<PurchaseOrderItemsModel>();
            String sql = @"select PurchaseOrderItems.ID ID, PurchaseOrderItems.POID POID, PurchaseOrderItems.PID PID, PurchaseOrderItems.Quantity Quantity,
                         PurchaseOrderItems.PurchasePrice PPrice,PurchaseOrderItems.RecivedQuantity RecivedQuantity from PurchaseOrderItems
                        where 1=1
                        and 
	                    (PurchaseOrderItems.POID like '%" + searchtext + "%' or PurchaseOrderItems.PurchasePrice like '%" + searchtext + "%' or PurchaseOrderItems.Quantity like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                PurchaseOrderItemsModel POIMOdel = new PurchaseOrderItemsModel();
                POIMOdel.ID = int.Parse(reader["ID"].ToString());
                POIMOdel.PurchaseOrderID = int.Parse(reader["POID"].ToString());
                POIMOdel.ProductID = int.Parse(reader["PID"].ToString());
                POIMOdel.Quantity = int.Parse(reader["Quantity"].ToString());
                POIMOdel.RecivedQuantity = int.Parse(reader["RecivedQuantity"].ToString());
                POIMOdel.PurchasePrice = float.Parse(reader["PPrice"].ToString());
                if (POIMOdel.Quantity > POIMOdel.RecivedQuantity)
                {
                    POIList.Add(POIMOdel);
                }
            }
            return POIList;
        }
        public static PurchaseOrderItemsModel getPurchaseOrderItemsInFo(String ID)
        {
            //PurchaseOrderItemsModel POIModel = null;
            String sql = @"select  PurchaseOrderItems.POID POID, PurchaseOrderItems.PID PID, PurchaseOrderItems.Quantity Quantity, 
                         PurchaseOrderItems.PurchasePrice PPrice , PurchaseOrderItems.RecivedQuantity RecivedQuantity from PurchaseOrderItems
                        where PurchaseOrderItems.ID='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                PurchaseOrderItemsModel POIMOdel = new PurchaseOrderItemsModel();
                POIMOdel.ID = int.Parse(ID);
                POIMOdel.PurchaseOrderID = int.Parse(reader["POID"].ToString());
                POIMOdel.ProductID = int.Parse(reader["PID"].ToString());
                POIMOdel.Quantity = int.Parse(reader["Quantity"].ToString());
                POIMOdel.RecivedQuantity = int.Parse(reader["RecivedQuantity"].ToString());
                POIMOdel.PurchasePrice = float.Parse(reader["PPrice"].ToString());
                return POIMOdel;
            }
            return null;
        }

        public static int updatePurchaseOrderItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"UPDATE [dbo].[PurchaseOrderItems]
                         SET [Quantity] = '" + POIModel.Quantity
                        + "', [PurchasePrice]='" + POIModel.PurchasePrice
                        + "' WHERE PurchaseOrderItems.ID = '" + POIModel.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
        public static int updatePurchaseOrderQuantity(PurchaseOrderItemsModel POIModel)
        {

            String sql = @"UPDATE [dbo].[PurchaseOrderItems]
                         SET   [RecivedQuantity]='" + POIModel.RecivedQuantity
                        + "' WHERE PurchaseOrderItems.ID = '" + POIModel.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                //add recived order items in stock
                updateStokQuantity(POIModel);

                POIModel = getPurchaseOrderItemsInFo(POIModel.ID.ToString());
                if (getDeliveredPurchaseOrderItemsCount(POIModel.PurchaseOrderID) == 0)
                {
                    String sql3 = @"UPDATE [dbo].[PurchaseOrder]
                         SET [OrderType]= '" + "5" 
                       + "' WHERE PurchaseOrder.ID = '" + POIModel.PurchaseOrderID + "'";
                    int check3 = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql3, null);
                    
                }
                return 1;
            }
            return 0;
        }

        private static void updateStokQuantity(PurchaseOrderItemsModel sModel)
           {
//            String sql = @"INSERT INTO [dbo].[Stock]
//                        ([WHID],[PID],[Quantity])
//		                output inserted.ID 
//                        VALUES ('" + Models.SCM.Common.OurWareHouseID + "','" + sModel.ProductID + "','" + sModel.Quantity + "')";
               String sql = @"UPDATE [dbo].[Stock]
                         SET [Quantity] = Quantity +'" + sModel.Quantity + "' WHERE Stock.PID = '" + sModel.ProductID + "'";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
        }
        public static List<ProductModel> getPurchaseOrderItemsList(string POID)
        {
            List<ProductModel> PModel = new List<ProductModel>();

            String sql = @"select Product.Id PID, Product.PName PName, Product.PCode PCode, Product.SalePrice SalePrice ,
                        Product.PThreshHoldValue PthreshHold,Product.PReOrderValue pReOrder,Product.PurchasePrice purchasePrice,
                        Product.UnitTypeID UnitTypeID,Product.ProductTypeID productTypeID
                        from Product
                        join PurchaseOrderItems on Product.ID = PurchaseOrderItems.PID
                        join PurchaseOrder on PurchaseOrder.ID = PurchaseOrderItems.POID
                        where PurchaseOrder.ID='" + POID + "' ";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = int.Parse(reader["PID"].ToString());
                product.ProductThresholdValue = int.Parse(reader["PthreshHold"].ToString());
                product.ProductReOderValue = int.Parse(reader["pReOrder"].ToString());
                product.ProductTypeID = int.Parse(reader["productTypeID"].ToString());
                product.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                product.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
                PModel.Add(product);
            }
            return PModel;
        }
        public static int deletePurchaseOrderItems(String ID)
        {
            String sql = @"DELETE FROM PurchaseOrderItems WHERE ID ='" + ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        public static int deletePurchaseOrder(string ID)
        {
            String sql = @"DELETE FROM PurchaseOrder WHERE ID ='" + ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        public static List<PurchaseOrderModel> GetSpecificPurchaseOrdersList(string type,string searchtext)
        {
            List<PurchaseOrderModel> POList = new List<PurchaseOrderModel>();
            String sql = @"select PurchaseOrder.ID ID, PurchaseOrder.WHID WHID, PurchaseOrder.SID SID,
                            PurchaseOrder.OrderDate, PurchaseOrder.OrderType OrderType
                        from PurchaseOrder
                        where PurchaseOrder.OrderType='" + type + "' and (PurchaseOrder.WHID like '%" + searchtext + "%' or PurchaseOrder.SID like '%" + searchtext +
                        "%' or PurchaseOrder.OrderDate like '%" + searchtext + "%' or PurchaseOrder.ID like '%" +
                        searchtext + "%' or PurchaseOrder.OrderType like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                PurchaseOrderModel POMOdel = new PurchaseOrderModel();
                POMOdel.ID = int.Parse(reader["ID"].ToString());
                POMOdel.WHID = int.Parse(reader["WHID"].ToString());
                POMOdel.SID = int.Parse(reader["SID"].ToString());
                POMOdel.OrderDate = reader["OrderDate"].ToString();
                POMOdel.OrderType = reader["OrderType"].ToString();
                POList.Add(POMOdel);
            }
            return POList;
        }

        public static int getProgressPurchaseOrderCount()
        {
            String sql = @"SELECT COUNT (*) as result
                         FROM PurchaseOrder 
                         where [PurchaseOrder].OrderType = '1'";
            object result = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(result.ToString());
        }
        public static int getDeliveredPurchaseOrderItemsCount(int ID)
        {
            String sql = @"SELECT COUNT (*) as result 
                         FROM PurchaseOrderItems
                         where [PurchaseOrderItems].Quantity > [PurchaseOrderItems].RecivedQuantity and [PurchaseOrderItems].POID='" + ID + "'";
            object result = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(result.ToString());
        }
    }
}

