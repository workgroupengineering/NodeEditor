using System.IO;
using Avalonia;
using Avalonia.Controls;
using SkiaSharp;

namespace NodeEditor.Export.Renderers;

public static class PdfRenderer
{
    public static void Render(Control target, Size size, Stream stream, double dpi = 72)
    {
        using var managedWStream = new SKManagedWStream(stream);
        using var document = SKDocument.CreatePdf(stream, (float)dpi);
        using var canvas = document.BeginPage((float)size.Width, (float)size.Height);
        target.Measure(size);
        target.Arrange(new Rect(size));
        CanvasRenderer.Render(target, canvas, dpi);
    }
}
