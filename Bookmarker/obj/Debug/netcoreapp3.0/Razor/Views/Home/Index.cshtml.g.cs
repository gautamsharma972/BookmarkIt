#pragma checksum "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33c46d7f2623b5dd76f279994b16e5a72481be96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "I:\Sujay\Bookmarker\Bookmarker\Views\_ViewImports.cshtml"
using Bookmarker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "I:\Sujay\Bookmarker\Bookmarker\Views\_ViewImports.cshtml"
using Bookmarker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33c46d7f2623b5dd76f279994b16e5a72481be96", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e893e77b9f8a939c6d539cd7eec8c825d0eb8a62", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("register"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";
    ViewData["Description"] = "Your digital Bookmarklet - Bookmark anything, access anywhere.";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""jumbotron jumbotron-fluid mb-3 pt-0 pb-0 bg-white position-relative"">
        <div class=""pl-4 pr-0 h-100 tofront"">
            <div class=""row justify-content-between"">
                <div class=""col-md-12 pt-6 pb-6 align-self-center text-center"">
                    <div class=""col-lg-12 col-md-12"">
                        <h1 class=""secondfont mb-3 font-weight-bold"">Why create Bookmarks everywhere when you can access all of them here.</h1>
                    </div>

                    <p class=""mb-3"">
                        With BookmarkIt, you can create or add bookmarks from any site of any type, articles, stories, videos, etc, and you can access all of
                        them here using you BookmarkIt account. Stay focused on your craft, continue your bookmarks.
                    </p>
                    <a");
            BeginWriteAttribute("href", " href=\"", 1027, "\"", 1050, 1);
#nullable restore
#line 19 "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml"
WriteAttributeValue("", 1034, Href("~/About"), 1034, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-dark"">Read More</a>
                </div>

            </div>
        </div>
    </div>
</div>


<div class=""container-fluid"">
    
        <div class=""jumbotron jumbotron-fluid mb-3 pt-0 pb-0 bg-lightblue position-relative"">
            <div class=""pl-4 pr-0 h-100 tofront"">
                <div class=""row justify-content-between"">
                    <div class=""col-md-6 pt-6 pb-6 align-self-center"">
                        <div class=""pl-5"">
                            <div class=""pl-1"">
                                <div class=""col-sm-12"">
                                    <h1 class=""secondfont mb-3 font-weight-bold"">
                                        BookmarkIt is for everyone!
                                    </h1>


                                    <p class=""mb-3"">
                                        A simple plugin, that can be embedded, to add BookmarkIt in your site, read our Developer guidelines.
                                    </p>
");
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2113, "\"", 2146, 1);
#nullable restore
#line 45 "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml"
WriteAttributeValue("", 2120, Href("~/About#developer"), 2120, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-dark"">Take me there</a>
                                </div>
                              
                            </div>
                           
                        </div>
                       
                    </div>
                    <div class=""col-md-6 d-none d-md-block pr-0"" style=""background-size:cover;background-image:url(./assets/bookmarks-able.jpg);"">	</div>
                </div>
            </div>
        </div>
      
  
</div>

<div class=""container"">
    <div class=""jumbotron jumbotron-fluid mb-3 pt-0 pb-0 bg-white position-relative"">
        <div class=""pl-4 pr-0 h-100 tofront"">
            <div class=""row justify-content-between"">
                <div class=""col-md-12 pt-6 pb-6 align-self-center text-center"">



");
#nullable restore
#line 69 "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml"
                     if (User.Identity.IsAuthenticated)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"mb-3\">\r\n                            <a class=\"btn btn-dark\"");
            BeginWriteAttribute("href", " href=\"", 3121, "\"", 3148, 1);
#nullable restore
#line 72 "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml"
WriteAttributeValue("", 3128, Href("~/Bookmarks"), 3128, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">See all your Bookmarks here</a>\r\n                        </p>\r\n");
#nullable restore
#line 74 "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-lg-12 col-md-12"">
                            <h1 class=""secondfont mb-3 font-weight-bold"">
                                Join now to see all your Bookmarks
                            </h1>
                        </div>
                        <p class=""mb-3"">
                            <span>Haven't registered yet? Join now and BookmarkIt.</span>
                        </p>
");
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33c46d7f2623b5dd76f279994b16e5a72481be969593", async() => {
                WriteLiteral("Get Started");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 87 "I:\Sujay\Bookmarker\Bookmarker\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Bookmarker.Helpers.ICurrentUser _loggedUser { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591