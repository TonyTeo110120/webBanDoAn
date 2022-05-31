export default {
    // product
    getCategories(axios){
        return axios.get('/api/Catalog/categories')
    },
    getProducts(axios){
        return axios.get('/api/Catalog/product')
    },
    getProductById(axios, id){
        return axios.get(`/api/Catalog/product/${id}`)
    },
    getProductsByCategories(axios, categoryId){
        return axios.get(`/api/Catalog/product-by-category/${categoryId}`)
    },
    updateProduct(axios, id , data){
        return axios.put(`/api/Catalog/update-sanpham/${id}`)
    },
    deleteProduct(axios, id){
        return axios.delete(`/api/Catalog/delete-sanpham/${id}`)
    },
    getData: (axios) => axios.get('api/Catalog/categories'),
    addProduct(axios,data){
        const url = 'api/Catalog/add-product'
        return axios.$post(url,data)
    },
    searchData(axios, nameData){
        return axios.get(`/api/Catalog/search/${nameData}`)
    },

    
    // contact
    getContact(axios){
        return axios.get('/api/Contact/Contact')
    },
    addContact(axios,data){
        const url = 'api/Contact/add-contact'
        return axios.$post(url,data)
    },
    deleteContact(axios, id){
        return axios.delete(`/api/Contact/delete-contact/${id}`)
    },

    
    // don hang
    getDonHang(axios){
        return axios.get('/api/Catalog/donhang')
    },

    addDonHang(axios,data){
        const url = '/api/Catalog/dathang'
        return axios.$post(url,data)
    },
    deleteDonHang(axios, id){
        return axios.delete(`/api/Catalog/delete-donhang/${id}`)
    },
}