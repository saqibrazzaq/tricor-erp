﻿using Models.POS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.POS
{
    public class ProductDB
    {
        public static ProductModel addProduct(ProductModel productModel)
        {
            String sql = @"INSERT INTO [dbo].[Product]
                        ([PName],[PCode],[SalePrice],[PDescription],[PThreshHoldValue],[PReOrderValue],[PurchasePrice],
                        [UnitTypeID],[ProductTypeID])
		                output inserted.ID 
                        VALUES ('" + productModel.ProductName + "','" + productModel.ProductCode + "','" +
                                 productModel.SalesPrice + "','" + productModel.ProductDescription +
                                 "','" + productModel.ProductThresholdValue + "','" + productModel.ProductReOderValue + "','" +
                                 productModel.PurchasePrice + "','" + productModel.UnitTypeID + "','" + productModel.ProductTypeID + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            productModel.ProductID = id.ToString();
            return productModel;
        }
        public static List<ProductModel> getProductList(String searchtext)
        {
            List<ProductModel> productList = new List<ProductModel>();
            String sql = @"select top 10 Product.Id PID, Product.PName PName, Product.PCode PCode, Product.SalePrice SalePrice ,
                        Product.PThreshHoldValue PthreshHold,Product.PReOrderValue pReOrder,Product.PurchasePrice purchasePrice,
                        Product.UnitTypeID UnitTypeID,Product.ProductTypeID productTypeID
                        from Product
                        where 1=1
                        and 
	                    (Product.PName like '%" + searchtext + "%' or Product.PCode like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = reader["PID"].ToString();
                product.ProductThresholdValue = int.Parse(reader["PthreshHold"].ToString());
                product.ProductReOderValue = int.Parse(reader["pReOrder"].ToString());
                product.ProductTypeID = reader["productTypeID"].ToString();
                product.UnitTypeID = reader["UnitTypeID"].ToString();
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                product.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
                productList.Add(product);
            }
            return productList;
        }
        public static ProductModel getProductInFo(String ID)
        {
            ProductModel product = null;
            String sql = @"select Product.PName PName, Product.PCode PCode, Product.SalePrice SalePrice ,Product.PDescription PDescription ,
                        Product.PThreshHoldValue PthreshHold,Product.PReOrderValue pReOrder,Product.PurchasePrice purchasePrice,
                        Product.UnitTypeID UnitTypeID,Product.ProductTypeID productTypeID
                        from Product where Product.id='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                product = new ProductModel();
                product.ProductThresholdValue = int.Parse(reader["PthreshHold"].ToString());
                product.ProductReOderValue = int.Parse(reader["pReOrder"].ToString());
                product.ProductTypeID = reader["productTypeID"].ToString();
                product.UnitTypeID = reader["UnitTypeID"].ToString();
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.ProductDescription = reader["PDescription"].ToString();
                product.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                product.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
            }
            return product;
        }
        public static int updateProduct(ProductModel pModel)
        {
            String sql = @"UPDATE [dbo].[Product]
                         SET [PName] = '" + pModel.ProductName + "' ,[pCode] = '" + pModel.ProductCode
                        + "', [SalePrice]='" + pModel.SalesPrice + "' , [PDescription] = '" + pModel.ProductDescription
                        + "' , [PThreshHoldValue] = '" + pModel.ProductThresholdValue
                        + "',[PReOrderValue] = '" + pModel.ProductReOderValue + "' , [PurchasePrice] = '" + pModel.PurchasePrice
                        + "' , [UnitTypeID] = '" + pModel.UnitTypeID + "' , [ProductTypeID] = '" + pModel.ProductTypeID
                        + "' WHERE Product.id = '" + pModel.ProductID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
        public static List<ProductModel> getProductList() {
            List<ProductModel> products = new List<ProductModel>();
            string sql = "SELECT * FROM Product ";
            using (SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    // Create new product model
                    ProductModel product = new ProductModel();
                    product.ProductID = reader["ID"].ToString();
                    product.ProductName = reader["PName"].ToString();
                    product.Description = reader["PDescription"].ToString();
                    product.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                    product.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
                    // Add to the lsit
                    products.Add(product);
                }
            }
            return products;
        }
        public static int getAvalableProducts(string WHID)
        {
            String sql = @"SELECT SUM([Stock].Quantity) as totalitem FROM [dbo].[Stock] where [Stock].WHID='" + WHID + "'";
            int totalitems = 0;
            using (SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    totalitems = int.Parse(reader["totalitem"].ToString());
                }
            }
            return totalitems;
        }
        
    }
}
