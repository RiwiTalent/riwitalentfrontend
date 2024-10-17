import { initializeApp } from "https://www.gstatic.com/firebasejs/9.6.0/firebase-app.js";
import { getAuth, signInWithEmailAndPassword, signOut } from "https://www.gstatic.com/firebasejs/9.6.0/firebase-auth.js";

// Configura tus credenciales de Firebase
const firebaseConfig = {
    apiKey: "AIzaSyCofNVrdCYoT-m6TUqoRXFhq5AXzWc51-Q",
    authDomain: "riwi-centinela-dev.firebaseapp.com",
    projectId: "riwi-centinela-dev",
    storageBucket: "riwi-centinela-dev.appspot.com",
    messagingSenderId: "137505037607",
    appId: "1:137505037607:web:8077b62587748569459d02"
};

// Inicializa Firebase
const app = initializeApp(firebaseConfig);
const auth = getAuth(app);

// Exponer métodos para usarlos en Blazor
window.firebaseAuth = {
    signInWithEmailAndPassword: function (email, password) {
        return signInWithEmailAndPassword(auth, email, password)
            .then(userCredential => userCredential.user.getIdToken())
            .catch(error => { throw error.message });
    },
    signOut: function () {
        return signOut(auth)
            .then(() => "Sign-out successful.")
            .catch(error => { throw error.message });
    }
};