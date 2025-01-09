using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Helpers;
using CustomerManagement.Core.Services;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
namespace CustomerManagament.Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GenerateReceipt(Receipt receipt)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));
                    page.PageColor(Colors.White);

                    page.Content().Column(column =>
                    {
                        // Cabeçalho
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Column(header =>
                            {
                                header.Item().Text("RECIBO").FontSize(30).Bold().AlignStart();
                            });

                            row.RelativeItem().Column(number =>
                            {
                                number.Item().PaddingTop(5).Text($"Nº {receipt.Number}").FontSize(20).Bold().AlignStart();
                            });

                            row.RelativeItem().AlignRight().Column(price =>
                            {
                                price.Item().Text($"VALOR").FontSize(12).Bold();
                                price.Item().Text($"R$ {receipt.Value:N2}").FontSize(16).Bold();
                            });
                        });

                        column.Item().PaddingVertical(10).LineHorizontal(1);

                        // Corpo do Recibo
                        column.Item().Text($"Recebi (emos) de:").FontSize(12).Bold();
                        column.Item().Text(receipt.Customer.Name).FontSize(12);

                        column.Item().PaddingTop(5).Text($"a quantia de:").FontSize(12).Bold();
                        // TODO: Format numeric price to written out
                        column.Item().Text($"{ToWords(receipt.Value)} (R$ {receipt.Value:N2})").FontSize(12);

                        column.Item().PaddingTop(5).Text($"Correspondente a:").FontSize(12).Bold();
                        column.Item().Text(receipt.Description).FontSize(12);

                        column.Item().PaddingVertical(10).LineHorizontal(1);

                        // Local e Data
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text("Local e Data:").FontSize(12);
                            row.RelativeItem().Text($"{receipt.Customer.City.Name}").FontSize(12);
                            row.ConstantItem(20).Text(receipt.Date.Day.ToString("00")).FontSize(12);
                            row.ConstantItem(65).Text(receipt.Date.ToString("MMMM", new CultureInfo("pt-BR")).ToUpper()).FontSize(12);
                            row.ConstantItem(50).Text(receipt.Date.Year.ToString()).FontSize(12);
                        });

                        column.Item().PaddingVertical(5).LineHorizontal(1);

                        column.Item().PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Text("Nome:").FontSize(12);
                            row.RelativeItem().Text($"{receipt.Tenant.Name}").FontSize(12);
                        });

                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text("CPF/CNPJ:").FontSize(12);
                            row.RelativeItem().Text($"{receipt.Tenant.DocumentNumber.FormatAsCpfOrCnpj()}").FontSize(12);
                        });
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text("Telefone");
                            row.RelativeItem().Text($"{receipt.Customer.PhoneNumber.FormatAsPhoneNumber()}");
                        });

                        column.Item().Row(row =>
                        {
                            row.RelativeItem().PaddingTop(30).Text("Assinatura: ___________________________________________").FontSize(12);
                        });
                    });
                });
            });

            //document.ShowInCompanion();

            return document.GeneratePdf();
        }
        
        private string ToWords(decimal value)
        {
            var culture = new CultureInfo("pt-BR");
            return $"{value.ToString("C", culture)}".ToUpper();
        }
    }

}
