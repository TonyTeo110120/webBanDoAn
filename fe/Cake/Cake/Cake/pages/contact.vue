<template>
    <div>
        <form class="Contact_new" action="" @submit.prevent="onSubmit">
            <div>
                <label for="">Họ tên </label>
                <input 
                    v-model="dataSubmit.hoTen"
                    type="text" class="form-control">
            </div>
            <div>
                <label for="">Số điện thoại </label>
                <input 
                    v-model="dataSubmit.soDienThoai"
                    type="text" class="form-control">
            </div>
            <div>
                <label for="">Địa chỉ email</label>
                <input 
                    v-model="dataSubmit.diaChiEmail"
                    type="text" class="form-control">
            </div>
            <div>
                <label for="">Nội dung  </label>
                <textarea 
                    v-model="dataSubmit.noiDung"
                    type="text" class="form-control"></textarea>
            </div>
            <button type = "submit" class = "btn btn-primary"> Gửi </button>
            <button type = "reset" class = "btn btn-outline-primary">Nhập lại</button>
        </form>
    </div>
</template>

<script>
import catalogApi from '@/api/catalogApi'
export default {
    middleware: ['isAuthorize'],
    data(){
        return {
            dataSubmit:{},
        }
    },

    methods:{
        async onSubmit(){
            try{
                await catalogApi.addContact(this.$axios,this.dataSubmit)
                alert('Bạn đã gửi liên hệ thành công')
                this.$router.push('/')
            }
            catch(err){
                alert('Có lỗi xảy ra' + JSON.stringify(err))
            }
        }
    }
}
</script>
<style>
.Contact_new{
    color: aliceblue;
}

</style>