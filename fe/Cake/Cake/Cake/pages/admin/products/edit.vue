<template>
    <div>
       
        <form>
        <div :key="index"
        v-for="(product, index) in listProduct">
            <div>

                <!-- thay co hoi tai sao em lai dung input :value thi tra loi ri -->
                <!-- listProduct m la no tra ve 1 mang, ma 1 mang update len thi k dc/ nen moi tao ra cai 
                dataSubmit dung value de set gia tri bang voi listProduct, va dataSubmit la 1 Object nen
                m put no lên đc
                van de la no k chinh dc data ne
                may cai kia tuong tu thi t chinh dc a' thoi de t lam cho nmhanh
                 -->
                <label for="">Tên sản phẩm </label>
                <input :value="dataSubmit.productName = product.productName"  
                @change="product.productName = $event.target.value"
                type="text" class="form-control">
                <input 
                    v-model="dataSubmit.productName"
                    type="hidden">
            </div>
            <input v-model="dataSubmit.productId" type="hidden">
            <input :value="dataSubmit.productId = product.productId" type="hidden" >
            <!-- lam tuong tu nhu rk hi` -->

            <!-- co van de chi o day roi, de chut fix -->
            <div>
                <label for="">Danh mục</label>
                
                <select 
                    v-model="dataSubmit.categoryId"
                    name="" class="form-control">
                    <option 
                     v-for="(category,index) in categories"
                     :key="index"
                     :value="category.categoryId"
                    >
                        {{category.categoryName}}
                    </option>
                </select>
            </div>
            <div>
                <label for="">Giá tiền</label>
                <input :value="dataSubmit.price = product.price"  
                @change="product.price = $event.target.value "
                type="text" class="form-control">
                <input 
                    v-model="dataSubmit.productName"
                    type="hidden">
            </div>
            <div>
                <label for="">Avatar</label>
                <input :value="dataSubmit.avatar = product.avatar"  
                @change="product.avatar = $event.target.value "
                type="text" class="form-control">
                <input 
                    v-model="dataSubmit.productName"
                    type="hidden">
            </div>
            <div>
                <label for="">Tồn kho</label>
                <input :value="dataSubmit.inStocks = product.inStocks"  
                @change="product.inStocks = $event.target.value "
                type="text" class="form-control">
                <input 
                    v-model="dataSubmit.productName"
                    type="hidden">
            </div>
            </div>
            <button @click.prevent="onUpdate" type = "submit" class = "btn btn-primary"> Lưu </button>
            <button type = "reset" class = "btn btn-outline-primary">Nhập lại</button>
        </form>
    </div>
</template>


<script>
import catalogApi from '@/api/catalogApi'
export default {
    layout: 'admin',
    middleware: ['isAuthorize'],
    data(){
        return{
            dataSubmit:{
                productName: '',
                avatar:'',
                categoryId:'', 
                // no tra ve mang met nhat khuc ni, no tra ve Object thi moi goi dc
                inStocks:'',
                price:'',
                productId:null
            },
            categories: [],
            listProduct: [],
        }
    },
    async created(){
        await this.getProduct()
        await this.getCategory()
    },
    
    methods:{
        async getProduct(){
            try{
                const { data } = await catalogApi.getProductById(this.$axios,
                 this.$route.params.id)
                this.listProduct = data
            }
            catch (err){}
        },

        async getCategory(){
            try {
                const { data } = await catalogApi.getCategories(this.$axios)
                this.categories = data
                console.log(this.categories);
            } catch (error) {
                console.log(error);
            }
        },

        onUpdate(){
            try {
                 this.$axios.$put(`/api/Catalog/update-sanpham/${this.$route.params.id}`, this.dataSubmit)
                alert("Chỉnh sửa thành công")
            } catch (error) {
                console.log(error);
                alert("Fail")
            }
        }
    }
}
</script>