#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e932dc0e4eb8de5f932d15764c24cbce83cb410f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Data_GetProcessFieldDataByVersions), @"mvc.1.0.view", @"/Views/Data/GetProcessFieldDataByVersions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Data/GetProcessFieldDataByVersions.cshtml", typeof(AspNetCore.Views_Data_GetProcessFieldDataByVersions))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e932dc0e4eb8de5f932d15764c24cbce83cb410f", @"/Views/Data/GetProcessFieldDataByVersions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Data_GetProcessFieldDataByVersions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.Data.ViewDataModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/PageStyleFile.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:ghostwhite"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
  
    ViewData["Title"] = "GetProcessFieldDataByVersions";
    string ProcessName = ViewBag.ProcessName;
    string ProcessVersion = ViewBag.ProcessVersion;
    var pageNumber = ViewBag.NumberOfPages;

#line default
#line hidden
            BeginContext(272, 593, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e932dc0e4eb8de5f932d15764c24cbce83cb410f5055", async() => {
                BeginContext(278, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(758, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e932dc0e4eb8de5f932d15764c24cbce83cb410f5933", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(794, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(800, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e932dc0e4eb8de5f932d15764c24cbce83cb410f7186", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(856, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(865, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(867, 4293, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e932dc0e4eb8de5f932d15764c24cbce83cb410f9315", async() => {
                BeginContext(909, 104, true);
                WriteLiteral("\r\n    <hr />\r\n    <div class=\"container\" id=\"subtitleDiv\">\r\n        <h2 id=\"ProcessDescription\">Process ");
                EndContext();
                BeginContext(1014, 11, false);
#line 20 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                       Write(ProcessName);

#line default
#line hidden
                EndContext();
                BeginContext(1025, 517, true);
                WriteLiteral(@"</h2>
    </div>
    <hr />
    <div class=""container"">
        <button type=""button"" onclick=""GoBack();"" style=""float:right""><i class=""fa fa-toggle-left""> Go Back </i></button>
    </div>
    <br />
    <div class=""container"">
        <br />
        <div class=""table-responsive table-striped"">
            <table class=""table table-bordered"" border=""1"" id=""processResultTable"">
                <thead>
                    <tr id=""tableHeader"">
                        <th>
                            ");
                EndContext();
                BeginContext(1543, 62, false);
#line 34 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).ProcessId));

#line default
#line hidden
                EndContext();
                BeginContext(1605, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1697, 67, false);
#line 37 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).ProcessVersion));

#line default
#line hidden
                EndContext();
                BeginContext(1764, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1856, 66, false);
#line 40 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).ProcessBranch));

#line default
#line hidden
                EndContext();
                BeginContext(1922, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2014, 65, false);
#line 43 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).CreationDate));

#line default
#line hidden
                EndContext();
                BeginContext(2079, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2171, 32, false);
#line 46 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayName("Edit Webform"));

#line default
#line hidden
                EndContext();
                BeginContext(2203, 111, true);
                WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
                EndContext();
#line 51 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                     foreach (var model in Model)
                    {

#line default
#line hidden
                BeginContext(2388, 111, true);
                WriteLiteral("                        <tr id=\"tableBody\">\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2500, 45, false);
#line 55 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                           Write(Html.DisplayFor(modelItem => model.ProcessId));

#line default
#line hidden
                EndContext();
                BeginContext(2545, 71, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
                EndContext();
#line 58 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                 if (model.ProcessVersion > 0)
                                {
                                    

#line default
#line hidden
                BeginContext(2752, 50, false);
#line 60 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                               Write(Html.DisplayFor(modelItem => model.ProcessVersion));

#line default
#line hidden
                EndContext();
#line 60 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                                                                       
                                }

#line default
#line hidden
                BeginContext(2839, 32, true);
                WriteLiteral("                                ");
                EndContext();
#line 62 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                 if (model.ProcessVersion <= 0)
                                {
                                    

#line default
#line hidden
                BeginContext(2976, 30, false);
#line 64 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                               Write(Html.DisplayName(string.Empty));

#line default
#line hidden
                EndContext();
#line 64 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                                                   
                                }

#line default
#line hidden
                BeginContext(3043, 101, true);
                WriteLiteral("                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(3145, 49, false);
#line 68 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                           Write(Html.DisplayFor(modelItem => model.ProcessBranch));

#line default
#line hidden
                EndContext();
                BeginContext(3194, 71, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
                EndContext();
#line 71 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                 if (model.ProcessVersion > 0)
                                {
                                    

#line default
#line hidden
                BeginContext(3401, 48, false);
#line 73 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                               Write(Html.DisplayFor(modelItem => model.CreationDate));

#line default
#line hidden
                EndContext();
#line 73 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                                                                     
                                }

#line default
#line hidden
                BeginContext(3486, 32, true);
                WriteLiteral("                                ");
                EndContext();
#line 75 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                 if (model.ProcessVersion <= 0)
                                {
                                    

#line default
#line hidden
                BeginContext(3623, 30, false);
#line 77 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                               Write(Html.DisplayName(string.Empty));

#line default
#line hidden
                EndContext();
#line 77 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                                                   
                                }

#line default
#line hidden
                BeginContext(3690, 69, true);
                WriteLiteral("                            </td>\r\n                            <td>\r\n");
                EndContext();
#line 81 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                 using (Html.BeginForm("GetStoredWebForm", "Data", new { ObjectId = model.ObjectId, ProcessId = model.ProcessId, ProcessVersion = model.ProcessVersion, ProcessBranch = model.ProcessBranch }, FormMethod.Post))
                                {
                                    

#line default
#line hidden
#line 83 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                     if (model.ProcessVersion <= 0)
                                    {

#line default
#line hidden
                BeginContext(4144, 110, true);
                WriteLiteral("                                        <button type=\"submit\" disabled><i class=\"fa fa-pencil\"></i></button>\r\n");
                EndContext();
#line 86 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                    }

#line default
#line hidden
#line 87 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                     if (model.ProcessVersion > 0)
                                    {

#line default
#line hidden
                BeginContext(4400, 101, true);
                WriteLiteral("                                        <button type=\"submit\"><i class=\"fa fa-pencil\"></i></button>\r\n");
                EndContext();
#line 90 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                    }

#line default
#line hidden
#line 90 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                     
                                }

#line default
#line hidden
                BeginContext(4575, 66, true);
                WriteLiteral("                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 94 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                    }

#line default
#line hidden
                BeginContext(4664, 168, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n        <br />\r\n    </div>\r\n    <div class=\"container\">\r\n        <ul class=\"pagination pagination-sm\">\r\n");
                EndContext();
#line 102 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
             for (int i = 1; i <= Convert.ToInt32(pageNumber); i++)
            {

#line default
#line hidden
                BeginContext(4916, 81, true);
                WriteLiteral("                <li class=\"page-item\"><a class=\"page-link\" style=\"color:#212529;\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4997, "\"", 5089, 6);
                WriteAttributeValue("", 5004, "/Data/GetProcessFieldDataByVersions?Name=", 5004, 41, true);
#line 104 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
WriteAttributeValue("", 5045, ProcessName, 5045, 12, false);

#line default
#line hidden
                WriteAttributeValue("", 5057, "&Version=", 5057, 9, true);
#line 104 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
WriteAttributeValue("", 5066, ProcessVersion, 5066, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 5081, "&Page=", 5081, 6, true);
#line 104 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
WriteAttributeValue("", 5087, i, 5087, 2, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5090, 4, true);
                WriteLiteral("><b>");
                EndContext();
                BeginContext(5095, 1, false);
#line 104 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                                                                                                                                                             Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(5096, 15, true);
                WriteLiteral("</b></a></li>\r\n");
                EndContext();
#line 105 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
            }

#line default
#line hidden
                BeginContext(5126, 27, true);
                WriteLiteral("        </ul>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5160, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.Data.ViewDataModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
