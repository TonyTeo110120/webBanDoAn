export default function ({store, redirect}, next){
    const authenticated = store.getters["user/isAuthen"];
    if(!authenticated){
        alert("vui lòng đăng nhập")
        // chuyển về trang login
        redirect('/login')
    }
    next()
}