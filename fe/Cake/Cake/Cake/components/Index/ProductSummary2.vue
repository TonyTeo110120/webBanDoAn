<template>
        <div class="card mb-4 shadow-sm">
            <div class="card-header">
                 <h4 class="my-0 font-weight-normal">
                     {{product.productName}}
                 </h4>
            </div>
            <div class="card-body">
                <img :src="product.avatar" class="img-fluid" alt=""/>
                <h1 class="card-title pricing-card-title">{{product.price}} <small class="text-muted"> VND</small></h1>
                <router-link :to="{path: './edit/' + product.productId }" >
                <button
                    type="button" 
                    class="bg-info btn btn-lg btn-block btn-outline-primary">
                Chỉnh sửa
                </button>
                 </router-link>
                <button class = "bg-info btn btn-lg btn-block btn-outline-primary"
                @click.prevent="OnDelete(product.productId)"
                >
                Xóa</button>
                 
            </div>
        </div>
</template>

<script>
import catalogApi from '~/api/catalogApi';
export default {
    props:{
        product:{
            type: Object,
            required: true,
            default(){
                return {}
            },
        },
    },
    methods :{
        addToCart(){
            this.$emit('add-to-cart',this.product);
        },
        outOfStock(){
            this.$emit('out-of-stock',this.product.productName);
        },
        async OnDelete(id){
            try {
                await catalogApi.deleteProduct(this.$axios, id)
                alert("Xử lý thành công")
                this.$router.go()
            } catch (err) {
                
            }
            
        }
    },
}
</script>
<style>
.delete_new
{
    border: 40px;
    padding: 0 50px;
    color: red;
}
</style>