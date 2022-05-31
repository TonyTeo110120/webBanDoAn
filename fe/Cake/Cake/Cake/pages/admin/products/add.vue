<template>
  <div class="add_team">
    <form action="" @submit.prevent="onSubmit">
      <div>
        <label for="">Tên sản phẩm </label>
        <input
          v-model="dataSubmit.productName"
          type="text"
          class="form-control"
        />
      </div>
      <div>
        <label for="">Danh mục</label>
        <select v-model="dataSubmit.categoryId" name="" class="form-control">
          <option
            v-for="(category, index) in categories"
            :key="index"
            :value="category.categoryId"
          >
            {{ category.categoryName }}
          </option>
        </select>
      </div>
      <div>
        <label for="">Giá tiền</label>
        <input v-model="dataSubmit.price" type="number" class="form-control" />
      </div>
      <div>
        <label for="">Hình ảnh </label>
        <input v-model="dataSubmit.avatar" type="text" class="form-control" />
      </div>
      <div>
        <label for="">Tồn kho </label>
        <input
          v-model="dataSubmit.inStocks"
          type="number"
          class="form-control"
        />
      </div>
      <button type="submit" class="bg-info btn btn-primary">Lưu</button>
      <button type="reset" class="btn btn-outline-primary">Nhập lại</button>
    </form>
  </div>
</template>

<script>
import catalogApi from '@/api/catalogApi'
export default {
  layout: 'admin',
  middleware: ['isAuthorize'],
  data() {
    return {
      dataSubmit: {},
      categories: [],
    }
  },
  async created() {
    await this.getCategories()
  },

  methods: {
    async getCategories() {
      try {
        const { data } = await catalogApi.getCategories(this.$axios)
        this.categories = data
      } catch (err) {}
    },
    async onSubmit() {
      try {
        await catalogApi.addProduct(this.$axios, this.dataSubmit)
        alert('Thêm sản phẩm thành công')
        this.$router.push('/admin')
      } catch (err) {
        alert('Có lỗi xảy ra' + JSON.stringify(err))
      }
    },
  },
}
</script>
<style>
.add_team {
  padding-left: 5rem;
  padding-right: 5rem;
}
</style>
