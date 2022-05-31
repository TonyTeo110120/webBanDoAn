<template>
    <div class="text-danger card mb-4 shadow-sm">
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                    STT : {{donhang.donHangId}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Tên sản phẩm: {{donhang.productName}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Số lượng: {{donhang.soLuong}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Thành tiền: {{donhang.price}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Địa chỉ: {{donhang.diaChi}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Số điện thoại: {{donhang.soDienThoai}}
                 </p>
            </div>
            <div ></div>
            <button class = "bg-info btn btn-primary"
             @click.prevent="OnDelete(donhang.donHangId)"
            >Xử lý đơn hàng</button>
        </div>
</template>


<script>
import catalogApi from '@/api/catalogApi'

export default {
    props:{
        donhang:{
            type: Object,
            required: true,
            default(){
                return {}
            },
        },
    },
    async created(){
        await this.OnDelete()
    },
    methods:{
        async OnDelete(id){
            try {
                await catalogApi.deleteDonHang(this.$axios, id)
                alert("Xử lý thành công")
                this.$router.go()
            } catch (error) {
            }
            
        }
    }
}
</script>