using Ecrion.Ultrascale;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using tr.Models;

namespace tr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public TemplateResponse Render(RenderingOptions options)
        {
            if (options == null)
            {
                throw new HttpException(404,"Rendering options are null");
            }

            var _param = new RenderingParameters();

            if (options.OutputFormat == OutputFormat.PDF)
            {
                _param.OutputFormat = Engine.OutputFormat.PDF;
                _param.PDFOutputFlags = Engine.PDFFlags.PDF14;
            }
            else if (options.OutputFormat == OutputFormat.HTML)
            {
                _param.OutputFormat = Engine.OutputFormat.HTML;
                _param.HtmlOutputSettings = new Engine.HtmlOutputSettings
                {
                    GenerateHtmlDocument = false
                };
            }
            else
            {
                // no other format is supported...
                throw new HttpException(403, "Rendering.OutputFormat not supported");
            }

            var template = XDocument.Parse(options.Template);

            Stream stream = new MemoryStream();
            template.Save(stream);
            // Rewind the stream ready to read from it elsewhere
            stream.Position = 0;

            _param.Template = new LocalDocumentTemplate(stream, null, Engine.XsltEngine.MSXML, "en_EN", null);
            var _output = new OutputInformation();
            var ds = DataSource(options);

            using (var outputStream = new MemoryStream())
            {
                Engine engine = new Engine();
                engine.Render(ds, outputStream, _param, ref _output);
                return new TemplateResponse
                {
                    Response = outputStream.ToArray()
                };
            }
        }

        /// <summary>
        /// Get the data source
        /// </summary>
        /// <param name="data">Data structure</param>
        /// <returns>IDataSource</returns>
        private static IDataSource DataSource(RenderingOptions doc)
        {
            var x = XDocument.Parse(doc.Content);
            Stream stream = new MemoryStream();  // Create a stream
            x.Save(stream);      // Save XDocument into the stream
            stream.Position = 0;   // Rewind the stream ready to read from it elsewhere

            return new XmlDataSource(stream, Engine.InputFormat.XML);
        }
    }
}