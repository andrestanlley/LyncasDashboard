const url = location.href

const id = localStorage.getItem("id")
const fullname = localStorage.getItem("fullname")
const auth = localStorage.getItem("auth")

if (id == null || fullname == null || auth == null) {
    if (url.indexOf("components") == -1) {
        location.href = "./login.html"
    } else {
        location.href = "../login.html"
    }
}