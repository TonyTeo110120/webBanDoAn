<template>
    <div class="login_new container">
        <form action="" @submit.prevent="onSubmit">
            <div class="form-group">
                <label for="">Tài khoản</label>
                <input
                 v-model="dataSubmit.username"
                 type="text" class="form-control" >
            </div>
            <div class="form-group">
                <label for="">Mật Khẩu</label>
                <input 
                 v-model="dataSubmit.password"
                 type="password" class="form-control" >
            </div>
            <button type="submit">Đăng nhập</button>
        </form>
        <h3>Chưa có tài khoản ? <a class="login-new" href="/user/register">Đăng ký ngay</a></h3>
    </div>
</template>

<script>
import { mapActions } from 'vuex'
import accountApi from '@/api/accountApi'

export default {
    layout: 'default',
    data(){
        return ({
            dataSubmit: {
                username: '',
                password: '',
            }
        })
    },
    methods: {
        ...mapActions({
            setToken: 'user/setToken',
            setRole: 'user/setRole',
        }),
        async onSubmit(){
            try{
                const  data  = await accountApi.login(this.$axios, this.dataSubmit)
                console.log(data.access_token)
                await this.setToken(data.access_token)
                await this.setRole(data.role)
                if(data.role === "admin") this.$router.push('/admin')
                else {
                    this.$router.push('/')
                    }
            }
            catch(err){
                console.log(err)
                alert("sai tên đăng nhập hoặc mât khẩu")
            }
        }
    },
}
</script>
<style>
.login-new{
    color: aqua;
}
.login-new:hover{
    text-decoration: none;
    color: deeppink;
}
.login_new{
    color: aliceblue;
}
</style>