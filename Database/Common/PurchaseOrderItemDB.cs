﻿using Models.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Common
{
    public class PurchaseOrderItemDB
    {
        public static List<PurchaseOrderItemsModel> getPurchaseOrderItemsList(String ID)
        {
            List<PurchaseOrderItemsModel> purchaseorderitems = new List<PurchaseOrderItemsModel>();

            String sql = @"SELECT [Product].PName PName, [PurchaseOrderItems].Quantity Quantity, [PurchaseOrderItems].ID ID
                        , [PurchaseOrderItems].CreatedBy CreatedBy, [PurchaseOrderItems].LastUpdatedBy LastUpdatedBy
                        from [Product]
                        join [PurchaseOrderItems] ON [PurchaseOrderItems].PID=[Product].Id
                        WHERE [PurchaseOrderItems].POID = '"+ID+"'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.Common.PurchaseOrderItemsModel item = new Models.Common.PurchaseOrderItemsModel();
                item.ID = reader["ID"].ToString();
                item.Quantity = int.Parse(reader["Quantity"].ToString());
                item.ProductName = reader["PName"].ToString();
                item.LastUpdatedBy = reader["LastUpdatedBy"].ToString();
                item.CreatedBy = reader["CreatedBy"].ToString();

                purchaseorderitems.Add(item);
            }
            return purchaseorderitems;
        }

        public static PurchaseOrderItemsModel addPurchaseProductItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"INSERT INTO [dbo].[PurchaseOrderItems]
           ([POID] ,[PID] ,[Quantity] ,[PurchasePrice] ,[CreatedBy] ,[LastUpdatedBy])
           output inserted.ID
           VALUES
           ('" + POIModel.PurchaseOrderID + "','" + POIModel.ProductID + "','" + POIModel.Quantity + "','"
               + POIModel.PurchasePrice + "','" + POIModel.CreatedBy + "','" + POIModel.LastUpdatedBy + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            POIModel.ID = id.ToString();
            return POIModel;
        }


        public static int updatePurchaseOrderItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"UPDATE [PurchaseOrderItems]
                        SET [Quantity] = '"+POIModel.Quantity+"' ,[LastUpdatedBy] = '"+POIModel.LastUpdatedBy
                        +"'WHERE [PurchaseOrderItems].ID = '"+POIModel.ID+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
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
    }
}