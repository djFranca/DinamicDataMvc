#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9d3621720fbae61b4edcbe3f45b077f9745ef28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Metadata_Read), @"mvc.1.0.view", @"/Views/Metadata/Read.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Metadata/Read.cshtml", typeof(AspNetCore.Views_Metadata_Read))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9d3621720fbae61b4edcbe3f45b077f9745ef28", @"/Views/Metadata/Read.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Metadata_Read : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.Metadata.ViewMetadataModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/PageStyleFile.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Metadata", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Read", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString(" return ValidateSearch(); "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
  
    var version = ViewBag.Version;

    if (version == null)
    {
        version = "1";
    }

    var name = ViewBag.Name;
    var pageNumber = ViewBag.NumberOfPages;

#line default
#line hidden
            BeginContext(256, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(258, 592, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9d3621720fbae61b4edcbe3f45b077f9745ef286505", async() => {
                BeginContext(264, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(744, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9d3621720fbae61b4edcbe3f45b077f9745ef287383", async() => {
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
                BeginContext(780, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(786, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c9d3621720fbae61b4edcbe3f45b077f9745ef288636", async() => {
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
                BeginContext(841, 2, true);
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
            BeginContext(850, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(852, 5137, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9d3621720fbae61b4edcbe3f45b077f9745ef2810765", async() => {
                BeginContext(858, 369, true);
                WriteLiteral(@"
    <hr />
    <div class=""container"" id=""subtitleDiv"">
        <h2 id=""ProcessDescription"">Process Metadata</h2>
    </div>
    <hr />
    <div class=""container"" id=""linkDiv"">
        <a id=""CreateLink"" href=""/Metadata/Create/""><i class=""fa fa-database""></i> Create New Process </a>
    </div>
    <hr />
    <div class=""container"" id=""searchDiv"">
        ");
                EndContext();
                BeginContext(1227, 709, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9d3621720fbae61b4edcbe3f45b077f9745ef2811537", async() => {
                    BeginContext(1344, 110, true);
                    WriteLiteral("\r\n            <div class=\"align-content-center\">\r\n                <label><b>Name</b></label>\r\n                ");
                    EndContext();
                    BeginContext(1455, 58, false);
#line 37 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
           Write(Html.TextBox("Name", name as string, new { @size = "50" }));

#line default
#line hidden
                    EndContext();
                    BeginContext(1513, 49, true);
                    WriteLiteral("\r\n                <label><b>Version</b></label>\r\n");
                    EndContext();
                    BeginContext(1648, 99, true);
                    WriteLiteral("                <input type=\"number\" min=\"1\" max=\"500\" name=\"version\" size=\"4\" />\r\n                ");
                    EndContext();
                    BeginContext(1748, 74, false);
#line 41 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
           Write(Html.TextBox("PageNumber", pageNumber as string, new { @type = "hidden" }));

#line default
#line hidden
                    EndContext();
                    BeginContext(1822, 107, true);
                    WriteLiteral("\r\n                <button type=\"submit\"><i class=\"fa fa-search\"></i></button>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1936, 308, true);
                WriteLiteral(@"
    </div>
    <div class=""container"">
        <div class=""table-responsive table-striped"">
            <table class=""table table-bordered"" border=""1"" id=""processResultTable"">
                <thead>
                    <tr id=""tableHeader"">
                        <th>
                            ");
                EndContext();
                BeginContext(2245, 53, false);
#line 52 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                       Write(Html.DisplayNameFor(model => Model.ElementAt(0).Name));

#line default
#line hidden
                EndContext();
                BeginContext(2298, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2390, 56, false);
#line 55 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                       Write(Html.DisplayNameFor(model => Model.ElementAt(0).Version));

#line default
#line hidden
                EndContext();
                BeginContext(2446, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2538, 53, false);
#line 58 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                       Write(Html.DisplayNameFor(model => Model.ElementAt(0).Date));

#line default
#line hidden
                EndContext();
                BeginContext(2591, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2683, 55, false);
#line 61 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                       Write(Html.DisplayNameFor(model => Model.ElementAt(0).Branch));

#line default
#line hidden
                EndContext();
                BeginContext(2738, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2830, 54, false);
#line 64 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                       Write(Html.DisplayNameFor(model => Model.ElementAt(0).State));

#line default
#line hidden
                EndContext();
                BeginContext(2884, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2976, 34, false);
#line 67 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                       Write(Html.DisplayName("Delete Process"));

#line default
#line hidden
                EndContext();
                BeginContext(3010, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(3102, 32, false);
#line 70 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                       Write(Html.DisplayName("Preview Form"));

#line default
#line hidden
                EndContext();
                BeginContext(3134, 111, true);
                WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
                EndContext();
#line 75 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                     foreach (var data in Model)
                    {

#line default
#line hidden
                BeginContext(3318, 111, true);
                WriteLiteral("                        <tr id=\"tableBody\">\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(3430, 149, false);
#line 79 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                           Write(Html.ActionLink(@Html.DisplayTextFor(model => data.Name), "GetDetailsByName", "Metadata", new { Name = data.Name }, new { @class = "processDetails"}));

#line default
#line hidden
                EndContext();
                BeginContext(3579, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(3683, 151, false);
#line 82 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                           Write(Html.ActionLink(@Html.DisplayTextFor(model => data.Version), "GetDetailsByVersion", "Metadata", new { ID = data.Id }, new { @class = "processDetails"}));

#line default
#line hidden
                EndContext();
                BeginContext(3834, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(3938, 39, false);
#line 85 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                           Write(Html.DisplayTextFor(model => data.Date));

#line default
#line hidden
                EndContext();
                BeginContext(3977, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(4081, 41, false);
#line 88 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                           Write(Html.DisplayTextFor(model => data.Branch));

#line default
#line hidden
                EndContext();
                BeginContext(4122, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(4226, 40, false);
#line 91 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                           Write(Html.DisplayTextFor(model => data.State));

#line default
#line hidden
                EndContext();
                BeginContext(4266, 87, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td id=\"deleteIcon\">\r\n");
                EndContext();
#line 94 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                 if (data.State.Length > 0)
                                {
                                    

#line default
#line hidden
#line 96 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                     using (Html.BeginForm("Delete", "Metadata", new { ID = data.Id }, FormMethod.Post))
                                    {

#line default
#line hidden
                BeginContext(4610, 100, true);
                WriteLiteral("                                        <button type=\"submit\"><i class=\"fa fa-trash\"></i></button>\r\n");
                EndContext();
#line 99 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                    }

#line default
#line hidden
#line 99 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                     
                                }

#line default
#line hidden
                BeginContext(4784, 69, true);
                WriteLiteral("                            </td>\r\n                            <td>\r\n");
                EndContext();
#line 103 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                 if (data.State.Length > 0)
                                {
                                    

#line default
#line hidden
#line 105 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                     using (Html.BeginForm("SelectBranch", "Metadata", new { processId = data.Id, processName = data.Name, processVersion = data.Version, processDate = data.Date, processBranches = data.Branch, processState = data.State, isEditable = "true" }, FormMethod.Post))
                                    {

#line default
#line hidden
                BeginContext(5283, 98, true);
                WriteLiteral("                                        <button type=\"submit\"><i class=\"fa fa-eye\"></i></button>\r\n");
                EndContext();
#line 108 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                    }

#line default
#line hidden
#line 108 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                     
                                }

#line default
#line hidden
                BeginContext(5455, 66, true);
                WriteLiteral("                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 112 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                    }

#line default
#line hidden
                BeginContext(5544, 152, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <div class=\"container\">\r\n        <ul class=\"pagination pagination-sm\">\r\n");
                EndContext();
#line 119 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
             for (int i = 1; i <= Convert.ToInt32(pageNumber); i++)
            {

#line default
#line hidden
                BeginContext(5780, 81, true);
                WriteLiteral("                <li class=\"page-item\"><a class=\"page-link\" style=\"color:#212529;\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 5861, "\"", 5918, 6);
                WriteAttributeValue("", 5868, "/Metadata/Read?Name=", 5868, 20, true);
#line 121 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
WriteAttributeValue("", 5888, name, 5888, 5, false);

#line default
#line hidden
                WriteAttributeValue("", 5893, "&Version=", 5893, 9, true);
#line 121 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
WriteAttributeValue("", 5902, version, 5902, 8, false);

#line default
#line hidden
                WriteAttributeValue("", 5910, "&Page=", 5910, 6, true);
#line 121 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
WriteAttributeValue("", 5916, i, 5916, 2, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5919, 4, true);
                WriteLiteral("><b>");
                EndContext();
                BeginContext(5924, 1, false);
#line 121 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
                                                                                                                                          Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(5925, 15, true);
                WriteLiteral("</b></a></li>\r\n");
                EndContext();
#line 122 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\Read.cshtml"
            }

#line default
#line hidden
                BeginContext(5955, 27, true);
                WriteLiteral("        </ul>\r\n    </div>\r\n");
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
            BeginContext(5989, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.Metadata.ViewMetadataModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
