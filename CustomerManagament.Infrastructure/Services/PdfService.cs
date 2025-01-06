using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using CustomerManagement.Core.Entities;
using System;
using CustomerManagement.Core.Services;
using QuestPDF.Companion;

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

                    page.Content().Border(1).Padding(10).Column(column =>
                    {
                        // Cabeçalho
                        column.Item().Row(row =>
                        {
                            row.ConstantItem(100).Column(col =>
                            {
                                col.Item().Text("RECIBO").FontSize(20).Bold().AlignCenter();
                            });

                            row.ConstantItem(100).Column(col =>
                            {
                                col.Item().Text($"Nº {receipt.Number}").Bold();
                                col.Item().Text($"Valor R$ {receipt.Value:C}").Bold();
                            });
                        });

                        column.Item().PaddingVertical(5).LineHorizontal(1);

                        // Corpo
                        column.Item().Text("Eu, __________________________________________").FontSize(12);
                        column.Item().Text("inscrito(a) no CPF sob o nº ______________________ e no RG nº ______________________").FontSize(12);
                        column.Item().Text($"recebi de __________________________________________").FontSize(12);
                        column.Item().Text("inscrito(a) no CPF sob o nº ______________________ e no RG nº ______________________").FontSize(12);
                        column.Item().Text($"a importância de R$ {receipt.Value:C}").FontSize(12).Bold();
                        column.Item().Text("(______________________________________)").FontSize(12);
                        column.Item().Text($"referente ao pagamento complementar à(ao) {receipt.Description}").FontSize(12);

                        column.Item().PaddingVertical(5).LineHorizontal(1);

                        // Rodapé
                        column.Item().Text($"______________________________, ___ de ____________ de ________").FontSize(12);
                        column.Item().Text("Assinatura: ___________________________________________").FontSize(12).AlignRight();
                    });
                });
            });

            byte[] pdf = document.GeneratePdf();

            document.ShowInCompanion();

            document.ShowInCompanion(12500);

            return pdf;
        }
    }
}
