﻿using System;
using HtmlAgilityPack;
using New_Proj_HTML;


public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] courseUrls = { 
            "https://www.education.ua/courses/company/7712/",
            "https://www.education.ua/courses/company/8855/",
            "https://www.education.ua/courses/company/5839/",
            "https://www.education.ua/courses/company/868/",
            "https://www.education.ua/courses/company/8476/",
            "https://www.education.ua/courses/company/3250/",
            "https://www.education.ua/courses/company/5163/",
            "https://www.education.ua/courses/company/30328/",
            "https://www.education.ua/courses/company/31734/",
            "https://www.education.ua/courses/company/5513/",
            "https://www.education.ua/courses/company/29150/",
            "https://www.education.ua/courses/company/33799/",
            "https://www.education.ua/courses/company/29547/",
            "https://www.education.ua/courses/company/34180/",
            "https://www.education.ua/courses/company/2876/",
            "https://www.education.ua/courses/company/33366/",
            "https://www.education.ua/courses/company/2634/",
            "https://www.education.ua/courses/company/819/",
            "https://www.education.ua/courses/company/4500/",
            "https://www.education.ua/courses/company/914/",
            "https://www.education.ua/courses/company/1435/",
            "https://www.education.ua/courses/company/2185/",
            "https://www.education.ua/courses/company/3285/",
        };

        List<New_Proj_HTML.Company> companies = HtmlParser.ParseCompanyData(courseUrls);
        string filePath = "DataBaseCompany.xlsx";  
        ExcelExporter.ExportToExcel(companies, filePath);
    }
}