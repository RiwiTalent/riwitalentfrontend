window.Blazor = window.Blazor || {};

window.Blazor.downloadFile = (fileName, contentType, byteArray) => {
    if (!byteArray) {
        console.error("byteArray is undefined or null.");
        return;
    }
    const blob = new Blob([new Uint8Array(byteArray)], { type: contentType });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    a.remove();
    URL.revokeObjectURL(url); // Limpia el objeto URL
};