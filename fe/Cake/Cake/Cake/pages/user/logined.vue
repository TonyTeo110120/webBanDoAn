<template>
  <main>
    <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
      <h1 class="display-4">Pricing</h1>
      <p class="lead">Quickly build an effective pricing table for your potential customers with this Bootstrap example. It’s built with default Bootstrap components and utilities with little customization.</p>
    </div>

    <div class="mb-3 text-center">
      <nuxt-link class="btn btn-outline-primary" to="#"
        v-for="(category,index) in categories"
        :key="index"> 
        {{category.categoryName}} 
      </nuxt-link>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-12 col-md-4 mb-3 text-center"
              v-for="(product,index) in listProducts"
                    :key="index">
            <ProductSummary 
                      :product="product"
                      @add-to-cart="addCart"
                      @out-of-stock="alert"
                      />
        </div>
      </div>
    </div>
  </main>
</template>

<script>
import ProductSummary from '@/components/Index/ProductSummary.vue'
import catalogApi from '@/api/catalogApi'

export default {
  components:{
    ProductSummary,
  },
  layout: 'default2',
  // middleware: ['isAuthorize'],
  data(){
    return{
      listProducts:[
        ],
      categories:[]
    }
  },
  async created(){
    await this.getAllProducts() 
    await this.getCategories()
  },
  mounted(){

  },
  methods:{
    addCart(obj){
      console.log(obj)
      this.$bvToast.toast('Add successful: '+ obj.productName,{
        title: 'Success',
        variant: 'success'
      })
    },
    alert(productName){
      this.$bvToast.toast('Out of Stocks: '+ productName,{
        title: 'Warning',
        variant: 'danger'
      })
    },
    //
    async getAllProducts(){
      try{
        const {data} = await catalogApi.getProducts(this.$axios)
        console.log(data)
        this.listProducts = data
      }
      catch(err){
        console.log(err)
      }
    },
     async getCategories(){
      try{
        const {data} = await catalogApi.getCategories(this.$axios)
        console.log(data)
        this.categories = data
      }
      catch(err){
        console.log(err)
      }
    },
    
  },
}
</script>