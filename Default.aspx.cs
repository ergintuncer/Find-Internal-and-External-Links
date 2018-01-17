using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    WebClient webClient = new WebClient();
    string pattern = "(http(s)?://.*?>.*?)";
    MatchCollection linkListCollection, linkListPagesCollection;
    private int linkNumber = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        table.Visible = false; //this hide all tools in table
    }


    protected void btnFind_Click(object sender, EventArgs e)
    {
        table.Visible = true; //Makes all tools visible

        /* Clear all listBox*/
        listInternalLinks.Items.Clear();
        listExternalLinks.Items.Clear();
        try
        {
            string Url = webClient.DownloadString(txtUrl.Text); /*Download all page as String*/
            linkListCollection = Regex.Matches(Url, pattern); /*Get all link in Url String*/

            foreach (Match match in linkListCollection) /*Loop for each url  at main Page*/
            {
                if (match.Value.Contains(txtUrl.Text)) /*if its look like our url. This mean is internal link*/
                {
/*Add main page internal url to internal list*/
                    listInternalLinks.Items.Add(clearUrl(match.Value));

                    string UrlinPages = webClient.DownloadString(clearUrl(match.Value));
                    linkListCollection = Regex.Matches(UrlinPages, pattern);

                    foreach (Match matchPages in linkListCollection) /*Loop for each url  in internal url*/
                    {
                        if (matchPages.Value.Contains(txtUrl.Text))
                        {
/*Add to interal list*/
                            listInternalLinks.Items.Add(clearUrl(matchPages.Value));
                        }
                        else
                        {
                            /*Add to external list*/
                            listExternalLinks.Items.Add(clearUrl(matchPages.Value));
                        }
                       
                    }
                    listInternalLinks.Items.Add(" ");
                    listExternalLinks.Items.Add(" ");
                }
                else
                {
/*Add main page external url to external list*/
                    listExternalLinks.Items.Add(clearUrl(match.Value));
                }
                linkNumber++;
                if (linkNumber > 30)
                {
                    break;
                }
            }
        }
        catch (Exception exception)
        {
            /*get Exception if url is 404 not found*/
        }
    }

    private string clearUrl(String url)
    {
/*this function returns url without " and  > and "/ 
        if we fix the patern then we don't need this function*/
        return url.Replace("\" /", "").Replace(">", "").Replace("\"", "");
    }
}