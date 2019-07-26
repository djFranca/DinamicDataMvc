#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d26659c3daad887aec90f27431c22fce0781052b"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d26659c3daad887aec90f27431c22fce0781052b", @"/Views/Metadata/GetDetailsByVersion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_Metadata_GetDetailsByVersion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DinamicDataMvc.Models.Process.ViewProcessModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(615, 531, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d26659c3daad887aec90f27431c22fce0781052b4550", async() => {
                BeginContext(621, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(1101, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d26659c3daad887aec90f27431c22fce0781052b5429", async() => {
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
                BeginContext(1137, 2, true);
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
            BeginContext(1146, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1148, 4095, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d26659c3daad887aec90f27431c22fce0781052b7482", async() => {
                BeginContext(1154, 185, true);
                WriteLiteral("\r\n    <section id=\"ProcessNameTag\">\r\n        <hr />\r\n        <div class=\"container\" style=\"background-color:darkorange\">\r\n            <h2 style=\"color:white; text-align:right;\">Process ");
                EndContext();
                BeginContext(1340, 19, false);
#line 37 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                                          Write(Model.Metadata.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1359, 219, true);
                WriteLiteral("</h2>\r\n        </div>\r\n        <hr />\r\n    </section>\r\n    <section id=\"ProcessMetadata\">\r\n        <div class=\"container\" style=\"text-align:center\">\r\n            <span>\r\n                <label><strong>Version: </strong>");
                EndContext();
                BeginContext(1579, 33, false);
#line 44 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                            Write(Model.Metadata.Version.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(1612, 65, true);
                WriteLiteral("</label>\r\n                <label><strong>Creation Date: </strong>");
                EndContext();
                BeginContext(1678, 47, false);
#line 45 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                                  Write(Model.Metadata.Date.ToString().Substring(0, 10));

#line default
#line hidden
                EndContext();
                BeginContext(1725, 89, true);
                WriteLiteral("</label>\r\n                <label><strong>Branches: </strong></label>\r\n                <i>");
                EndContext();
                BeginContext(1815, 26, false);
#line 47 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
              Write(Html.Label("Development "));

#line default
#line hidden
                EndContext();
                BeginContext(1841, 22, true);
                WriteLiteral("</i>\r\n                ");
                EndContext();
                BeginContext(1864, 79, false);
#line 48 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
           Write(Html.CheckBox("Development", @branchesState[0], new { @disabled = "disabled" }));

#line default
#line hidden
                EndContext();
                BeginContext(1943, 21, true);
                WriteLiteral("\r\n                <i>");
                EndContext();
                BeginContext(1965, 22, false);
#line 49 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
              Write(Html.Label("Quality "));

#line default
#line hidden
                EndContext();
                BeginContext(1987, 22, true);
                WriteLiteral("</i>\r\n                ");
                EndContext();
                BeginContext(2010, 75, false);
#line 50 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
           Write(Html.CheckBox("Quality", @branchesState[1], new { @disabled = "disabled" }));

#line default
#line hidden
                EndContext();
                BeginContext(2085, 21, true);
                WriteLiteral("\r\n                <i>");
                EndContext();
                BeginContext(2107, 25, false);
#line 51 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
              Write(Html.Label("Production "));

#line default
#line hidden
                EndContext();
                BeginContext(2132, 22, true);
                WriteLiteral("</i>\r\n                ");
                EndContext();
                BeginContext(2155, 78, false);
#line 52 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
           Write(Html.CheckBox("Production", @branchesState[2], new { @disabled = "disabled" }));

#line default
#line hidden
                EndContext();
                BeginContext(2233, 45, true);
                WriteLiteral("\r\n            <label><strong>State: </strong>");
                EndContext();
                BeginContext(2279, 13, false);
#line 53 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                      Write(ViewBag.State);

#line default
#line hidden
                EndContext();
                BeginContext(2292, 699, true);
                WriteLiteral(@"</label>
            </span>
        </div>
    </section>
    <section id=""ProcessFieldsTag"">
        <hr />
        <div class=""container"" style=""background-color:darkorange"">
            <h2 style=""color:white; text-align:right;"">Process Fields</h2>
        </div>
        <hr />
    </section>
    <section id=""ProcessFields"">
        <div class=""container"">
            <div class=""table-responsive table-striped"">
                <table class=""table table-bordered"" border=""1"" style=""border-style:dotted"">
                    <thead>
                        <tr style=""background-color:#212529; color:white;"">
                            <th>
                                ");
                EndContext();
                BeginContext(2992, 60, false);
#line 71 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                           Write(Html.DisplayNameFor(model => model.Fields.ElementAt(0).Name));

#line default
#line hidden
                EndContext();
                BeginContext(3052, 103, true);
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
                EndContext();
                BeginContext(3156, 60, false);
#line 74 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                           Write(Html.DisplayNameFor(model => model.Fields.ElementAt(0).Type));

#line default
#line hidden
                EndContext();
                BeginContext(3216, 103, true);
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
                EndContext();
                BeginContext(3320, 60, false);
#line 77 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                           Write(Html.DisplayNameFor(model => model.Fields.ElementAt(0).Date));

#line default
#line hidden
                EndContext();
                BeginContext(3380, 103, true);
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
                EndContext();
                BeginContext(3484, 30, false);
#line 80 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                           Write(Html.DisplayName("Properties"));

#line default
#line hidden
                EndContext();
                BeginContext(3514, 127, true);
                WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
                EndContext();
#line 85 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                         foreach (var field in Model.Fields)
                        {

#line default
#line hidden
                BeginContext(3730, 111, true);
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <b>");
                EndContext();
                BeginContext(3842, 40, false);
#line 89 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                  Write(Html.DisplayFor(modelItem => field.Name));

#line default
#line hidden
                EndContext();
                BeginContext(3882, 119, true);
                WriteLiteral("</b>\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(4002, 40, false);
#line 92 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                               Write(Html.DisplayFor(modelItem => field.Type));

#line default
#line hidden
                EndContext();
                BeginContext(4042, 115, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(4158, 40, false);
#line 95 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                               Write(Html.DisplayFor(modelItem => field.Date));

#line default
#line hidden
                EndContext();
                BeginContext(4198, 94, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td align=\"center\">\r\n");
                EndContext();
#line 98 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                     using (Html.BeginForm("DisplayProperties", "Properties", new { Properties = @Model.Properties }, FormMethod.Get))
                                    {

#line default
#line hidden
                BeginContext(4483, 98, true);
                WriteLiteral("                                        <button type=\"submit\"><i class=\"fa fa-key\"></i></button>\r\n");
                EndContext();
#line 101 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                                    }

#line default
#line hidden
                BeginContext(4620, 74, true);
                WriteLiteral("                                </td>\r\n                            </tr>\r\n");
                EndContext();
#line 104 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
                        }

#line default
#line hidden
                BeginContext(4721, 156, true);
                WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </section>\r\n    <section>\r\n        <div class=\"container\">\r\n");
                EndContext();
#line 112 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
             using (Html.BeginForm("Read", "Metadata", FormMethod.Get))
            {

#line default
#line hidden
                BeginContext(4965, 224, true);
                WriteLiteral("                <span>\r\n                    <label class=\"form-group\" style=\"color:darkorange\"><strong>Back to List</strong></label>\r\n                    <button><i class=\"fa fa-list\"></i></button>\r\n                </span>\r\n");
                EndContext();
#line 118 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByVersion.cshtml"
            }

#line default
#line hidden
                BeginContext(5204, 32, true);
                WriteLiteral("        </div>\r\n    </section>\r\n");
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
            BeginContext(5243, 2, true);
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
