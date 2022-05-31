<template>
    <div class="container">
      <div class="row">
        <div class="col-12 col-md-4 mb-3 text-center"
              v-for="(product,index) in listProducts"
                    :key="index">
            <ProductSummary2 
                      :product="product"
                      />
        </div>
      </div>
    </div>
</template>

<script>
import catalogApi from '@/api/catalogApi'
import ProductSummary2 from '@/components/Index/ProductSummary2'
export default {
    layout: 'admin',
    components:{ ProductSummary2 },
    data(){
        return{
             listProducts:{}
        }
    },
    async created(){
        await this.getAllProducts()
    },
    methods:{
        async getAllProducts(){
            try{
                const {data}  = await catalogApi.getProducts(this.$axios)
                console.log(data)
                this.listProducts = data
            }
            catch(err){
                console.log(err)
            }
        }
    }

}
</script>