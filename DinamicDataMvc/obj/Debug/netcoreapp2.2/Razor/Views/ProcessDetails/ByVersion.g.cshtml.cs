#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "242b8bc6dfaa463412f56864d4cdb2245251b69f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProcessDetails_ByVersion), @"mvc.1.0.view", @"/Views/ProcessDetails/ByVersion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProcessDetails/ByVersion.cshtml", typeof(AspNetCore.Views_ProcessDetails_ByVersion))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"242b8bc6dfaa463412f56864d4cdb2245251b69f", @"/Views/ProcessDetails/ByVersion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_ProcessDetails_ByVersion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DinamicDataMvc.Models.ProcessDetailsModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml"
  
    ViewData["Title"] = "ByVersion";

#line default
#line hidden
            BeginContext(97, 79, true);
            WriteLiteral("\r\n<section id=\"ProcessName\">\r\n    <div class=\"text-body\">\r\n        <h4>Process ");
            EndContext();
            BeginContext(177, 17, false);
#line 9 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml"
               Write(Html.ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(194, 92, true);
            WriteLiteral("</h4>\r\n    </div>\r\n</section>\r\n<br />\r\n<section id=\"ProcessHeaderInfo\">\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(287, 50, false);
#line 15 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml"
   Write(await Html.PartialAsync("_ByVersionHeader", Model));

#line default
#line hidden
            EndContext();
            BeginContext(337, 201, true);
            WriteLiteral("\r\n    </div>\r\n</section>\r\n<br />\r\n<section id=\"ProcessDataInfo\">\r\n    <div>\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(539, 24, false);
#line 25 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml"
                   Write(Html.DisplayName("Type"));

#line default
#line hidden
            EndContext();
            BeginContext(563, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(643, 25, false);
#line 28 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml"
                   Write(Html.DisplayName("Field"));

#line default
#line hidden
            EndContext();
            BeginContext(668, 198, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(867, 47, false);
#line 36 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml"
                   Write(Html.DisplayFor(modelItem => modelItem.Version));

#line default
#line hidden
            EndContext();
            BeginContext(914, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(994, 52, false);
#line 39 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\ByVersion.cshtml"
                   Write(Html.DisplayFor(modelItem => modelItem.CreationDate));

#line default
#line hidden
            EndContext();
            BeginContext(1046, 122, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DinamicDataMvc.Models.ProcessDetailsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
