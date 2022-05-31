<template>
     <div class="dathang_team">
        <form action="" @submit.prevent="onSubmit">
            <div
            v-for="(product,index) in listProducts"
            :key="index"
            :value="product.price"
            >
            <div>
                <label for="">Sản phẩm đặt hàng </label>
                <input v-model="dataSubmit.productName" type = "hidden">
                <input type = "hidden"
                 :value="dataSubmit.productName = product.productName">
                
                
                <div class="dathang_new">
                    {{product.productName}}
                </div>
            </div>
            <div>
                <label for="">Số lượng </label>
                <input v-model="dataSubmit.soluong"
                    type="number" class="form-control">
            </div>

            <div class="dathang_new">
                <label for="">Giá tiền</label>
                <input v-model="dataSubmit.price" type = "hidden">
                <input type = "hidden"
                 :value="dataSubmit.price = product.price*dataSubmit.soluong">
                    {{product.price * dataSubmit.soluong}}
                </div>
            </div>

            <div>
                <label for="">Họ tên</label>
                <input v-model="dataSubmit.hoten"
                    type="text" class="form-control">
            </div>
            <div>
                <label for="">Địa chỉ </label>
                <input v-model="dataSubmit.diachi"
                    type="text" class="form-control">
            </div>
            <div>
                <label for="">Số điện thoại</label>
                <input v-model="dataSubmit.sodienthoai"
                    type="text" class="form-control">
            </div>
            <button class="btn btn-primary">Đặt ngay </button>
        </form>
    </div>
</template>

<script>
import catalogApi from '@/api/catalogApi'
export default {
    middleware: ['isAuthorize'],
    data(){
        return {
            dataSubmit:{
                productName: '',
                soluong: 1,
                price:'',
                diachi: '',
                hoten:'',
                sodienthoai: ''
            },
            listProducts:[],
        }
    },
    async created(){
        await this.getAllProducts()
    },
    methods:{
        async getAllProducts(){
            try{
            const {data} = await catalogApi.getProductById(this.$axios, this.$route.params.id)
            console.log(data)
            this.listProducts = data
            }
        catch(err){
            console.log(err)
            }
        },

        async onSubmit(){
            try{
                await catalogApi.addDonHang(this.$axios,this.dataSubmit)
                alert('Bạn đã đặt hàng thành công')
                this.$router.push('/')
            }
            catch(err){
                alert('Có lỗi xảy ra' + JSON.stringify(err))
            }
        }
        }
    }
</script>
<style>
.dathang_new{
    color: red;
    
}
.dathang_team{
    font-size: 2rem;
    padding-left: 5rem;
    padding-right: 5rem;
    color: white;

}
</style>