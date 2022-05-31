<template>
  <div>
    <ul class="admin_team">
      <li>
        <nuxt-link id="admin_new" :to="'/admin'"> Home </nuxt-link>
        <nuxt-link id="admin_new" :to="'/admin/products/add'">
          Thêm sản phẩm
        </nuxt-link>
        <nuxt-link id="admin_new" :to="'/admin/contact'">
          Xử lý các liên hệ
        </nuxt-link>
        <nuxt-link id="admin_new" :to="'/admin/donhang'">
          Xử lý đơn hàng
        </nuxt-link>
        <nuxt-link id="admin_new" :to="'/admin/products/products'">
          Chỉnh sửa sản phẩm
        </nuxt-link>
        <button class="button_new bg-info btn btn-primary" @click="signOut()">
          Đăng xuất
        </button>
      </li>
      <div></div>
    </ul>
    <Nuxt />
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
export default {
  computed: {
    ...mapGetters({
      isAdmin: 'user/isAdmin',
      isUser: 'user/isUser',
    }),
  },
  methods: {
    ...mapActions({
      logout: 'user/logout',
    }),
    async signOut() {
      // goi action cua store
      await this.logout()
      // chuyen huong
      this.$router.push('/')
    },
  },
}
</script>
<style>
.admin_team {
  background: linear-gradient(to right, #ffc845, #fe3859);
  list-style: none;
}
#admin_new {
  color: white;
  list-style: none;
  text-decoration: none;
  padding: 0 31px;
  font-size: 30px;
}
#admin_new:hover {
  color: #fe3859;
}
.button_new {
  margin-bottom: 8px;
}
</style>
