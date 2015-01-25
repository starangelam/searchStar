using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        search(tb_search.Text.Trim());

        loadFile(searchResult[currIndx].Trim());
        setNavBtnState();
        updateLabels();
    }

    protected void btn_start_Click(object sender, EventArgs e)
    {
        currIndx = 0;
        
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

    private void loadFile(string filePath)
    {
        tb_viewer.Text = File.ReadAllText(filePath);
    }

    private void updateLabels()
    {
        lb_docName.Text = Path.GetFileName(searchResult[currIndx]);
        lb_resultTotal.Text = searchResult.Count.ToString();
        lb_resultCurr.Text = (currIndx + 1).ToString();
    }

    private void setNavBtnState()
    {
        if (searchResult.Count == 0)
        {
            btn_start.Enabled = false;
            btn_end.Enabled = false;
            btn_prev.Enabled = false;
            btn_next.Enabled = false;
        }
        else if (currIndx == 0)
        {
            btn_prev.Enabled = false;
        }
        else if (currIndx == (searchResult.Count - 1))
        {
            btn_next.Enabled = false;

        }
        else
        {
            btn_start.Enabled = true;
            btn_end.Enabled = true;
            btn_prev.Enabled = true;
            btn_next.Enabled = true;
        }
    }
}