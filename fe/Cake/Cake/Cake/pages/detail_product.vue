<template>
     <center class="dathang_team">
        <form action="">
            <div
            v-for="(product,index) in listProducts"
            :key="index"
            :value="product.price"
            >
                <div>
                    <label for="">Sản phẩm </label>              
                    <div class="dathang_new">
                        {{product.productName}}
                    </div>
                </div>
                <div class="width: 100px;">
                    <img :src="product.avatar" class="img-fluid" style="display: block;
  width: 40%;
  height: auto;" />
                </div>
                <div class="dathang_new">
                    <label for="">Giá tiền:</label>
                        {{product.price}}
                </div>
            <div>
                <label for="">Mã sản phẩm: <p style="font-size:24px">BANH {{product.productId}}</p> </label>
            </div>
            <div>
                <label for="">Tồn kho:</label>
                {{product.inStocks}}
            </div>
            <router-link :to="{path: '/dathang/' + product.productId }" >
                <button
                    type="button" 
                    class=" btn btn-lg btn-primary"
                    >
                Đặt ngay
                </button>
            </router-link>
        </div>
            
        </form>
    </center>
</template>

<script>
import catalogApi from '@/api/catalogApi'
export default {
    data(){
        return {
            dataSubmit:{
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

}
</style>