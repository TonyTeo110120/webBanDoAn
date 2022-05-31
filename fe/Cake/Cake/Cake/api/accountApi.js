export default{
    login(axios,data){
        return axios.$post('/api/Accounts/Login',data)
    },
    register(axios,data){
        const url = '/api/Accounts/Register'
        return axios.$post(url,data)
    },
}