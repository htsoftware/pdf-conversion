using System;
using System.Threading.Tasks;
using iText.Kernel.Geom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdfConversion.Constant;
using PdfConversion.Contracts;
using PdfConversion.Dto;
using PdfConversion.Helper;

namespace PdfConversion.Services
{
    public class ReportService : IReportService
    {
        private readonly ILogger<ReportService> _logger;

        public ReportService(ILogger<ReportService> logger)
        {
            _logger = logger;
        }

        public async Task<FileStreamResult> ExportToPdf(string htmlContent, bool rotate)
        {
            var pageSize = rotate ? PageSize.A4.Rotate() : PageSize.A4;
            var convertRequest = new ConvertRequest
            {
                Content = htmlContent,
                Footer = PdfFormation.PageNumberFooterTemplate
            };

            var pdfConverter = new PdfHtmConverter(convertRequest);
            var memoryStream = pdfConverter.ManipulatePdf(pageSize);

            var guid = Guid.NewGuid();
            var outputFilePath = $"report_{guid}.pdf";
            var finalOutputFilePath = $"final_report_{guid}.pdf";

            await PdfFileWriter.SaveToFile(memoryStream, outputFilePath);
            _logger.LogInformation($"Saved pdf file {outputFilePath}");

            pdfConverter.DecoratePdf(outputFilePath, finalOutputFilePath);
            var response = PdfFileReader.ReadFrom(finalOutputFilePath);

            FileOperator.Delete(outputFilePath);
            _logger.LogInformation($"Deleted pdf file {outputFilePath}");
            FileOperator.Delete(finalOutputFilePath);
            _logger.LogInformation($"Deleted pdf file {finalOutputFilePath}");

            return new FileStreamResult(response, "application/pdf");
        }
    }
}