import { warn, returnWarn, BASEURL } from "../dashboard/dom.js"
import { browser } from "../dashboard/browser.js"
import { maskPhoneNumber } from "./main.js"
import { showUserName } from "../dashboard/main.js"

export const postUser = async (e) => {
    e.preventDefault()
    const result = await fetch(BASEURL + "/salvarUsuario", {
        method: "post",
        headers: {
            'Content-Type': 'application/json',
            "authorization": localStorage.getItem("auth")
        },
        body: JSON.stringify({
            "nome": firstname.value,
            "sobrenome": lastname.value,
            "email": email.value,
            "telefone": phonenumber.value,
            "DataNasc": birthdate.value,
            "senha": password.value,
            "estado": estado.checked ? true : false
        })
    })
    const response = await result.json()
    if (result.status != 200) {
        if(response.errors){
            return returnWarn(response)
        }
        return warn(response.message)
    }
    warn(response.message, true)
    browser("users")
}

export const deleteUser = async (id) => {
    const verify = confirm("Deseja deletar esse usuario?")
    if (verify) {
        const result = await fetch(`${BASEURL}/excluirUsuario/${id}`, {
            method: "DELETE",
            headers: {
                'Content-Type': 'application/json',
                "authorization": localStorage.getItem("auth")
            }
        })
        const response = await result.json()
        if (result.status == 200) {
            if(localStorage.getItem("id") == id){
                localStorage.clear()
                location.href = "./login.html"
            }
            browser("users")
            warn(response.message, true)
        }
    }
}

export const editUser = async (id) => {
    await browser("register")
    password.removeAttribute("required")
    confirmpass.removeAttribute("required")
    document.querySelector("button").innerText = "Atualizar"
    const result = await fetch(`${BASEURL}/obterPorId/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            "authorization": localStorage.getItem("auth")
        }
    })
    const response = await result.json()
    if (result.status == 200) {
        firstname.value = response.nome
        lastname.value = response.sobrenome
        phonenumber.value = maskPhoneNumber(response.telefone)
        birthdate.value = response.dataNasc.split('T')[0]
        email.value = response.email
        estado.checked = response.estado
    }
    registerForm.onsubmit = () => updateUser(id)
}

export const updateUser = async (id, e = event) => {
    e.preventDefault()
    const result = await fetch(BASEURL + `/editarUsuario/${id}`, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json',
            "authorization": localStorage.getItem("auth")
        },
        body: JSON.stringify({
            "nome": firstname.value,
            "sobrenome": lastname.value,
            "email": email.value,
            "telefone": phonenumber.value,
            "DataNasc": birthdate.value,
            "senha": password.value,
            "estado": estado.checked ? true : false
        })
    })
    const response = await result.json()
    if (result.status != 200) {
        if(response.errors){
            return returnWarn(response)
        }
        return warn(response.message)
    }
    warn(response.message, true)
    if(localStorage.getItem("id") == id){
        localStorage.setItem("fullname", `${firstname.value} ${lastname.value}`)
        showUserName()
        if(password.value != ""){
            localStorage.clear()
            location.reload()
        }
    }
    browser("users")
}
