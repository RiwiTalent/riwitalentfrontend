// Función para guardar el token en una cookie
window.setTokenInCookies = function (token) {
   
    document.cookie = `authToken=${token}; path=/; max-age=3600; SameSite=Lax;`;
};


// Función para leer el token de las cookies
window.getCookie = function(name){
    const value = `; ${document.cookie}`;
    const parts = value.split(`; authToken=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}


//Funcion para crear una cookie de auth externo
window.setCookieExternal = function (){
    document.cookie = "Auth=true; path=/; max-age=3600; SameSite=Lax;";
}

//Funcion para leer la cookie del externo
window.GetCookieExternal = function (){
    const value = `; ${document.cookie}`;
    const parts = value.split(`; Auth=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}

// Función para borrar el token de las cookies
function deleteTokenFromCookies() {
    document.cookie = "authToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = "Auth=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
}