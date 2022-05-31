export default function ({store, role}, next){
    const authenticated = store.getters["user/isAdmin"];
    if(authenticated){
        alert("xin chào admin")
        // chuyển về trang login
        role = "admin"
    }
    console.log(role)
    next()
}