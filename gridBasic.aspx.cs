using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gridBasic : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }


    [WebMethod]
    public static List<DummyData> ToddGrdNeedDataSource()
    {
        //List<ElitePotentialDormantMatterInfo> clMatters = JsonConvert.DeserializeObject<List<ElitePotentialDormantMatterInfo>>(clientMatters);

        //string allGoodUpdates = string.Empty;
        //foreach (ElitePotentialDormantMatterInfo clMatterInfo in clMatters)
        //{
        //    if (!updateMattersAndWasSuccessful(clMatterInfo))
        //    {
        //        allGoodUpdates = clMatterInfo.MatterNum + " " + clMatterInfo.MatterDescription + " errors occured on update";
        //        break;
        //    }
        //}

        //if (!string.IsNullOrWhiteSpace(allGoodUpdates))
        //{
        //    Exception except = new Exception(allGoodUpdates);
        //    throw except;
        //}

        List<DummyData> rList = DummyData.CreateLotsOfRandomData(100);


        return rList;
    }
}