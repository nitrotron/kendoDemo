using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DummyData
/// </summary>
public class DummyData
{
    #region Properties
    public int SysID;
    public string MatterNumber;
    public string MatterDescription;
    public string Notes;
    public string DueDate;
    #endregion

    #region Potential MatterDescriptions
    public static string[] posMatterDescriptions = new string[] {
        "Bacon ipsum dolor amet kevin filet mignon landjaeger",
        "sausage jowl pork chop porchetta, cupim pork swine ham hock",
        "ribeye venison turducken. Jowl alcatra bresaola boudin cupim pork chop",
        "corned beef. Spare ribs tenderloin meatloaf tail meatball",
        "ribeye ham hock turkey pastrami. ",
        "Ball tip bacon bresaola meatloaf, rump cupim tail tri-tip",
        "pork loin beef pastrami. Shank shankle ground round corned beef tenderloin.",
        "Cupim salami short loin tri-tip tenderloin. ",
        "Ham hock tri-tip strip steak picanha frankfurter, landjaeger filet mignon. ",
        "Strip steak drumstick shankle doner sirloin ground round pork kevin short ribs shoulder.",
        "Capicola ham ribeye meatloaf venison shankle shoulder tail chuck short loin.", 
        "Strip steak porchetta swine, corned beef short ribs beef ribs cow leberkas beef fatback ball tip capicola venison filet mignon.",
        "Short loin turkey fatback, shank prosciutto shankle venison swine sirloin strip steak chicken boudin jerky cupim."
    };
    #endregion
    #region Potential MatterNotes
    public static string[] posMatterNotes = new string[] {
     "Don't look behind you",
     "I love meat",
     "That doesn't kill you makes you stronger, except for a desk job"
    };
    #endregion

    public DummyData()
    {
    }


    public static DummyData CreateRandomData(int seeder = 99)
    {
        DummyData myData = new DummyData();

        Random seed = new Random(seeder);
        
        myData.SysID = seed.Next(1, 5000);
        myData.MatterNumber = seed.Next(1, 50).ToString() + ".UI" + seed.Next(1, 500).ToString();
        myData.MatterDescription = posMatterDescriptions[seed.Next(0, posMatterDescriptions.Count())];
        if (seed.Next(1, 10) > 8)
        {
            myData.Notes = posMatterNotes[seed.Next(0, posMatterNotes.Count())];
        }
        else
        {
            myData.Notes = string.Empty;
        }

        myData.DueDate = DateTime.Now.AddDays(seed.Next(1, 7)).ToShortDateString();

        return myData;

    }

    public static List<DummyData> CreateLotsOfRandomData(int howMuchData)
    {
        List<DummyData> rList = new List<DummyData>();

        for (int i = 0; i < howMuchData; i++)
        {
            rList.Add(CreateRandomData(i));
        }

        return rList;
    }
}