
using Barcoder.Ean;
using Barcoder.Renderer.Svg;
using BdPouch.Service.MainSeos;
using BdPouch.Service.SiteSettings;
using BdPouch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Components
{
    public class BarcodeViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string ean)
        {

            string svg;
            var barcode = EanEncoder.Encode(ean.ToString());
            var renderer = new SvgRenderer();

            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            {
                renderer.Render(barcode, stream);
                stream.Position = 0;

                svg = reader.ReadToEnd();
            }

            return View(new { svg});
        }
    }
}
