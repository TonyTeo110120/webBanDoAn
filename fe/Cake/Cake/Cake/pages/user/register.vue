<template>
    <div>
        <form class="regisiter_new" action="" @submit.prevent="onSubmit">
            <div>
                <label for="">Tên tài khoản</label>
                <input 
                    v-model="dataSubmit.username"
                    type="text" class="form-control">
            </div>
            <div>
                <label for="">Mật khẩu </label>
                <input 
                    v-model="dataSubmit.password"
                    type="password" class="form-control">
            </div>
            <div>
                <label for="">Họ tên</label>
                <input 
                    v-model="dataSubmit.hoten"
                    type="text" class="form-control">
            </div>
            <div>
                <label for="">Email </label>
                <input
                    v-model="dataSubmit.email"
                    type="text" class="form-control">
            </div>
            <button type = "submit" class = "btn btn-primary"> Gửi </button>
            <button type = "reset" class = "btn btn-outline-primary">Nhập lại</button>
        </form>
    </div>
</template>

<script>
import accountApi from '@/api/accountApi'
export default {
   
    data(){
        return {
            dataSubmit:{},
        }
    },

    methods:{
        async onSubmit(){
            try{
                await accountApi.register(this.$axios,this.dataSubmit)
                alert('Bạn đã đăng ký thành công')
                this.$router.push('/login')
            }
            catch(err){
                alert('Có lỗi xảy ra')
                console.log(err)
            }
        }
    }
}
</script>
<style>
.regisiter_new{
    color: aliceblue;
}


</style>