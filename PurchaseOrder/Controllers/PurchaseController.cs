using PurchaseOrder.Models;
using PurchaseOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseOrder.Controllers
{
    public class PurchaseController : Controller
    {
        ProductOrderRepository oProductOrderRepository = new ProductOrderRepository();

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertDetails(ItemModel oItemModel)
        {
            oProductOrderRepository.AddData(oItemModel);
            return RedirectToAction("GetDetails");
        }
        public ActionResult GetDetails()
        {
            ItemModel oItemModel = new ItemModel();
            oItemModel.PartyNameList = oProductOrderRepository.PartyNameMeth();
            oItemModel.NameList = oProductOrderRepository.ItemNameMeth();
            oItemModel.ItemList = oProductOrderRepository.GetData();
            oItemModel.PartyList = oProductOrderRepository.PartyDataMeth(oItemModel);
            return View(oItemModel);
        }
        public ActionResult DeleteDetails(int ID, ItemModel oItemModel)
        {
            oProductOrderRepository.DeleteEntery(ID);
            return RedirectToAction("GetDetails");
        }
        public ActionResult EditDetails(int ID, ItemModel oItemModel)
        {
            oProductOrderRepository.EditEntery(ID, oItemModel);
            return View("EditDetails", oItemModel);
        }
    }
}