using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{

    private int currIndx
    {
        get
        {
            object obj = ViewState["currIndx"];
            return (obj == null) ? 0 : (int)obj;
        }
        set
        {
            ViewState["currIndx"] = value;
        }
    }

    private List<string> searchResult
    {
        get
        {
            if (!(ViewState["result"] is List<string>))
            {
                ViewState["result"] = new List<string>();
            }

            return (List<string>)ViewState["result"];
        }
        set
        {
            ViewState["result"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setNavBtnState();
            updateLabels();
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        search(tb_search.Text.Trim());

        //String userInput = tb_search.Text;
        //String[] searchTerms = userInput.Split(null);
        //List<String> validSearchTerms = new List<string>();
        //String[] allTextFiles = Directory.GetFiles(Utils.GetTextFilePhysicalDir());
        //String[] validTextFiles;
        //int matchingTerms;

        ////Remove excluded terms from searchTerms
        //foreach (string term in searchTerms)
        //{
        //    if (!File.ReadAllText(Utils.GetExclusionFile()).Contains(term))
        //    {
        //        validSearchTerms.Add(term);
        //    }
        //}
        ////For each file in the directory
        //    //For each search term
        //        //Does the file contain the search term?
        //        //If yes: matchingTerms++, else: break
        //    //If matchingTerms == searchTerms length, add current text to validTextFiles
        ////int Vara = File.ReadAllText(path).Contains("mystring") ? 1 : 0;


        //tb_viewer.Text = validSearchTerms.ToString();

        loadFile();
        setNavBtnState();
        updateLabels();
    }

    private void search(string keywords)
    {
        string searchDir = ConfigurationManager.AppSettings["searchDir"];
        string projectRoot = MapPath("~");
        string[] toSearch = Directory.GetFiles(projectRoot + searchDir);
        
        // search through files and return a list of file path
        // mock code, pretend this is the search result
        currIndx = 0;
        searchResult = new List<string>(toSearch);
    }

    private void loadFile()
    {
        if (searchResult.Count > 0)
        {
            string filePath = searchResult[currIndx].Trim();
            tb_viewer.Text = File.ReadAllText(filePath);
        }
        else
        {
            tb_viewer.Text = "Keywords not found.";
        }
    }

    private void updateLabels()
    {
        if (searchResult.Count == 0) {
            lb_docName.Text = "---";
            lb_resultCurr.Text = currIndx.ToString();
        }
        else {
            lb_docName.Text = Path.GetFileName(searchResult[currIndx]);
            lb_resultCurr.Text = (currIndx + 1).ToString();
        }
        
        lb_resultTotal.Text = searchResult.Count.ToString();
    }

    private void setNavBtnState()
    {
        // disable all navigation buttons if no search result
        btn_start.Enabled = (searchResult.Count <= 1) ? false : true;
        btn_end.Enabled = (searchResult.Count <= 1) ? false : true;
        btn_prev.Enabled = (searchResult.Count <= 1) ? false : true;
        btn_next.Enabled = (searchResult.Count <= 1) ? false : true;

        // disable prev / next button if at start of list
        if (currIndx == 0)
        {
            btn_prev.Enabled = false;
        }

        if (currIndx == (searchResult.Count - 1))
        {
            btn_next.Enabled = false;
        }

    }

    protected void btn_start_Click(object sender, EventArgs e)
    {
        currIndx = 0;

        loadFile();
        setNavBtnState();
        updateLabels();
    }

    protected void btn_end_Click(object sender, EventArgs e)
    {
        currIndx = searchResult.Count - 1;

        loadFile();
        setNavBtnState();
        updateLabels();
    }

    protected void btn_next_Click(object sender, EventArgs e)
    {
        if (currIndx < (searchResult.Count - 1))
        {
            currIndx++;
        }

        loadFile();
        setNavBtnState();
        updateLabels();
    }

    protected void btn_prev_Click(object sender, EventArgs e)
    {
        if (currIndx > 0)
        {
            currIndx--;
        }

        loadFile();
        setNavBtnState();
        updateLabels();
    }    
}