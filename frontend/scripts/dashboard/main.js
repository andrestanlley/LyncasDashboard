import { menuOptions, toggleButton, logo } from "./dom.js"
import { hiddenSidebar } from "./hiddenSidebar.js"
import { browser } from "./browser.js"

export const showUserName = () => {
    const userName = document.querySelector("#user-info")
    userName.children[0].innerHTML = localStorage.getItem("fullname")
    userName.children[1].addEventListener("click", () => {
        localStorage.clear()
        location.href = "./login.html"
    })
}

onload = () => {
    if (visualViewport.width < 800) { // Esconde a barra automaticamente em telas menores
        hiddenSidebar()
    }

    browser() // Indexa a página padrão ao main container

    showUserName()

    menuOptions.forEach(option => {
        option.addEventListener("click", () => { // Adiciona um EventListener em todos os botões

            menuOptions.forEach(button => {
                button.classList.remove("optActive") // Adiciona o estilo de ativo ao botão clicado
            })
            option.classList.add("optActive")

            browser(option.id) // Carrega a página clicada dentro do container
        })
    })
}



toggleButton.addEventListener("click", hiddenSidebar)
logo.addEventListener("click", () => browser())