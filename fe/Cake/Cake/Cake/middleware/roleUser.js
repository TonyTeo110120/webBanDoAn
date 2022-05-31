export default function ({store, role}, next){
    const authenticated = store.getters["user/isUser"];
    if(authenticated){
        alert("đăng nhập thành công")
        role = "user"
    }
    console.log(role)
    next()
}