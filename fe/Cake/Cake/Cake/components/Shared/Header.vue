<template>
  <header>
    <div class="new" id="new">
      <b-navbar  type="dark" variant="info">
        <b-navbar-brand class="Logo_new" href="#">
         <img src="https://themesflat.com/html/kababi/assets/img/logo/logo@2x.png" alt="">
        </b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse class="nav_new" id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item>
              <nuxt-link id="nav" to="/">Trang Chủ</nuxt-link>
            </b-nav-item>
            <b-nav-item id="nav" href="/about">Giới Thiệu</b-nav-item>
            <b-nav-item-dropdown text="Sản Phẩm" right>
              <b-dropdown-item href="/index1"
                >Bánh Tiramisu Italia</b-dropdown-item
              >
              <b-dropdown-item href="/index2"
                >Bánh Sachertorte Áo</b-dropdown-item
              >
              <b-dropdown-item href="/index3"
                >Bánh Tapioca Brazil</b-dropdown-item
              >
              <b-dropdown-item href="/index4"
                >Bánh Macaron Pháp</b-dropdown-item
              >
            </b-nav-item-dropdown>
            <b-nav-item href="#">
              <nuxt-link id="nav" to="/dathang">Đặt Hàng</nuxt-link>
            </b-nav-item>
            <b-nav-item>
              <nuxt-link id="nav" to="/contact">Liên Hệ</nuxt-link>
            </b-nav-item>
          </b-navbar-nav>

          <!-- Right aligned nav items -->
          <b-navbar-nav class="ml-auto">
            <b-nav-form>
            </b-nav-form>
            <b-nav-item href="#">
              <nuxt-link
                v-if="!loginedName"
                class="navcake"
                id="nav"
                to="/login"
                >Đăng nhập</nuxt-link
              >
              <div v-else class="">
                <p id="nav" href="#">Hello User</p>
                <a class="btn btn-outline-primary border" id="nav" @click="signOut()"
                  >Logout</a
                >
              </div>
            </b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
  </header>
</template>

<script>
import { mapActions } from 'vuex'
const user = JSON.parse(localStorage.getItem('user'))
export default {
  data() {
    return {
      loginedName: user.token,
    }
  },
  methods: {
    ...mapActions({
      logout: 'user/logout',
    }),
    async signOut() {
      // goi action cua store
      await this.logout()
      // chuyen huong
      this.$router.go()
    },
  },
}
</script>
<style>
.nav_new {
  color: wheat;
}

.navbar-dark .navbar-nav .nav-link {
  color: black;
}
.bg-info {
  background: #262626  !important;
}
.new img {
  width: 195px;
}
.navbar-dark .navbar-nav .nav-link {
  font-size: 25px;
  text-decoration: none;
}
.navbar-expand-lg .navbar-nav .nav-link {
  padding-left: 2.5rem;
}
#nav {
  text-decoration: none;
  color: white;
}
.navbar-dark .navbar-nav .nav-link {
  color: white;
}
.navbar-dark .navbar-nav .nav-link:hover {
  color: deeppink;
}

#nav:hover {
  color: deeppink;
}
/* header{
  position: fixed;
  width: 100%;
  z-index: 999 ;

} */

.border{
  padding: 10px 30px;
}
.Logo_new{
  width: 100px;

}
.navbar-expand .navbar-collapse{
  padding: 0 133px;
   width: 100px;
}
</style>
