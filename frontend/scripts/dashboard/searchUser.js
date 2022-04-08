import { getTable } from "./getUsers.js"

export const searchUser = (data) => {
    const searchButton = document.querySelector("#searchUserLabel").children[1]
    searchButton.addEventListener("keyup", async () => {
        const newData = data.filter(user => {
            if (user.nome.toUpperCase().indexOf(searchButton.value.toUpperCase()) >= 0
                || user.sobrenome.toUpperCase().indexOf(searchButton.value.toUpperCase()) >= 0) {
                return user
            }
        })
        if (searchButton.value != "") {
            getTable(newData)
        } else {
            getTable(data)
        }
    })
}