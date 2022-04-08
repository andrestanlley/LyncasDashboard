import { BASEURL, returnWarn, warn } from "../dashboard/dom.js"

const id = localStorage.getItem("id")
const fullname = localStorage.getItem("fullname")
const auth = localStorage.getItem("auth")

if(id != null && fullname != null && auth != null){
    location.href = "./dashboard.html"
}

const email = document.querySelector("#email")
const password = document.querySelector("#password")
const loginForm = document.querySelector("#login-form")

loginForm.addEventListener("submit", async (e) => {
    e.preventDefault()
    const request = {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "email": email.value,
            "senha": password.value
        })
    }
    const response = await fetch(BASEURL + "/login", request)
    const result = await response.json()
    console.log(result)
    if (response.status != 200) {
        if(result.errors){
            return returnWarn(result)
        }
        return warn(result.message)
    }
    localStorage.setItem("id", result.pessoaId)
    localStorage.setItem("fullname", `${result.nome} ${result.sobrenome}`)
    localStorage.setItem("auth", `Basic ${btoa(result.email + ":" + password.value)}`)
    location.href = "../frontend/dashboard.html"
})

