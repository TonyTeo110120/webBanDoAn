<template>
  <div class="card mb-4 shadow-sm">
    <div class="card-header">
      <h4 class="my-0 font-weight-normal">
        {{ product.productName }}
      </h4>
    </div>
    <div class="card-body">
      <router-link :to="{ path: './detail_product/' + product.productId }">
        <img :src="product.avatar" class="img-fluid" alt="" />
      </router-link>
      <h1 class="card-title pricing-card-title">
        {{ product.price }} <small class="text-muted"> VND</small>
      </h1>
      <router-link :to="{ path: './dathang/' + product.productId }">
        <button
          type="button"
          class="productSummary-new btn btn-lg btn-block btn-outline-primary"
          @click="addToCart"
        >
          Đặt ngay
        </button>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    product: {
      type: Object,
      required: true,
      default() {
        return {}
      },
    },
  },
  methods: {
    addToCart() {
      this.$emit('add-to-cart', this.product)
    },
    outOfStock() {
      this.$emit('out-of-stock', this.product.productName)
    },
  },
}
</script>
<style>
.productSummary-new:hover {
  text-decoration: none;
}
.btn-outline-primary {
  color: #ff0047;
  border-color: #ff0000;
}
.mb-3,
.my-3 {
  padding-left: 47px;
}
.card {
  background-color: rgba(49, 46, 46, 0.615);
}
</style>