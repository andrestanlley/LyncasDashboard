import { BASEURL, warn } from "./dom.js"
import { deleteUser, editUser } from "../register/CRUD.js"
import { listenRegisterButton, maskPhoneNumber } from "../register/main.js"
import { searchUser } from "./searchUser.js"

export const getTable = (data) => {
    const usersTable = document.querySelector('tbody')

    usersTable.innerHTML =
        `<tr>
            <th><p>Status</i></p></th>
            <th><p>Nome <i class="fas fa-sort-amount-down"></i></p></th>
            <th><p>Telefone <i class="fas fa-sort-amount-down"></i></p></th>
            <th><p>Email <i class="fas fa-sort-amount-down"></i></p></i></th>
            <th><p>Data Nasc. <i class="fas fa-sort-amount-down"></i></p></th>
            <th><p>Ações</p></th>
            </tr>`

    let mainTable = {
        id: [],
        name: [],
        phone: [],
        status: [],
        email: [],
        birth: [],
        columns: [],
        rows: []
    }

    data.forEach((user, index) => {
        let { pessoaId, estado, nome, sobrenome, email, telefone, dataNasc } = user
        let birthDate = new Date(dataNasc)
        mainTable.id.push(pessoaId)
        mainTable.name.push(`${nome} ${sobrenome}`)
        mainTable.phone.push(telefone)
        mainTable.status.push(estado)
        mainTable.email.push(email)
        mainTable.birth.push(new Intl.DateTimeFormat('pt-BR').format(birthDate))

        let row = document.createElement('tr')

        for (let i = 0; i < 6; i++) {
            mainTable.columns[i] = document.createElement('td')
            row.append(mainTable.columns[i])
        }

        usersTable.append(row)
        row.classList.add("tableRow")

        mainTable.columns[0].innerHTML = renderStatus(mainTable.status[index])
        mainTable.columns[1].innerHTML = `<div class="personal"><img src="./assets/users/profile/0.jpg" class="profile-pic"> ${mainTable.name[index]}</div>`
        mainTable.columns[2].innerText = maskPhoneNumber(mainTable.phone[index])
        mainTable.columns[3].innerText = mainTable.email[index]
        mainTable.columns[4].innerText = mainTable.birth[index]
        mainTable.columns[5].innerHTML = actionButtons(mainTable.id[index])
    })

    const edit = document.querySelectorAll(".fa-edit")
    const del = document.querySelectorAll(".fa-trash")

    edit.forEach((button => {
        button.addEventListener("click", () => editUser(button.id))
    }))

    del.forEach((button => {
        button.addEventListener("click", () => deleteUser(button.id))
    }))
}

const renderStatus = (status) => {
    if (status === true) {
        return '<p class="status active"></p>'
    }
    return '<p class="status blocked"></p>'
}

const actionButtons = (id) => {
    const buttons = `<i class="fas fa-edit actButton" id="${id}"></i><i class="fas fa-trash actButton" id="${id}"></i>`
    return buttons
}

export const getUsers = async () => {
    const loading = document.querySelector("#loading")
    loading.style.display = "block"
    const result = await fetch(BASEURL + "/obterTodos", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            "authorization": localStorage.getItem("auth")
        }
    })
    const data = await result.json()
    loading.style.display = "none"
    if (result.status != 200) {
        content.innerHTML += `<div><img src="./assets/imgs/notfound.png" width="100"><h5>${data.message}</h5></div>`
        warn(data.message)
    } else {
        getTable(data)
        searchUser(data)
    }
    listenRegisterButton()
}