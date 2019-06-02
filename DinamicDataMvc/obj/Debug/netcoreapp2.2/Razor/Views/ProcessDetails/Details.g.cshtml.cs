#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9309379cd53716c7e1d348d88c5e391776f6efa3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProcessDetails_Details), @"mvc.1.0.view", @"/Views/ProcessDetails/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProcessDetails/Details.cshtml", typeof(AspNetCore.Views_ProcessDetails_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9309379cd53716c7e1d348d88c5e391776f6efa3", @"/Views/ProcessDetails/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_ProcessDetails_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.ProcessDetailsModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
  
    ViewData["Title"] = "Process Details";

#line default
#line hidden
            BeginContext(114, 60, true);
            WriteLiteral("<section>\r\n    <div class=\"text-body\">\r\n        <h4>Process ");
            EndContext();
            BeginContext(175, 17, false);
#line 7 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
               Write(Html.ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(192, 154, true);
            WriteLiteral("</h4>\r\n    </div>\r\n    <div>\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(347, 43, false);
#line 14 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Version));

#line default
#line hidden
            EndContext();
            BeginContext(390, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(470, 48, false);
#line 17 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.CreationDate));

#line default
#line hidden
            EndContext();
            BeginContext(518, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(598, 44, false);
#line 20 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Branches));

#line default
#line hidden
            EndContext();
            BeginContext(642, 126, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 26 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(833, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(918, 143, false);
#line 30 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                       Write(Html.ActionLink(@Html.DisplayTextFor(modelItem => item.Version), "ByVersion", "ProcessDetails", new { ID = item.Version, Name = ViewBag.Name }));

#line default
#line hidden
            EndContext();
            BeginContext(1061, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1153, 51, false);
#line 33 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                       Write(Html.DisplayTextFor(modelItem => item.CreationDate));

#line default
#line hidden
            EndContext();
            BeginContext(1204, 63, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 36 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                             foreach(var branch in item.Branches)
                            {

#line default
#line hidden
            BeginContext(1365, 68, true);
            WriteLiteral("                            <span>\r\n                                ");
            EndContext();
            BeginContext(1434, 32, false);
#line 39 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                           Write(Html.DisplayTextFor(s => branch));

#line default
#line hidden
            EndContext();
            BeginContext(1466, 39, true);
            WriteLiteral("\r\n                            </span>\r\n");
            EndContext();
#line 41 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                            }

#line default
#line hidden
            BeginContext(1536, 89, true);
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1626, 65, false);
#line 44 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1691, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 47 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(1770, 66, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.ProcessDetailsModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
