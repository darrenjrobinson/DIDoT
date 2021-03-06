#pragma checksum "C:\working-friday\Pages\V2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d3ae7ab51a6829aad8ec672d336dcac41c0b0bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreVerifiableCredentials.Pages.Pages_V2), @"mvc.1.0.razor-page", @"/Pages/V2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d3ae7ab51a6829aad8ec672d336dcac41c0b0bc", @"/Pages/V2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1696cd1c73de55a48ac8554feb073dcb6d0d8bc3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_V2 : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\working-friday\Pages\V2.cshtml"
  
    ViewData["Title"] = "Verifier";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"           <div style=""text-align: center;"">
                <img src=""newLogo.png"" height=100px; />
                <h1>Identirati Product Verifiable Credential Verification</h1>
        
            <button type=""button"" id=""sign-in"" class=""button"">VERIFY CREDENTIAL</button>
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
               <");
            WriteLiteral(@"div id=""message""></div>
                <br />
               <div id=""subject""></div>
                <br />
               <div id=""payload""></div>
            </div>

            <script src=""qrcode.min.js""></script>
            
            <script>
                    function saveDynamicDataToFile() {
                    var userInput = document.getElementById('payload').value;
		            var blob = new Blob([userInput], { type: ""text/plain;charset=utf-8"" });
                saveAs(blob, ""dynamic.txt"");
            </script>
            
            
            
            
            
            <script>
                var signIn = document.getElementById('sign-in');
                var signOut = document.getElementById('sign-out');
                var display = document.getElementById('display');
                var qrcode = new QRCode(""qrcode"", { width: 300, height: 300 });
                var respPresentationReq = null;







                signIn.addEventL");
            WriteLiteral(@"istener('click', () => {
                    fetch('/api/verifier/presentation-request')
                    .then(function(response) {
                        response.text()
                        .catch(error => document.getElementById(""message"").innerHTML = error)
                        .then(function(message) {
                            respPresentationReq = JSON.parse(message);
                            if( /Android/i.test(navigator.userAgent) ) {
                                console.log(`Android device! Using deep link (${respPresentationReq.url}).`);
                                window.location.href = respPresentationReq.url; setTimeout(function () {
                                window.location.href = ""https://play.google.com/store/apps/details?id=com.azure.authenticator""; }, 2000);
                            } else if (/iPhone/i.test(navigator.userAgent)) {
                                console.log(`iOS device! Using deep link (${respPresentationReq.url}).`);
          ");
            WriteLiteral(@"                      window.location.replace(respPresentationReq.url);
                            } else {
                                console.log(`Not Android or IOS. Generating QR code encoded with ${message}`);
                                qrcode.makeCode(respPresentationReq.url);
                                document.getElementById('sign-in').style.visibility = ""hidden"";
                                document.getElementById('qrText').style.display = ""block"";
                            }
                        }).catch(error => { console.log(error.message); })
                    }).catch(error => { console.log(error.message); })

                    var checkStatus = setInterval(function () {
                        fetch('api/verifier/presentation-response?id=' + respPresentationReq.id )
                            .then(response => response.text())
                            .catch(error => document.getElementById(""message"").innerHTML = error)
                            .");
            WriteLiteral(@"then(response => {
                                if (response.length > 0) {
                                    console.log(response)
                                    respMsg = JSON.parse(response);
                                    // QR Code scanned
                                    if (respMsg.status == 'request_retrieved') {
                                        document.getElementById('message-wrapper').style.display = ""block"";
                                        document.getElementById('qrText').style.display = ""none"";
                                        document.getElementById('qrcode').style.display = ""none"";

                                        document.getElementById('message').innerHTML = respMsg.message;
                                    }
                                    
                                    if (respMsg.status == 'presentation_verified') {
                                        document.getElementById('message').innerHTML = respMsg.messag");
            WriteLiteral(@"e;
                                        document.getElementById('payload').innerHTML = ""Payload: "" + JSON.stringify(respMsg.payload);
                                        document.getElementById('subject').innerHTML = respMsg.productName +"" cointains the following allergens: <b>"" + respMsg.allergenName +""</b>.<br> It also contains these ingredients: "" + respMsg.ingredientName;
                                        saveDynamicDataToFile();
                                        clearInterval(checkStatus);
                                    }

                                }
                            })
                    }, 1500); //change this to higher interval if you use ngrok to prevent overloading the free tier service
                })
            </script>
            </div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AspNetCoreVerifiableCredentials.Pages.VerifierModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspNetCoreVerifiableCredentials.Pages.VerifierModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspNetCoreVerifiableCredentials.Pages.VerifierModel>)PageContext?.ViewData;
        public AspNetCoreVerifiableCredentials.Pages.VerifierModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
