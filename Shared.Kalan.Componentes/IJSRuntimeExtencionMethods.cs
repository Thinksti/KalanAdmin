using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Componentes
{
    public static class IJSRuntimeExtencionMethods
    {
        public static async ValueTask InicializarTimerInactivo<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("timerInactivo", dotNetObjectReference);
        }
        public static ValueTask<string> getClipboard(this IJSRuntime js) => js.InvokeAsync<string>("getClipboard");
        public static ValueTask<string> crearBlobPDF(this IJSRuntime js, byte[] datos) => js.InvokeAsync<string>("crearBlobUrl", datos);
        public static ValueTask<string> crearBlobPNG(this IJSRuntime js, byte[] datos) => js.InvokeAsync<string>("crearBlobUrlImage", datos);
        public static ValueTask<string> crearBlobUrJPEG(this IJSRuntime js, byte[] datos) => js.InvokeAsync<string>("crearBlobUrlImagejpeg", datos);
        public static ValueTask<string> crearBlob(this IJSRuntime js, byte[] datos, string mimeType) => js.InvokeAsync<string>("crearBlobUrlMimeType", datos, mimeType);
        public static async Task<byte[]> capturePagePNG(this IJSRuntime js)
        {
            return await js.InvokeAsync<byte[]>("capturePagePNG");
        }
        public static async Task<byte[]> capturePageJPEG(this IJSRuntime js)
        {
            return await js.InvokeAsync<byte[]>("capturePageJPEG");
        }
        public static async Task DownloadFileFromStream(this IJSRuntime js,Stream fileStream, string fileName)
        {
            using var streamRef = new DotNetStreamReference(stream: fileStream);
            await js.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }
    }
}
