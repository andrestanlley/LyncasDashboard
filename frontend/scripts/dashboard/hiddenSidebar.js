import {mainContainer, sidebar, logo,menuOptions,menuText} from "./dom.js"

export const hiddenSidebar = ()=>{
    mainContainer.classList.toggle("close")
    sidebar.classList.toggle("close")
    logo.classList.toggle("close")
    menuOptions.forEach(option => {
        option.classList.toggle("close")
    })
    menuText.forEach(text => {
        text.classList.toggle("close")
    })
}
