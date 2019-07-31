#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b6fe962b30cdebc95729821f6e3e6667e31ac17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Metadata_GetDetailsByVersion), @"mvc.1.0.view", @"/Views/Metadata/GetDetailsByVersion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Metadata/GetDetailsByVersion.cshtml", typeof(AspNetCore.Views_Metadata_GetDetailsByVersion))]
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
#line 1 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\_ViewImports.cshtml"
using DinamicDataMvc;

#line default
#line hidden
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\_ViewImports.cshtml"
using DinamicDataMvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b6fe962b30cdebc95729821f6e3e6667e31ac17", @"/Views/Metadata/GetDetailsByVersion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_Metadata_GetDetailsByVersion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DinamicDataMvc.Models.Process.ViewProcessModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/PageStyleFile.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
  
    ViewData["Title"] = "ByVersion";
    var pageNumber = ViewBag.NumberOfPages;
    var processId = ViewBag.Id;

    bool[] branchesState = new bool[3] { false, false, false };

    string[] branchList = ViewBag.Branches.Split(" ");

    foreach (var description in branchList)
    {
        if (description.Equals("Development"))
        {
            branchesState[0] = true;
        }
        else if (description.Equals("Quality"))
        {
            branchesState[1] = true;
        }
        else if (description.Equals("Production"))
        {
            branchesState[2] = true;
        }
    }

