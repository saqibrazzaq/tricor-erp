﻿using Models.Samples;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Samples
{
    /// <summary>
    /// All database related operations related to the customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Search customers
        /// </summary>
        /// <param name="searchtext">search text</param>
        /// <returns>List of customers</returns>
        public static List<CustomerModel> SearchCustomers(String searchtext)
        {
            // Initialize empty list of customers
            List<CustomerModel> customers = new List<CustomerModel>();

            // Prepare the SQL query
            String sql = @"SELECT ID, FullName, CustomerType
                FROM Samples_Customer
                WHERE 1=1";
            // Get datareader
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while(reader.Read())
            {
                // Create a new customer for every record
                CustomerModel customerModel = new CustomerModel();
                customerModel.ID = int.Parse(reader["ID"].ToString());
                customerModel.FullName = reader["FullName"].ToString();
                customerModel.CustomerType = int.Parse(reader["CustomerType"].ToString());
                // Add it to list
                customers.Add(customerModel);
            }

            // return the list
            return customers;
        }

        /// <summary>
        /// Get the String format of the customer type
        /// </summary>
        /// <param name="customerType"></param>
        /// <returns></returns>
        public static String GetCustomerType(int customerType)
        {
            if (customerType == 1)
                return "Individual";
            else if (customerType == 2)
                return "Company";
            else
                return "Unknown";
        }
    }
}
