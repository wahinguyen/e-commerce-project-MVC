#pragma checksum "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4b754681237037104f04fdbac78fe032e0f098e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Order_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Order/Detail.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\_ViewImports.cshtml"
using ShopQuanAo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\_ViewImports.cshtml"
using ShopQuanAo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4b754681237037104f04fdbac78fe032e0f098e", @"/Areas/Admin/Views/Order/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63572335f77354d8ba86f03d54b83e002cf2ff90", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Order_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopQuanAo.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Sản phẩm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    <div id=""layoutSidenav_content"">
        <main>
            <div>
                <h3>Chi tiết đơn hàng</h3>
                <hr />
                <div class=""row"">
                    <div class=""col-sm-9"">
                        <dl class=""row"">
                            <dt class=""col-sm-3"">
                                Mã đơn hàng
                            </dt>
                            <dd class=""col-sm-9"">
                                ");
#nullable restore
#line 20 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                           Write(Html.DisplayFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-3\">\r\n                                Tên khách hàng:\r\n                            </dt>\r\n                            <dd class=\"col-sm-9\">\r\n                                ");
#nullable restore
#line 26 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                           Write(Html.DisplayFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-3\">\r\n                                Địa chỉ\r\n                            </dt>\r\n                            <dd class=\"col-sm-9\">\r\n                                ");
#nullable restore
#line 32 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                           Write(Html.DisplayFor(model =>
                                model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-3\">\r\n                                Số điện thoại\r\n                            </dt>\r\n                            <dd class=\"col-sm-9\">\r\n                                ");
#nullable restore
#line 39 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                           Write(Html.DisplayFor(model =>
                                model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-3\">\r\n                                Giá giảm\r\n                            </dt>\r\n                            <dd class=\"col-sm-9\">\r\n                                ");
#nullable restore
#line 46 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                           Write(Html.DisplayFor(model =>
                                model.GiaGiam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-3\">\r\n                                Tổng tiền\r\n                            </dt>\r\n                            <dd class=\"col-sm-9\">\r\n                                ");
#nullable restore
#line 53 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                           Write(Html.DisplayFor(model =>
                                model.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </dd>
                        </dl>
                    </div>
                </div>
                <div class=""row"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <td>STT</td>
                                <td>Tên sản phẩm</td>
                                <td>Hình ảnh</td>
                                <td>Số lượng</td>
                                <td>Đơn giá</td>
                                <td>Tổng tiền</td>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 72 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                             if (ViewBag.Order != null)
                            {
                                int i = 1;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                 foreach (var item in ViewBag.Order)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n\r\n                                        <td>");
#nullable restore
#line 79 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                        Write(i++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 80 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                       Write(item.SanPham.TenSP);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a4b754681237037104f04fdbac78fe032e0f098e12360", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3361, "~/images/", 3361, 9, true);
#nullable restore
#line 81 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
AddHtmlAttributeValue("", 3370, item.SanPham.HinhSP, 3370, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 82 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                       Write(item.SoLuong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 83 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                       Write(item.SanPham.DonGia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 84 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                        Write(item.SoLuong * @item.SanPham.DonGia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 86 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n            <div class=\"row\">\r\n                <div style=\"margin-right: 15px\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4b754681237037104f04fdbac78fe032e0f098e15937", async() => {
                WriteLiteral("Quay về");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4b754681237037104f04fdbac78fe032e0f098e17248", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a4b754681237037104f04fdbac78fe032e0f098e17531", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 98 "C:\Users\Admin\Desktop\ThuongMaiDienTu\TMDT\ShopQuanAo\Areas\Admin\Views\Order\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.OrderId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <input type=\"submit\" value=\"Hoàn tất\" class=\"btn btn-danger\" onclick=\" return confirm(\'Hoàn tất đơn hàng này?\');\" />\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            \r\n\r\n            </main>\r\n        </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopQuanAo.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
