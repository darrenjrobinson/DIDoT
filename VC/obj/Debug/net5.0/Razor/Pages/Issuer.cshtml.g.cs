#pragma checksum "C:\working-friday\Pages\Issuer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ee84521242927593b1e8ff4858b10d43cf1559e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreVerifiableCredentials.Pages.Pages_Issuer), @"mvc.1.0.razor-page", @"/Pages/Issuer.cshtml")]
namespace AspNetCoreVerifiableCredentials.Pages
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
#line 1 "C:\working-friday\Pages\_ViewImports.cshtml"
using AspNetCoreVerifiableCredentials;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee84521242927593b1e8ff4858b10d43cf1559e", @"/Pages/Issuer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1696cd1c73de55a48ac8554feb073dcb6d0d8bc3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Issuer : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\working-friday\Pages\Issuer.cshtml"
  
    ViewData["Title"] = "Issuer";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div style=""text-align: center;"">
                <img src=""newLogo.png"" height=100px; />
                <h1>Identirati Product Verifiable Credential Issuance</h1>
        
            <button type=""button"" id=""sign-in"" class=""button"">GET CREDENTIAL</button>
            <div id=""qrText""  style=""display:none;"">
                <p class=""small-text"">
                    <img src=""authenticator-icon.png"" alt=""Authenticator icon"" class=""icon-small""><br>
                    Scan with Microsoft Authenticator
                </p>
            </div>
            <a id=""deeplink"" style=""display: none;margin-top: 10px;"">Tap to open Authenticator on mobile</a>
            <div id=""qrcode"" style=""text-align: center""></div>
            <div id=""pinCodeText"" style=""display: none""></div>

            <div id=""message-wrapper"" class=""margin-bottom-75 margin-top-75"" style=""display: none"">
               <i class=""fas fa-user-check green icon-text-large margin-bottom-25""></i>
               <div id");
            WriteLiteral(@"=""message""></div>
               <br />
               <div id=""payload""></div>
            </div>

            <script src=""qrcode.min.js""></script>
            <script>
                var signIn = document.getElementById('sign-in');
                var signOut = document.getElementById('sign-out');
                var display = document.getElementById('display');
                var qrcode = new QRCode(""qrcode"", { width: 300, height: 300 });
                var respIssuanceReq = null;

                signIn.addEventListener('click', () => {
                    fetch('/api/issuer/issuance-request')
                    .then(function(response) {
                        response.text()
                        .catch(error => document.getElementById(""message"").innerHTML = error)
                        .then(function(message) {
                            respIssuanceReq = JSON.parse(message);
                            if( /Android/i.test(navigator.userAgent) ) {
                       ");
            WriteLiteral(@"         console.log(`Android device! Using deep link (${respIssuanceReq.url}).`);
                                window.location.href = respIssuanceReq.url; setTimeout(function () {
                                window.location.href = ""https://play.google.com/store/apps/details?id=com.azure.authenticator""; }, 2000);
                            } else if (/iPhone/i.test(navigator.userAgent)) {
                                console.log(`iOS device! Using deep link (${respIssuanceReq.url}).`);
                                window.location.replace(respIssuanceReq.url);
                            } else {
                                console.log(`Not Android or IOS. Generating QR code encoded with ${message}`);
                                qrcode.makeCode(respIssuanceReq.url);
                                document.getElementById('sign-in').style.display = ""none"";
                                document.getElementById('qrText').style.display = ""block"";
                                i");
            WriteLiteral(@"f (respIssuanceReq.pin) {
                                    document.getElementById('pinCodeText').innerHTML = ""Pin code: "" + respIssuanceReq.pin;
                                    document.getElementById('pinCodeText').style.display = ""block"";
                                }
                            }
                        }).catch(error => { console.log(error.message); })
                    }).catch(error => { console.log(error.message); })

                    var checkStatus = setInterval(function () {
                        fetch('api/issuer/issuance-response?id=' + respIssuanceReq.id )
                            .then(response => response.text())
                            .catch(error => document.getElementById(""message"").innerHTML = error)
                            .then(response => {
                                if (response.length > 0) {
                                    console.log(response)
                                    respMsg = JSON.parse(response);
  ");
            WriteLiteral(@"                                  // QR Code scanned, show pincode if pincode is required
                                    if (respMsg.status == 'request_retrieved') {
                                        document.getElementById('message-wrapper').style.display = ""block"";
                                        document.getElementById('qrText').style.display = ""none"";
                                        document.getElementById('qrcode').style.display = ""none"";

                                        if (respMsg.pin) {
                                            document.getElementById('pinCodeText').style.display = ""visible"";
                                        }
                                        document.getElementById('message').innerHTML = respMsg.message;
                                    }
                                    if (respMsg.status == 'issuance_successful') {
                                        document.getElementById('pinCodeText').style.display = ""none");
            WriteLiteral(@""";
                                        document.getElementById('message').innerHTML = respMsg.message;
                                        clearInterval(checkStatus);
                                    }
                                    if (respMsg.status == 'issuance_error') {
                                        document.getElementById('pinCodeText').style.display = ""none"";
                                        document.getElementById('message').innerHTML = ""Issuance error occured, did you enter the wrong pincode? Please refresh the page and try again."";
                                        document.getElementById('payload').innerHTML = ""Payload: "" + respMsg.payload;
                                        clearInterval(checkStatus);
                                    }
                                }
                            })
                    }, 1500); //change this to higher interval if you use ngrok to prevent overloading the free tier service
                }");
            WriteLiteral(")\r\n            </script>\r\n            </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AspNetCoreVerifiableCredentials.Pages.IssuerModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspNetCoreVerifiableCredentials.Pages.IssuerModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspNetCoreVerifiableCredentials.Pages.IssuerModel>)PageContext?.ViewData;
        public AspNetCoreVerifiableCredentials.Pages.IssuerModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591