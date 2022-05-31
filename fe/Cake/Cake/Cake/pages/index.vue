<template>
  <main>
    <div class="index_new">
      <h1 class="contact">Sản Phẩm</h1>
    </div>

    <div class="mb-3 text-center container" id="programs">
      <li class="programs_new">
        <nuxt-link class="product_new btn btn-outline-primary" to="/index1"
          >Đồ Ăn
        </nuxt-link>
      </li>
      <li class="programs_new">
        <nuxt-link class="product_new btn btn-outline-primary" to="/index2"
          >Đồ Uống
        </nuxt-link>
      </li>
      <li class="programs_new">
        <nuxt-link class="product_new btn btn-outline-primary" to="/index3"
          >Bánh Kem
        </nuxt-link>
      </li>
      <li class="programs_new">
        <nuxt-link class="product_new btn btn-outline-primary" to="/index4"
          >Tráng Miệng
        </nuxt-link>
      </li>
    </div>
    <div class="team_new container">
      <div class="row">
        <div
          class="col-12 col-md-4 mb-3 text-center"
          v-for="(product, index) in listProducts"
          :key="index"
        >
          <ProductSummary :product="product" />
        </div>
      </div>
    </div>
  </main>
</template>
<script>
import ProductSummary from '@/components/Index/ProductSummary.vue'
import catalogApi from '@/api/catalogApi'

export default {
  
  components: {
    ProductSummary,
  },
  layout: 'default',
  data() {
    return {
      listProducts: [],
      categories: [],
      search:{}
    }
  },
  async created() {
    await this.getAllProducts()
    await this.getCategories()
    
  },
  mounted() {},
  methods: {
    //
    async getAllProducts() {
      try {
        const { data } = await catalogApi.getProducts(this.$axios)
        console.log(data)
        this.listProducts = data
      } catch (err) {
        console.log(err)
      }
    },
    async getCategories() {
      try {
        const { data } = await catalogApi.getCategories(this.$axios)
        console.log(data)
        this.categories = data
      } catch (err) {
        console.log(err)
      }
    },
     async searchData(nameData){
        try{
          const {data} = await catalogApi.searchData(this.$axios,nameData)
          console.log(data)
          this.listProducts = data
        }
        catch{
        }
      }
  },
}
</script>
<style>
.contact {
  margin-left: 42rem;
  color: #d6d8db !important;
  padding: 16px 0;
}

.text-center {
  display: flex;
  list-style: none;
}
.product_new {
  margin: 0 85px;
  background-color: #2f2f2f;
  color: white;
}
.team_new {
  background-color: rgba(255, 255, 255, 0.163);
}
.form_index {
  /* margin-left: 60rem; */

  margin-top: 2rem;
  margin-bottom: 2rem;
}
.index_new {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.index_content {
  padding: 3px 37px;
}
</style>
