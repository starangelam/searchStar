using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] files = Directory.GetFiles(Utils.GetTextFilePhysicalDir());

            string filename = Utils.GetTextFilePhysicalDir() + "/al-Assad.txt";
            tb_viewer.Text = File.ReadAllText(filename);
        }
    }

    protected void SubmitSearch(object sender, EventArgs e)
    {
        String userInput = tb_search.Text;
        String[] searchTerms = userInput.Split(null);
        List<String> validSearchTerms = new List<string>();
        String[] allTextFiles = Directory.GetFiles(Utils.GetTextFilePhysicalDir());
        String[] validTextFiles;
        int matchingTerms;

        //Remove excluded terms from searchTerms
        foreach (string term in searchTerms)
        {
            if (!File.ReadAllText(Utils.GetExclusionFile()).Contains(term))
            {
                validSearchTerms.Add(term);
            }
        }
        //For each file in the directory
            //For each search term
                //Does the file contain the search term?
                //If yes: matchingTerms++, else: break
            //If matchingTerms == searchTerms length, add current text to validTextFiles
        //int Vara = File.ReadAllText(path).Contains("mystring") ? 1 : 0;


        tb_viewer.Text = validSearchTerms.ToString();
    }
}