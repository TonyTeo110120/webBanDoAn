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
    <div class="container">
      <div id="new" class="row">
        <div
          v-for="(product, index) in listProducts"
          :key="index"
          class="col-12 col-md-4 mb-3 text-center"
        >
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
  components: { ProductSummary },
  layout: 'default',

  data() {
    return {
      listProducts: [],
      categories: [],
    }
  },
  async created() {
    await this.getCategories()
    await this.getProductsBySort()
  },
  mounted() {},
  methods: {
    addCart(obj) {
      // eslint-disable-next-line no-console
      console.log(obj)
      this.$bvToast.toast('Add successful: ' + obj.productName, {
        title: 'Information',
        variant: 'success',
      })
    },
    alert(productName) {
      this.$bvToast.toast('Out of Stocks: ' + productName, {
        title: 'Waring',
        variant: 'danger',
      })
    },

    async getCategories() {
      try {
        const { data } = await catalogApi.getCategories(this.$axios)
        this.categories = data
      } catch (err) {
        console.log(err)
      }
    },
    async getProductsBySort() {
      try {
        const { data } = await catalogApi.getProductsByCategories(
          this.$axios,
          1
        )
        console.log(data)

        this.listProducts = data
      } catch (err) {
        console.log(err)
      }
    },
  },
}
</script>
<style>
.contact {
  text-align: center;
  color: deeppink;
}
</style>
