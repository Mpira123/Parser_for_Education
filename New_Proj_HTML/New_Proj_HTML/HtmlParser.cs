using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace New_Proj_HTML
{
    public class HtmlParser
    {
        public static string CleanHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.InnerText.Trim();
        }
        public static List<Company> ParseCompanyData(string[] courseUrls)
        {
            List<Company> companies = new List<Company>();
            HtmlWeb web = new HtmlWeb();

            try
            {
                foreach (string url in courseUrls)
                {
                    HtmlDocument document = web.Load(url);
                    string nameXPathExpression = "//*[@id=\"wrap-content\"]/main/div/section[2]/h1/span/text()";
                    string addressXPathExpression = "//*[@id=\"contacts\"]/li[1]/span[2]/text()";
                    string phoneXPathExpression = "//*[@id=\"_telephone\"]";

                    HtmlNodeCollection nameNodes = document.DocumentNode.SelectNodes(nameXPathExpression);
                    string companyName = nameNodes != null ? CleanHtml(nameNodes[0].InnerHtml) : "Name not found";

                    HtmlNodeCollection addressNodes = document.DocumentNode.SelectNodes(addressXPathExpression);
                    string companyAddress = addressNodes != null ? CleanHtml(addressNodes[0].InnerHtml) : "Address not found";

                    HtmlNodeCollection phoneNodes = document.DocumentNode.SelectNodes(phoneXPathExpression);
                    string companyPhone = phoneNodes != null ? CleanHtml(phoneNodes[0].InnerHtml) : "Phone not found";

                    companies.Add(new Company
                    {
                        Name = companyName,
                        Address = companyAddress,
                        Phone = companyPhone
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return companies;
        }
    }
}
