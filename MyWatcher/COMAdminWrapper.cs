using System;
using COMAdmin;
using System.Runtime.InteropServices;

namespace COMAdminWrapper
{
    public class Subscriptions
    {
        public static string g_strPUBID = "PublisherID";
        public static string g_strNAME = "Name";
        public static string g_strVALUE = "Value";
        public static string g_strECID = "EventCLSID";
        public static string g_strIID = "InterfaceID";
        public static string g_strMETHOD = "MethodName";
        public static string g_strCRITERIA = "FilterCriteria";
        public static string g_strTRANSSUB = "TransientSubscriptions";
        public static string g_strSUBINT = "SubscriberInterface";
        public static string g_strTRANSPUBPROP = "TransientPublisherProperties";
        public enum ADMINTYPE
        {
            APPLICATION = 0,
            COMPONENT,
            SUBSCRIPTION,
            TRANSIENTSUB,
            PUBPROP,
            TRANSIENTPUBPROP,
        } ;

        public static void AddTransientSubscription(ICOMAdminCatalog pICat,
            string strSubName, string strECID, string strPubID, string strIID, object punk,
            string strMethod, string strCriteria, string strPubProp, string strPubVal)
        {

            ICatalogObject pISub = null, pIProp = null;
            ICatalogCollection pISubs = null, pIProps = null;
            int lret = 0;
            bool fCreate = false;

            try
            {

                if (pICat == null || strSubName == null || punk == null)
                    throw new Exception("Bad parameters");

                pISubs = (ICatalogCollection)pICat.GetCollection(g_strTRANSSUB);
                if (pISubs == null)
                    throw new Exception("Collection not found");

                pISub = (ICatalogObject)pISubs.Add();
                if (pISub == null)
                    throw new Exception("Could not add item to collection");

                pISub.set_Value(g_strNAME, strSubName);
                pISub.set_Value(g_strECID, strECID);
                pISub.set_Value(g_strIID, strIID);
                pISub.set_Value(g_strSUBINT, punk);
                if (strPubID != null)
                    pISub.set_Value(g_strPUBID, strPubID);
                if (strMethod != null)
                    pISub.set_Value(g_strMETHOD, strMethod);
                if (strCriteria != null)
                    pISub.set_Value(g_strCRITERIA, strCriteria);
                lret = pISubs.SaveChanges();

                fCreate = true;

                if (strPubProp != null && strPubVal != null)
                {

                    object var = pISub.Key;
                    pIProps = (ICatalogCollection)pISubs.GetCollection(g_strTRANSPUBPROP, var);
                    if (pIProps == null)
                        throw new Exception("Collection not found");
                    pIProps.Populate();
                    pIProp.set_Value(g_strNAME, strPubProp);
                    pIProp.set_Value(g_strVALUE, strPubVal);
                    lret = pIProps.SaveChanges();
                }

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (fCreate)
                    RemoveTransientSubscription(pICat, strSubName);
            }
        }

        public static void RemoveTransientSubscription(ICOMAdminCatalog pICat, string strName)
        {
            ICatalogCollection pISubs = null;

            if (pICat == null || strName == null)
                throw new Exception("Invalid args");

            pISubs = (ICatalogCollection)pICat.GetCollection(g_strTRANSSUB);
            pISubs.Populate();

            RemoveNamedObjectFromCollection(pISubs, strName, ADMINTYPE.TRANSIENTSUB);
        }

        public static void RemoveNamedObjectFromCollection(ICatalogCollection pICol, string szObjectName, ADMINTYPE type)
        {
            ICatalogObject pICatObj = null;
            int key = 0, lTotal;

            if (szObjectName != "*")
            {
                if (GetNamedObjectFromCollection(pICol, szObjectName, ref pICatObj, ref key, type, null))
                {
                    pICol.Remove(key);
                    key = pICol.SaveChanges();
                }
            }
            else
            {
                lTotal = pICol.Count;
                for (key = lTotal - 1; key >= 0; key--)
                {
                    pICol.Remove(key);
                    key = pICol.SaveChanges();
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // Name			: GetNamedObjectFromCollection
        // Purppose		: Gets an object from a collection
        // Parameters	:
        //				: ICatalogCollection* pIParentColl		- Collection from the object has to be 
        //														  retrieved
        //				: BSTR bstrObjName						- Object name
        //				: ADMINTYPE type						- type of the object
        //				: ICatalogObject** ppObj				- return Object
        //				: LONG* plIndex							- Index of the object (-1, if not found)
        //				: ADMINTYPE type						- type of the object
        //				: BSTR bstrPropname						- name of the property
        // Return Value : HRESULT
        ////////////////////////////////////////////////////////////////////////////////////////////////////	
        static bool GetNamedObjectFromCollection(ICatalogCollection pCol, string bstrObjName, ref ICatalogObject ppObj,
            ref int plIndex, ADMINTYPE type, string bstrPropname)
        {
            int lCount = 0;
            int i = 0;
            ICatalogObject pObj = null;
            string bstrName;
            string varProp;

            if (pCol == null || bstrObjName == null)
                new Exception("Invalid args");

            if (bstrPropname == null)
            {
                bstrName = g_strNAME;
            }
            else
                bstrName = bstrPropname;

            ppObj = null;

            pCol.Populate();
            lCount = pCol.Count;

            if (lCount == 0)
            {
                plIndex = -1; // To indicate that the object is not found in the collection
                return false; //throw new Exception("object not found");
            }

            // Loop through 
            for (i = 0; i < lCount; i++)
            {
                // Get the next item
                pObj = (ICatalogObject)pCol.get_Item(i);

                // Retrieve it's name property
                varProp = (string)pObj.get_Value(bstrName);

                // Check it's name property for a match
                if (bstrObjName == varProp)
                {
                    // Found it!
                    ppObj = pObj;
                    plIndex = i;
                    return true;
                }
            }

            // If we got here then we didn't find it
            plIndex = -1; // To indicate that the object is not found in the collection
            return false;
        }
    }
}