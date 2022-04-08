export const toggleButton = document.querySelector('#hidden-button')
export const sidebar = document.querySelector('sidebar')
export const logo = document.querySelector("#logo")
export const menuOptions = document.querySelectorAll(".option")
export const menuText = document.querySelectorAll('p')
export const mainContainer = document.querySelector("#right-container")
export const mainContent = document.querySelector("#content")
export const warningbox = document.querySelector("#warning")
export const warningtext = document.querySelector("#warningtext")


export const BASEURL = "https://localhost:7142"

export const warn = (msg, color=false)=>{
    warningbox.classList.remove("close")
    warningbox.style.display = "flex"
    warningbox.style.background = color==true ? "#4CAF50":"#E96565"
    warningtext.innerHTML = `${msg}`
    setTimeout(()=> warningbox.classList.add("close"), 3000)
    setTimeout(()=> warningbox.style.display = "none", 4000)
}

export const returnWarn = (response) => {
    let counter = 0
    for (const er in response.errors) {
        response.errors[er].map((erro => {
            setTimeout(() => warn(erro), counter)
            counter += 1500
        }))
    }
}
