using System;
using System.Collections.Generic;
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
            setAuxiliaryBtnState();
            updateLabels();
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
       searchResult = new List<string>();
       search(tb_search.Text);

       loadFile();
       setAuxiliaryBtnState();
       setNavBtnState();
       updateLabels();
    }

    private void search(string keywords)
    {
        String[] searchTerms = keywords.Split(null);
        List<String> validSearchTerms = new List<string>();
        String[] allTextFiles = Directory.GetFiles(Utils.GetTextFilePhysicalDir());
        int matchingTerms = 0;

        //Remove excluded terms from searchTerms
        foreach (string term in searchTerms)
        {
            if (!File.ReadAllText(Utils.GetExclusionFile()).Contains(term))
            {
                validSearchTerms.Add(term.ToLower());
            }
        }


        foreach (string file in allTextFiles)
        {
            matchingTerms = 0;
            foreach (string term in validSearchTerms)
            {
                //Does the file contain the search term?
                if (File.ReadAllText(file.ToLower()).Contains(term))
                {
                    matchingTerms++;
                }
                else
                {
                    break;
                }
            }
            if (matchingTerms == validSearchTerms.Count)
            {
                searchResult.Add(file);
            }
        }
        
        currIndx = 0;
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

    private void setAuxiliaryBtnState()
    {
        if (searchResult.Count == 0)
        {
            btn_download.Enabled = false;
            btn_print.Enabled = false;
        }
        else
        {
            btn_download.Enabled = true;
            btn_print.Enabled = true;
        }
       
    }

    protected void btn_download_Click(object sender, EventArgs e)
    {
        string filepath = searchResult[currIndx];
        string filename = Path.GetFileName(filepath);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.TransmitFile(filepath);
        Response.End();
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