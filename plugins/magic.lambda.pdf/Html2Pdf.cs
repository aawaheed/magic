/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.IO;
using magic.node;
using magic.node.contracts;
using magic.node.extensions;
using magic.signals.contracts;
using iText.Html2pdf;

namespace magic.lambda.pdf
{
    /// <summary>
    /// [html2pdf] slot for converting HTML to PDF.
    /// </summary>
    [Slot(Name = "html2pdf")]
    public class Html2Pdf : ISlot
    {
        readonly IRootResolver _rootResolver;

        /// <summary>
        /// Creates an instance of your type
        /// </summary>
        /// <param name="rootResolver">Needed to resolve root folder of cloudlet</param>
        public Html2Pdf(IRootResolver rootResolver)
        {
            _rootResolver = rootResolver;
        }

        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler used to signal your slot.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var html = input.GetEx<string>();
            using (var stream = new MemoryStream())
            {
                HtmlConverter.ConvertToPdf(html, stream);
                input.Clear();
                input.Value = stream.ToArray();
            }
        }
    }
}
