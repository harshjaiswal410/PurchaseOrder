using PurchaseOrder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PurchaseOrder.Repository
{
    public class ProductOrderRepository
    {
        string Address = "Data source = DESKTOP-8T78S35; Initial Catalog = Company; Integrated Security = SSPI;";

        public List<ItemModel> GetData()
        {
            List<ItemModel> getItem = new List<ItemModel>();
            ItemModel oItemModel = new ItemModel();
            SqlConnection connect = new SqlConnection(Address);
            connect.Open();
            SqlCommand cmd = new SqlCommand("Sp_Product_Order_Details", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader read = cmd.ExecuteReader();
            try
            {
                while (read.Read())
                {
                    ItemModel objItemModel = new ItemModel()
                    {
                        //ItemName = read["Item_Name"].ToString(),
                        DetailsID = Convert.ToInt32(read["PODetailsID"]),
                        Qty = Convert.ToInt32(read["Qty"]),
                        Rate = Convert.ToInt64(read["Rate"]),
                        Amount = Convert.ToInt64(read["Amount"]),
                        DiscPercent = Convert.ToInt64(read["Disc_Percent"]),
                        Discount = Convert.ToInt64(read["Discount"]),
                        Total = Convert.ToInt64(read["Total_Amount"])
                    };
                    getItem.Add(objItemModel);

                }
                
            }
            catch (Exception exe)
            {

            }
            oItemModel.ItemList = getItem;
            return getItem;
        }
        public void AddData(ItemModel oItemModel)
        {
            try
            {
                SqlConnection connect = new SqlConnection(Address);
                connect.Open();

                SqlCommand cmd = new SqlCommand("Sp_Add_Product_Order_Details", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                
                //cmd.Parameters.AddWithValue("", oItemModel.ItemName);
                //cmd.Parameters.AddWithValue("@PODetailsID", oItemModel.Details);
                cmd.Parameters.AddWithValue("@Qty", oItemModel.Qty);
                cmd.Parameters.AddWithValue("@Rate", oItemModel.Rate);
                cmd.Parameters.AddWithValue("@Amount", oItemModel.Amount);
                cmd.Parameters.AddWithValue("@Disc_Percent", oItemModel.DiscPercent);
                cmd.Parameters.AddWithValue("@Discount", oItemModel.Discount);
                cmd.Parameters.AddWithValue("@Total_Amount", oItemModel.Total);

                int x = cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch(Exception exe)
            {

            }
        }

        public List<ItemModel> PartyDataMeth(ItemModel oItemModel)
        {         
            SqlConnection connect = new SqlConnection(Address);
            connect.Open();

            List<ItemModel> GetParty = new List<ItemModel>();
            ItemModel objItemModel = new ItemModel();
            SqlCommand cmd = new SqlCommand("Sp_Get_Party", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", oItemModel.PO_ID);

            SqlDataReader read = cmd.ExecuteReader();
            try
            {
                while (read.Read())
                {
                    ItemModel objItemModel1 = new ItemModel()
                    {
                        PO_Date = Convert.ToDateTime(read["PO_Date"]),
                        Remarks = read["Remarks"].ToString(),
                    };
                    GetParty.Add(objItemModel);
                }
                int x = cmd.ExecuteNonQuery();
                connect.Close();

            }
            catch (Exception exe)
            {
                    
            }
            objItemModel.PartyList = GetParty;
            return GetParty;
        }

        public List<ItemModel> PartyNameMeth()
        {
            List<ItemModel> PartyList = new List<ItemModel>();
            SqlConnection connect = new SqlConnection(Address);
            connect.Open();

            SqlCommand cmd = new SqlCommand("Sp_Get_PartyName", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read1 = cmd.ExecuteReader();

            while (read1.Read())
            {
                ItemModel objItemModel = new ItemModel();

                objItemModel.PartyID = Convert.ToInt32(read1["Party_ID"]);
                objItemModel.PartyName = read1["PartyName"].ToString(); 
                PartyList.Add(objItemModel);
            }

            return PartyList;
        }
        public void DeleteEntery(int ID)
        {
            try
            {
                SqlConnection connect = new SqlConnection(Address);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Sp_Delete_Product_Order_Details", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);

                int x = cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception exe)
            {

            }
        }
        public void EditEntery(int ID, ItemModel oItemModel)
        {
           
                SqlConnection connect = new SqlConnection(Address);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Sp_Update_Product_Order_Details", connect);
                cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataReader read = cmd.ExecuteReader();
            try
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@Qty", oItemModel.Qty);
                cmd.Parameters.AddWithValue("@Rate", oItemModel.Rate);
                cmd.Parameters.AddWithValue("@Amount", oItemModel.Amount);
                cmd.Parameters.AddWithValue("@DiscPercent", oItemModel.DiscPercent);
                cmd.Parameters.AddWithValue("@Discount", oItemModel.Discount);
                cmd.Parameters.AddWithValue("@Total", oItemModel.Total);
                int x = cmd.ExecuteNonQuery();
                connect.Close();
                
            }
            catch (Exception exe)
            {

            }
        }
        public  List<ItemModel> ItemNameMeth()
        {
            List<ItemModel> GetNameList = new List<ItemModel>();
            SqlConnection connect = new SqlConnection(Address);
            connect.Open();

            SqlCommand cmd = new SqlCommand("Sp_Item_info", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read1 = cmd.ExecuteReader();

            while (read1.Read())
            {
                ItemModel objItemModel = new ItemModel();

                objItemModel.ItemId = Convert.ToInt32(read1["Item_ID"]);
                objItemModel.ItemName = read1["Item_Name"].ToString();
                GetNameList.Add(objItemModel);
            }
            
            return GetNameList;
        }
    }
}














