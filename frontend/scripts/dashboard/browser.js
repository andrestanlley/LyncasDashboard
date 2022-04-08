import { mainContent } from "./dom.js"
import { getUsers } from "./getUsers.js"
import { checkRegister } from "../register/main.js"

export const browser = async (page = "home") => {
    mainContent.innerHTML = "Carregando..."

    let contentUrl = `./components/${page}.html`

    const request = await fetch(contentUrl)
    const response = await request.text()
    if (request.status == 200) {
        mainContent.innerHTML = response
        switch (page) {
            case "users":
                getUsers()
                break
            case "register":
                checkRegister()
                break
            default:
                break
        }
    } else {
        alert("Erro ao carregar o conteúdo.")
    }
}

