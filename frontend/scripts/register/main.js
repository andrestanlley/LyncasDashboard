import { browser } from "../dashboard/browser.js"
import { postUser } from "./CRUD.js"

export const listenRegisterButton = () => {
    const registerButton = document.querySelector('#register')
    registerButton.addEventListener("click", () => {
        browser("register")
    })
}

export function maskPhoneNumber(phonenumber) {
    phonenumber = phonenumber.replace(/\D/g, "")
    phonenumber = phonenumber.replace(/^(\d{2})(\d)/g, "($1) $2")
    phonenumber = phonenumber.replace(/(\d)(\d{4})$/, "$1-$2")
    return phonenumber
}

export const checkRegister = () => {
    const firstname = document.querySelector("input#firstname")
    const lastname = document.querySelector("input#lastname")
    const email = document.querySelector("input#email")
    const phonenumber = document.querySelector("input#phonenumber")
    const birthdate = document.querySelector("input#birthdate")
    const password = document.querySelector("input#password")
    const confirmpass = document.querySelector("input#confirmpass")
    const estado = document.querySelector("#estado")
    const registerForm = document.querySelector("#registerForm")


    function validatePassword() {
        if (password.value.search(/[0-9]/) != -1) {
            password.setCustomValidity('');
        } else {
            password.setCustomValidity("Digite ao menos um número.")
        }
        if (password.value != confirmpass.value) {
            confirmpass.setCustomValidity("Senhas não conferem.");
        } else {
            confirmpass.setCustomValidity('')
        }
    }

    phonenumber.addEventListener("keyup", () => phonenumber.value = maskPhoneNumber(phonenumber.value))

    password.onchange = validatePassword
    confirmpass.onkeyup = validatePassword
    registerForm.onsubmit = postUser
}