#line default
#line hidden
            BeginContext(693, 593, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b6fe962b30cdebc95729821f6e3e6667e31ac175338", async() => {
                BeginContext(699, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(1179, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b6fe962b30cdebc95729821f6e3e6667e31ac176217", async() => {
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
                BeginContext(1215, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1221, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2b6fe962b30cdebc95729821f6e3e6667e31ac177472", async() => {
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
                BeginContext(1277, 2, true);
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
            BeginContext(1286, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1288, 4084, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b6fe962b30cdebc95729821f6e3e6667e31ac179604", async() => {
                BeginContext(1294, 104, true);
                WriteLiteral("\r\n    <hr />\r\n    <div class=\"container\" id=\"subtitleDiv\">\r\n        <h2 id=\"ProcessDescription\">Process ");
                EndContext();
                BeginContext(1399, 19, false);
#line 39 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                       Write(Model.Metadata.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1418, 9, true);
                WriteLiteral(" Version ");
                EndContext();
                BeginContext(1428, 33, false);
#line 39 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                                                    Write(Model.Metadata.Version.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(1461, 147, true);
                WriteLiteral("</h2>\r\n    </div>\r\n    <hr />\r\n    <div class=\"container\" id=\"processDetails\">\r\n        <span>\r\n            <label><strong>Creation Date: </strong>");
                EndContext();
                BeginContext(1609, 47, false);
#line 44 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                              Write(Model.Metadata.Date.ToString().Substring(0, 10));

#line default
#line hidden
                EndContext();
                BeginContext(1656, 81, true);
                WriteLiteral("</label>\r\n            <label><strong>Branches: </strong></label>\r\n            <i>");
                EndContext();
                BeginContext(1738, 26, false);
#line 46 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
          Write(Html.Label("Development "));

#line default
#line hidden
                EndContext();
                BeginContext(1764, 18, true);
                WriteLiteral("</i>\r\n            ");
                EndContext();
                BeginContext(1783, 79, false);
#line 47 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
       Write(Html.CheckBox("Development", @branchesState[0], new { @disabled = "disabled" }));

#line default
#line hidden
                EndContext();
                BeginContext(1862, 17, true);
                WriteLiteral("\r\n            <i>");
                EndContext();
                BeginContext(1880, 22, false);
#line 48 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
          Write(Html.Label("Quality "));

#line default
#line hidden
                EndContext();
                BeginContext(1902, 18, true);
                WriteLiteral("</i>\r\n            ");
                EndContext();
                BeginContext(1921, 75, false);
#line 49 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
       Write(Html.CheckBox("Quality", @branchesState[1], new { @disabled = "disabled" }));

#line default
#line hidden
                EndContext();
                BeginContext(1996, 17, true);
                WriteLiteral("\r\n            <i>");
                EndContext();
                BeginContext(2014, 25, false);
#line 50 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
          Write(Html.Label("Production "));

#line default
#line hidden
                EndContext();
                BeginContext(2039, 18, true);
                WriteLiteral("</i>\r\n            ");
                EndContext();
                BeginContext(2058, 78, false);
#line 51 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
       Write(Html.CheckBox("Production", @branchesState[2], new { @disabled = "disabled" }));

#line default
#line hidden
                EndContext();
                BeginContext(2136, 45, true);
                WriteLiteral("\r\n            <label><strong>State: </strong>");
                EndContext();
                BeginContext(2182, 13, false);
#line 52 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                      Write(ViewBag.State);

#line default
#line hidden
                EndContext();
                BeginContext(2195, 465, true);
                WriteLiteral(@"</label>
        </span>
    </div>
    <hr />
    <div class=""container"" id=""fieldDiv"">
        <h2 id=""FieldDescription""> Fields </h2>
    </div>
    <hr />
    <div class=""container"">
        <div class=""table-responsive table-striped"">
            <table class=""table table-bordered"" border=""1"" style=""border-style:dotted"">
                <thead>
                    <tr id=""tableHeader"">
                        <th>
                            ");
                EndContext();
                BeginContext(2661, 60, false);
#line 66 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                       Write(Html.DisplayNameFor(model => model.Fields.ElementAt(0).Type));

#line default
#line hidden
                EndContext();
                BeginContext(2721, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2813, 60, false);
#line 69 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                       Write(Html.DisplayNameFor(model => model.Fields.ElementAt(0).Name));

#line default
#line hidden
                EndContext();
                BeginContext(2873, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2965, 60, false);
#line 72 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                       Write(Html.DisplayNameFor(model => model.Fields.ElementAt(0).Date));

#line default
#line hidden
                EndContext();
                BeginContext(3025, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(3117, 30, false);
#line 75 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                       Write(Html.DisplayName("Properties"));

#line default
#line hidden
                EndContext();
                BeginContext(3147, 111, true);
                WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
                EndContext();
#line 80 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                     for (int i = 0; i < Model.Fields.Count; i++)
                    {

#line default
#line hidden
                BeginContext(3348, 114, true);
                WriteLiteral("                        <tr id=\"tableBody\">\r\n                            <td>\r\n                                <b>");
                EndContext();
                BeginContext(3463, 60, false);
#line 84 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                              Write(Html.DisplayFor(modelItem => Model.Fields.ElementAt(i).Type));

#line default
#line hidden
                EndContext();
                BeginContext(3523, 107, true);
                WriteLiteral("</b>\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(3631, 60, false);
#line 87 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                           Write(Html.DisplayFor(modelItem => Model.Fields.ElementAt(i).Name));

#line default
#line hidden
                EndContext();
                BeginContext(3691, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(3795, 60, false);
#line 90 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                           Write(Html.DisplayFor(modelItem => Model.Fields.ElementAt(i).Date));

#line default
#line hidden
                EndContext();
                BeginContext(3855, 86, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td align=\"center\">\r\n");
                EndContext();
#line 93 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                 using (Html.BeginForm("Details", "Properties", new { PropertiesId = Model.Fields.ElementAt(i).Properties, ProcessName = Model.Metadata.Name, ProcessVersion = Model.Metadata.Version.ToString(), FieldType = Model.Fields.ElementAt(i).Type, FieldName = Model.Fields.ElementAt(i).Name }, FormMethod.Post))
                                {

#line default
#line hidden
                BeginContext(4311, 57, true);
                WriteLiteral("                                    <button type=\"submit\"");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 4368, "\"", 4375, 1);
#line 95 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
WriteAttributeValue("", 4373, i, 4373, 2, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4376, 37, true);
                WriteLiteral("><i class=\"fa fa-key\"></i></button>\r\n");
                EndContext();
#line 96 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                }

#line default
#line hidden
                BeginContext(4448, 66, true);
                WriteLiteral("                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 99 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                    }

#line default
#line hidden
                BeginContext(4537, 152, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <div class=\"container\">\r\n        <ul class=\"pagination pagination-sm\">\r\n");
                EndContext();
#line 106 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
             for (int i = 1; i <= Convert.ToInt32(pageNumber); i++)
            {

#line default
#line hidden
                BeginContext(4773, 81, true);
                WriteLiteral("                <li class=\"page-item\"><a class=\"page-link\" style=\"color:#212529;\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4854, "\"", 4912, 4);
                WriteAttributeValue("", 4861, "/Metadata/GetDetailsByVersion?ID=", 4861, 33, true);
#line 108 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
WriteAttributeValue("", 4894, processId, 4894, 10, false);

#line default
#line hidden
                WriteAttributeValue("", 4904, "&Page=", 4904, 6, true);
#line 108 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
WriteAttributeValue("", 4910, i, 4910, 2, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4913, 4, true);
                WriteLiteral("><b>");
                EndContext();
                BeginContext(4918, 1, false);
#line 108 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                                                                                                                           Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(4919, 15, true);
                WriteLiteral("</b></a></li>\r\n");
                EndContext();
#line 109 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
            }

#line default
#line hidden
                BeginContext(4949, 89, true);
                WriteLiteral("        </ul>\r\n    </div>\r\n    <div class=\"container\">\r\n        <div class=\"btn-group\">\r\n");
                EndContext();
#line 114 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
             using (Html.BeginForm("Read", "Metadata", FormMethod.Get))
            {

#line default
#line hidden
                BeginContext(5126, 89, true);
                WriteLiteral("                <button type=\"submit\"><i class=\"fa fa-list\"></i> Back to List </button>\r\n");
                EndContext();
#line 117 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
            }

#line default
#line hidden
                BeginContext(5230, 135, true);
                WriteLiteral("            <button type=\"button\" onclick=\"GoBack();\"><i class=\"fa fa-toggle-left\"></i> Go Back </button>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5372, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DinamicDataMvc.Models.Process.ViewProcessModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
