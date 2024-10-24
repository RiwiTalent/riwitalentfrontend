window.Blazor = window.Blazor || {};

<<<<<<< HEAD
=======
// Descargar el archivo desde un array de bytes como raw
>>>>>>> 54902e3b7322e0de7bfa7b6273d6d595251a934b
window.Blazor.downloadFile = (fileName, contentType, byteArray) => {
    if (!byteArray) {
        console.error("byteArray is undefined or null.");
        return;
    }
    const blob = new Blob([new Uint8Array(byteArray)], { type: contentType });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
<<<<<<< HEAD
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    a.remove();
    URL.revokeObjectURL(url); // Limpia el objeto URL
};
=======
    a.download = fileName;  // Aquí puedes especificar cualquier extensión, o dejarlo sin extensión si es RAW
    document.body.appendChild(a);
    a.click();
    a.remove();
    URL.revokeObjectURL(url);
};

window.Blazor = window.Blazor || {};

// Nueva función para abrir una URL
window.Blazor.downloadFromUrl = (url) => {
    if (!url) {
        console.error("URL is undefined or null.");
        return;
    }
    const a = document.createElement('a');
    a.href = url;
    a.target = '_blank'; // Abre en nueva pestaña
    document.body.appendChild(a);
    a.click();
    a.remove();
};

>>>>>>> 54902e3b7322e0de7bfa7b6273d6d595251a934b
