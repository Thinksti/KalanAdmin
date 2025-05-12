function HideModal(Id) {
    $("#" + Id).modal("hide");
}
function ShowModal(Id) {
    $("#" + Id).modal("show");
}
window.downloadFileFromBase64 = (fileName, base64Data) => {
    try {
        const byteCharacters = atob(base64Data);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray], { type: 'application/zip' }); // Asegúrate de especificar el tipo MIME correcto
        const url = URL.createObjectURL(blob);
        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName;
        anchorElement.click();
        anchorElement.remove();
        URL.revokeObjectURL(url);
    } catch (error) {
        console.error('Error al descargar el archivo:', error);
    }
}
window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName;
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
}
function triggerFileInputClick(element) {
    element.click();
}
function hideSpinner() {
    document.getElementById("div_spinner").style.display = "none";
}
function showSpinner() {
    document.getElementById("div_spinner").style.display = "block";
}
function crearBlobUrl(datos) {
    var bytes = new Uint8Array(datos);
    var blob = new Blob([bytes], { type: 'application/pdf' });
    var url = URL.createObjectURL(blob);
    return url;
}

function crearBlobUrlMimeType(datos, mimeType) {
    var bytes = new Uint8Array(datos);
    var blob = new Blob([bytes], { type: mimeType });
    var url = URL.createObjectURL(blob);
    return url;
}

function crearBlobUrlImage(datos) {
    var bytes = new Uint8Array(datos);
    var blob = new Blob([bytes], { type: 'image/png' });
    var url = URL.createObjectURL(blob);
    return url;
}
function crearBlobUrlImagejpeg(datos) {
    var bytes = new Uint8Array(datos);
    var blob = new Blob([bytes], { type: 'image/jpeg' });
    var url = URL.createObjectURL(blob);
    return url;
}
window.getClipboard = async function () {
    if (navigator.clipboard) {
        var textToPaste = await navigator.clipboard.readText();
        return textToPaste;
    }
    else {
        return "";
    }
}

window.pasteFromClipboardToTextArea = async function (elementId) {
    var textArea = document.getElementById(elementId);
    if (textArea && navigator.clipboard) {
        var textToPaste = await navigator.clipboard.readText();
        textArea.value = textToPaste.trim();
    }
}
async function capturePagePNG() {
    const element = document.querySelector("body"); // Selecciona el cuerpo de la página
    const canvas = await html2canvas(element);
    const dataUrl = canvas.toDataURL("image/png");
    const response = await fetch(dataUrl);
    const blob = await response.blob();
    const arrayBuffer = await blob.arrayBuffer();
    const bytes = new Uint8Array(arrayBuffer);
    return bytes;
}
async function capturePageJPEG() {
    const element = document.querySelector("body"); // Selecciona el cuerpo de la página
    const canvas = await html2canvas(element);
    const dataUrl = canvas.toDataURL("image/jpeg");
    const response = await fetch(dataUrl);
    const blob = await response.blob();
    const arrayBuffer = await blob.arrayBuffer();
    const bytes = new Uint8Array(arrayBuffer);
    return bytes;
}

window.getClientHeight = (element) => {
    return element.clientHeight;
};

